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
    namespace keithley_response
    {

    }

    public class keithley
    {
        #region members
        private Form uiForm;
        private ResourceManager resource_manager;
        private FormattedIO488 instrument;
        public Int16 timeout;
        public string identification;
        #endregion

        public keithley(Form uiForm)
        {
            this.uiForm = uiForm;
            this.resource_manager = new ResourceManager();
            this.instrument = new FormattedIO488();
            this.timeout = 5000;   /* 5s */
        }

        public void Connect(string instrumentID)
        {
            this.instrument.IO = (IMessage)this.resource_manager.Open(instrumentID, AccessMode.NO_LOCK, this.timeout, "");
            this.instrument.IO.Clear();
            this.instrument.IO.Timeout = this.timeout;
            this.instrument.IO.TerminationCharacterEnabled = true;
            this.instrument.IO.TerminationCharacter = 0x0A;

            /* Set to REMOTE */
            this.Write("SYST:REM");
        }

        public void Disconnect()
        {
            if(this.instrument.IO != null) {
                this.instrument.IO.Close();
                this.instrument.IO = null;
            }
        }

        private void Write(string command)
        {
            if(this.instrument.IO != null) {
                this.instrument.WriteString("SYST:REM\n");
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
                this.Write("INST:NSEL " + ( channel + 1 ).ToString());
                this.Write("VOLT " + voltage);
            }
        }

        public float GetVoltage(byte channel)
        {
            float retval = 0.0f;
            if(channel < 3) {
                string strValue;
                this.Write("INST:NSEL " + ( channel + 1 ).ToString());
                this.Write("MEAS:VOLT?");
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

        public float GetCurrent(byte channel)
        {
            float retval = 0.0f;
            if (channel < 3) {
                string strValue;
                this.Write("INST:NSEL " + ( channel + 1 ).ToString());
                this.Write("MEAS:CURR?");
                strValue = this.Read();
                retval = Convert.ToSingle(strValue);
            }
            return ( retval );
        }

        public void OutputEnable(bool enable)
        {
            if(enable) {
                this.Write("OUTP 1");
            } else {
                this.Write("OUTP 0");
            }
        }
        #endregion
    }
}
