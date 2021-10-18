using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace PowerSupply
{
    namespace xantrax_response
    {
        public class ID_RespArgs : EventArgs
        {
            public readonly string id;
            public ID_RespArgs(string id)
            {
                this.id = id;
            }
        }
        public delegate void ID_RespHander(object sender, ID_RespArgs e);

        public class Voltage_RespArgs : EventArgs
        {
            public readonly float voltage;
            public Voltage_RespArgs(float voltage)
            {
                this.voltage = voltage;
            }
        }
        public delegate void Voltage_RespHandler(object sender, Voltage_RespArgs e);

        public class Current_RespArgs : EventArgs
        {
            public readonly float current;
            public Current_RespArgs(float current)
            {
                this.current = current;
            }
        }
        public delegate void Current_RespHandler(object sender, Current_RespArgs e);

    }

    public class xantrax
    {
        #region constant
        const UInt32 RCV_BUF_SZ = 8192;
        #endregion

        #region delegates
        public event xantrax_response.ID_RespHander ResponseID;
        public event xantrax_response.Voltage_RespHandler ResponseVoltage;
        public event xantrax_response.Current_RespHandler ResponseCurrent;
        #endregion

        #region members
        private Form uiForm;
        private SerialPort serial_port;
        private byte[] receiveBuffer;
        private UInt32 rcvBuff_wrPtr;
        private UInt32 rcvBuff_rdPtr;
        
        public bool Connected { get; private set; }
        #endregion

        public xantrax(Form uiForm)
        {
            this.uiForm = uiForm;
            this.serial_port = new SerialPort();
            this.serial_port.BaudRate = 9600;
            this.serial_port.Handshake = Handshake.None;
            this.serial_port.DataBits = 8;
            this.serial_port.Parity = Parity.None;
            this.serial_port.StopBits = StopBits.One;
            this.serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedEventHandler);

            this.receiveBuffer = new byte[RCV_BUF_SZ];
            this.rcvBuff_rdPtr = 0;
            this.rcvBuff_wrPtr = 0;
        }

        public void Connect(string portName)
        {
            if (this.serial_port.IsOpen) {
                this.serial_port.Close();
            }
            this.serial_port.PortName = portName;
            this.serial_port.Open();
        }

        public void Disconnect()
        {
            if(this.serial_port.IsOpen) {
                this.serial_port.Close();
            }
            this.Connected = false;
        }

        private void SendData(byte[] data)
        {
            if (this.serial_port.IsOpen) {
                this.serial_port.Write(data, 0, data.Length);
            }
        }

        #region Message Handler
        void DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Int32 nBytes = sp.BytesToRead;
            Int32 actualBytes = 0;
            byte[] data = new byte[nBytes];

            UInt32 idx = 0;
            UInt32 length = 0;

            try {
                if (sp.IsOpen) {
                    actualBytes = sp.Read(data, 0, nBytes);
                    // Store to buffer
                    if (actualBytes > 0) {
                        for (idx = 0; idx < actualBytes; idx++) {
                            receiveBuffer[rcvBuff_wrPtr] = data[idx];
                            rcvBuff_wrPtr = ( rcvBuff_wrPtr + 1 ) % RCV_BUF_SZ;
                        }
                    }
                    // Parse Data
                    idx = rcvBuff_rdPtr;
                    while (idx != rcvBuff_wrPtr) {
                        /* Find CR (0x0D) delimiter */
                        if (receiveBuffer[idx] != 0x0D) {
                            idx = ( idx + 1 ) % RCV_BUF_SZ;
                            continue;
                        }

                        idx = ( idx + 1 ) % RCV_BUF_SZ;
                        if (idx == rcvBuff_wrPtr) {
                            /* No additional character in buffer */
                            break;
                        }

                        /* 
                         * It will only reach here if CR delimiter is received.
                         * Calculate length (including CR)
                         */
                        if (idx >= rcvBuff_rdPtr) {
                            length = idx - rcvBuff_rdPtr;
                        } else {
                            length = RCV_BUF_SZ - rcvBuff_rdPtr + idx;
                        }

                        if (length <= 1) {
                            /* No data (it's just CR) */
                            rcvBuff_rdPtr = idx;
                            continue;
                        }

                        /*
                         * Valid packet (remove CR)
                         */
                        byte[] parsedData = new byte[length - 1];
                        for (int i = 0; i < parsedData.Length; i++) {
                            parsedData[i] = receiveBuffer[( rcvBuff_rdPtr + i ) % RCV_BUF_SZ];
                        }
                        ProcessPacket(parsedData);

                        /*
                         * Done with this packet
                         */
                        rcvBuff_rdPtr = idx;
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void ProcessPacket(byte[] data)
        {
            /* Convert byte array to string */
            string str = System.Text.Encoding.Default.GetString(data);

            if(str.Contains("ID")) {
                this.Connected = true;
                /* Reply to ID? */
                if(this.ResponseID != null) {
                    if(this.uiForm != null) {
                        this.uiForm.BeginInvoke(ResponseID, this, new xantrax_response.ID_RespArgs(str));
                    } else {
                        this.ResponseID.Invoke(this, new xantrax_response.ID_RespArgs(str));
                    }
                }
            }

            if(str.Contains("VOUT")) {
                string[] substring = str.Split(' ');
                float voltage = Convert.ToSingle(substring[1]);
                if(this.ResponseVoltage != null) {
                    if(this.uiForm != null) {
                        this.uiForm.BeginInvoke(ResponseVoltage, this, new xantrax_response.Voltage_RespArgs(voltage));
                    } else {
                        this.ResponseVoltage.Invoke(this, new xantrax_response.Voltage_RespArgs(voltage));
                    }
                }
            }

            if (str.Contains("IOUT")) {
                string[] substring = str.Split(' ');
                float current = Convert.ToSingle(substring[1]);
                if (this.ResponseCurrent != null) {
                    if (this.uiForm != null) {
                        this.uiForm.BeginInvoke(ResponseCurrent, this, new xantrax_response.Current_RespArgs(current));
                    } else {
                        this.ResponseCurrent.Invoke(this, new xantrax_response.Current_RespArgs(current));
                    }
                }
            }
        }
        #endregion

        #region Command
        public void GetID()
        {
            string cmd = "ID?\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }

        public void GetErr()
        {
            string cmd = "ERR?\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }
        public void GetVoltage()
        {
            string cmd = "VOUT?\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }

        public void SetVoltage(float voltage)
        {
            string cmd = "VSET " + voltage.ToString("#.000") + "\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }

        public void GetCurrent()
        {
            string cmd = "IOUT?\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }

        public void SetCurrent(float current)
        {
            string cmd = "ISET " + current.ToString("#.000") + "\r";
            this.SendData(Encoding.Default.GetBytes(cmd));
        }

        public void SetOutput(bool on)
        {
            if(on) {
                string cmd = "OUT ON\r";
                this.SendData(Encoding.Default.GetBytes(cmd));
            } else {
                string cmd = "OUT OFF\r";
                this.SendData(Encoding.Default.GetBytes(cmd));
            }
        }
        #endregion
    }
}
