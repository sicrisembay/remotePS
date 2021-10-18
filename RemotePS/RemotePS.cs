using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using PowerSupply;
using PowerSupply.xantrax_response;

namespace RemotePS
{
    public partial class RemotePS : Form
    {
        #region members
        private xantrax powerSupply;
        private float voltage;
        private float current;
        private string file_log;
        private FileStream file_stream_log;
        private BinaryWriter binary_writer_log;
        #endregion
        public RemotePS()
        {
            InitializeComponent();

            this.GetSerialPorts();
            this.SetConnectProperty(false);
            this.powerSupply = new xantrax(this);
            this.powerSupply.ResponseID += this.ID_RespHander;
            this.powerSupply.ResponseVoltage += this.Voltage_RespHandler;
            this.powerSupply.ResponseCurrent += this.Current_RespHandler;
        }

        #region Helpers
        private void GetSerialPorts()
        {
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;

            cboPorts.Items.Clear();
            cboPorts.Text = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            if (ArrayComPortsNames.GetUpperBound(0) >= 0) {
                do {
                    index += 1;
                    cboPorts.Items.Add(ArrayComPortsNames[index]);
                }
                while (!( ( ArrayComPortsNames[index] == ComPortName ) ||
                      ( index == ArrayComPortsNames.GetUpperBound(0) ) ));
                Array.Sort(ArrayComPortsNames);
                if (index == ArrayComPortsNames.GetUpperBound(0)) {
                    ComPortName = ArrayComPortsNames[0];
                }
                cboPorts.Text = ArrayComPortsNames[0];
            }
        }

        private void SetConnectProperty(bool isConnected)
        {
            this.cboPorts.Enabled = !isConnected;
            this.btnGetSerialPorts.Enabled = !isConnected;
            this.timer_poll.Enabled = isConnected;
            this.groupBox_main.Enabled = isConnected;
            this.timer_log.Enabled = isConnected;
            this.OpenLogStream();
            this.label_logFilename.Text = "Log File: " + Path.GetFileName(this.file_log);
        }

        #endregion

        #region Event Handlers
        #region Xantrax Event Handlers
        private void ID_RespHander(object sender, ID_RespArgs e)
        {
            this.Text = e.id;
        }

        private void Voltage_RespHandler(object sender, Voltage_RespArgs e)
        {
            this.voltage = e.voltage;
            this.label_voltage.Text = "voltage: " + e.voltage.ToString("#.000") + " V";
        }

        private void Current_RespHandler(object sender, Current_RespArgs e)
        {
            this.current = e.current;
            this.label_current.Text = "current: " + e.current.ToString("#.000") + " A";
        }
        #endregion
        #region Button Event Handlers
        private void btnGetSerialPorts_Click(object sender, EventArgs e)
        {
            this.GetSerialPorts();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect") {
                try {
                    this.powerSupply.Connect(this.cboPorts.Text);
                    this.powerSupply.GetID();
                    this.powerSupply.GetID();
                    this.powerSupply.GetErr();
                    this.powerSupply.SetOutput(false);
                    btnConnect.Text = "Disconnect";
                    this.SetConnectProperty(true);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else if (btnConnect.Text == "Disconnect") {
                try {
                    btnConnect.Text = "Connect";

                    this.SetConnectProperty(false);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #endregion


        private void timer_poll_Tick(object sender, EventArgs e)
        {
            this.powerSupply.GetVoltage();
            this.powerSupply.GetCurrent();
        }

        private void button_setVoltage_Click(object sender, EventArgs e)
        {
            try {
                float voltage = Convert.ToSingle(textBox_voltage.Text);
                this.powerSupply.SetVoltage(voltage);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_setCurrent_Click(object sender, EventArgs e)
        {
            try {
                float current = Convert.ToSingle(textBox_current.Text);
                this.powerSupply.SetCurrent(current);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_on_off_Click(object sender, EventArgs e)
        {
            if(button_on_off.Text == "ON") {
                this.powerSupply.SetOutput(true);
                button_on_off.Text = "OFF";
            } else {
                this.powerSupply.SetOutput(false);
                button_on_off.Text = "ON";
            }
        }

        #region Logging
        private void OpenLogStream()
        {
            // Close and create new stream
            this.CloseLogStream();
            this.file_log = this.GenerateFileName("PowerSupply");
            this.file_stream_log = new FileStream(this.file_log, FileMode.Append, FileAccess.Write, FileShare.Read);
            this.binary_writer_log = new BinaryWriter(this.file_stream_log);
        }

        private void CloseLogStream()
        {
            if (null != this.binary_writer_log) {
                this.binary_writer_log.Flush();
                this.binary_writer_log.Close();
                this.binary_writer_log = null;
            }

            if (null != this.file_stream_log) {
                this.file_stream_log.Close();
                this.file_stream_log = null;
            }
        }
        private string GenerateFileName(string name)
        {
            // Filename: MotorX_YYYYMMDD_HHMMSS.csv
            DateTime dateTimeStamp = DateTime.Now;
            string streamFileName = Path.Combine(Environment.CurrentDirectory, name + "_" +
                            dateTimeStamp.Year.ToString("D4") +
                            dateTimeStamp.Month.ToString("D2") +
                            dateTimeStamp.Day.ToString("D2") + "_" +
                            dateTimeStamp.Hour.ToString("D2") +
                            dateTimeStamp.Minute.ToString("D2") +
                            dateTimeStamp.Second.ToString("D2") + ".csv");
            return streamFileName;

        }
        #endregion

        private void timer_log_Tick(object sender, EventArgs e)
        {
            if (this.binary_writer_log != null) {
                DateTime timestamp = DateTime.Now;
                var msTimestamp = ( ( ( ( ( timestamp.Hour * 60 ) + timestamp.Minute ) * 60 ) + timestamp.Second ) * 1000 ) + timestamp.Millisecond;
                string logString = DateTime.Now.ToString() + ", ";
                logString += this.voltage.ToString("#.000") + ", ";
                logString += this.current.ToString("#.000") + ", ";
                logString += Environment.NewLine;
                this.binary_writer_log.Write(Encoding.Default.GetBytes(logString));
            }

        }
    }
}
