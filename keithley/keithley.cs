using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Ivi.Visa.Interop;

namespace PowerSupply
{
    public struct ChannelInfo
    {
        public float voltage;
        public float current;
    }

    public class keithley
    {
        #region members
        private const int N_CHANNEL = 3;
        private Thread pollThread;
        private bool bConnected;
        private ResourceManager resource_manager;
        private FormattedIO488 instrument;
        public Int16 timeout;
        public string identification;
        public ChannelInfo[] channelData { private set; get; }
        #endregion

        private void PollThreadFunc()
        {
            this.bConnected = true;

            /* Set to REMOTE and lock front panel */
            this.instrument.WriteString("SYST:RWL\n");

            while (true) {
                Thread.Sleep(10);
                for (byte i = 0; i < N_CHANNEL; i++) {
                    this.channelData[i].voltage = this.GetVoltage(i);
                    this.channelData[i].current = this.GetCurrent(i);
                }
            }
        }

        public keithley(Form uiForm)
        {
            this.pollThread = null;
            this.bConnected = false;
            this.resource_manager = new ResourceManager();
            this.instrument = new FormattedIO488();
            this.timeout = 1000;   /* 5s */

            this.channelData = new ChannelInfo[3];
            for(int i = 0; i < N_CHANNEL; i++) {
                this.channelData[i].current = 0.0f;
                this.channelData[i].voltage = 0.0f;
            }
        }

        public void Connect(string instrumentID)
        {
            this.instrument.IO = (IMessage)this.resource_manager.Open(instrumentID);
            this.instrument.IO.Clear();
            this.instrument.IO.Timeout = this.timeout;
            this.instrument.IO.TerminationCharacterEnabled = true;
            this.instrument.IO.TerminationCharacter = 0x0A;

            /* Create Thread for polling power supply status */
            ThreadStart threadDelegate = new ThreadStart(this.PollThreadFunc);
            if(this.pollThread != null) {
                /* Destroy previous thread instance */
                this.pollThread.Abort();
                this.pollThread.Join();
                this.pollThread = null;
            }
            this.pollThread = new Thread(threadDelegate);
            this.pollThread.Name = "Keithley Worker";
            this.pollThread.IsBackground = true;
            this.pollThread.Start();
        }

        public void Disconnect()
        {
            if(this.instrument.IO != null) {
                this.instrument.WriteString("SYST:LOC\n");
                this.instrument.IO.Close();
                this.instrument.IO = null;
            }

            if (this.pollThread != null) {
                this.pollThread.Abort();
                this.pollThread.Join();
                this.pollThread = null;
            }
        }

        private void Write(string command)
        {
            if(this.instrument.IO != null) {
                this.instrument.WriteString(command + "\n");
            }
        }

        private string Read()
        {
            string retval = null;
            if(this.instrument.IO != null) {
                retval = this.instrument.ReadString();
            }
            return retval;
        }

        #region Command
        public void Reset()
        {
            this.Write("*RST");
        }

        public string GetID()
        {
            this.Write("*IDN?");
            this.identification = this.Read();
            Console.WriteLine(this.identification);

            return this.identification;
        }

        public void SetVoltage(byte channel, float voltage)
        {
            if(channel < 3) {
                this.Write("INST:SEL CH" + ( channel + 1 ).ToString());
                this.Write("VOLT " + voltage);
            }
        }

        private float GetVoltage(byte channel)
        {
            float retval = 0.0f;
            if(channel < 3) {
                string strValue;
                this.Write("INST:SEL CH" + ( channel + 1 ).ToString() + ";:MEAS:VOLT?");
                strValue = this.Read();
                retval = Convert.ToSingle(strValue);
            }
            return ( retval );
        }

        public void SetCurrent(byte channel, float current)
        {
            if (channel < 3) {
                this.Write("INST:NSEL " + ( channel + 1 ).ToString());
                this.Write("CURR " + current);
            }
        }

        private float GetCurrent(byte channel)
        {
            float retval = 0.0f;
            if (channel < 3) {
                string strValue;
                this.Write("INST:SEL CH" + ( channel + 1 ).ToString() + ";:MEAS:CURR?");
                strValue = this.Read();
                retval = Convert.ToSingle(strValue);
            }
            return ( retval );
        }

        public void OutputEnable(bool enable)
        {
            if(enable) {
                this.Write("OUTP ON");
            } else {
                this.Write("OUTP OFF");
            }
        }
        #endregion
    }
}
