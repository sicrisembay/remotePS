
namespace RemotePS
{
    partial class RemotePS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetSerialPorts = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cboPorts = new System.Windows.Forms.ComboBox();
            this.timer_poll = new System.Windows.Forms.Timer(this.components);
            this.textBox_voltage = new System.Windows.Forms.TextBox();
            this.textBox_current = new System.Windows.Forms.TextBox();
            this.groupBox_main = new System.Windows.Forms.GroupBox();
            this.button_on_off = new System.Windows.Forms.Button();
            this.button_setVoltage = new System.Windows.Forms.Button();
            this.label_current = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_voltage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_log = new System.Windows.Forms.Timer(this.components);
            this.label_logFilename = new System.Windows.Forms.Label();
            this.textBox_logInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_IVI_devices = new System.Windows.Forms.ComboBox();
            this.btnGetIVIdevices = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKeithleyConnect = new System.Windows.Forms.Button();
            this.lbl_KeithleyDevice = new System.Windows.Forms.Label();
            this.btn_Keithley_output = new System.Windows.Forms.Button();
            this.lbl_voltage_ch1 = new System.Windows.Forms.Label();
            this.lbl_current_ch1 = new System.Windows.Forms.Label();
            this.timer_keithley_poll = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_voltage_ch1 = new System.Windows.Forms.TextBox();
            this.textBox_current_ch1 = new System.Windows.Forms.TextBox();
            this.btn_set_ch1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_set_ch2 = new System.Windows.Forms.Button();
            this.lbl_current_ch2 = new System.Windows.Forms.Label();
            this.textBox_current_ch2 = new System.Windows.Forms.TextBox();
            this.lbl_voltage_ch2 = new System.Windows.Forms.Label();
            this.textBox_voltage_ch2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_set_ch3 = new System.Windows.Forms.Button();
            this.lbl_current_ch3 = new System.Windows.Forms.Label();
            this.textBox_current_ch3 = new System.Windows.Forms.TextBox();
            this.lbl_voltage_ch3 = new System.Windows.Forms.Label();
            this.textBox_voltage_ch3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox_keithley = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnKeithleyReset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox_main.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox_keithley.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnGetSerialPorts);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.cboPorts);
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 57);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // btnGetSerialPorts
            // 
            this.btnGetSerialPorts.Location = new System.Drawing.Point(159, 20);
            this.btnGetSerialPorts.Name = "btnGetSerialPorts";
            this.btnGetSerialPorts.Size = new System.Drawing.Size(78, 21);
            this.btnGetSerialPorts.TabIndex = 4;
            this.btnGetSerialPorts.Text = "Refresh";
            this.btnGetSerialPorts.UseVisualStyleBackColor = true;
            this.btnGetSerialPorts.Click += new System.EventHandler(this.btnGetSerialPorts_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(243, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 21);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cboPorts
            // 
            this.cboPorts.FormattingEnabled = true;
            this.cboPorts.Location = new System.Drawing.Point(57, 19);
            this.cboPorts.Name = "cboPorts";
            this.cboPorts.Size = new System.Drawing.Size(96, 21);
            this.cboPorts.TabIndex = 5;
            // 
            // timer_poll
            // 
            this.timer_poll.Interval = 500;
            this.timer_poll.Tick += new System.EventHandler(this.timer_poll_Tick);
            // 
            // textBox_voltage
            // 
            this.textBox_voltage.Location = new System.Drawing.Point(82, 23);
            this.textBox_voltage.Name = "textBox_voltage";
            this.textBox_voltage.Size = new System.Drawing.Size(51, 20);
            this.textBox_voltage.TabIndex = 9;
            this.textBox_voltage.Text = "48.00";
            // 
            // textBox_current
            // 
            this.textBox_current.Location = new System.Drawing.Point(197, 23);
            this.textBox_current.Name = "textBox_current";
            this.textBox_current.Size = new System.Drawing.Size(51, 20);
            this.textBox_current.TabIndex = 9;
            this.textBox_current.Text = "3.50";
            // 
            // groupBox_main
            // 
            this.groupBox_main.Controls.Add(this.button_on_off);
            this.groupBox_main.Controls.Add(this.button_setVoltage);
            this.groupBox_main.Controls.Add(this.label_current);
            this.groupBox_main.Controls.Add(this.label2);
            this.groupBox_main.Controls.Add(this.label_voltage);
            this.groupBox_main.Controls.Add(this.label1);
            this.groupBox_main.Controls.Add(this.textBox_current);
            this.groupBox_main.Controls.Add(this.textBox_voltage);
            this.groupBox_main.Location = new System.Drawing.Point(24, 84);
            this.groupBox_main.Name = "groupBox_main";
            this.groupBox_main.Size = new System.Drawing.Size(353, 141);
            this.groupBox_main.TabIndex = 10;
            this.groupBox_main.TabStop = false;
            // 
            // button_on_off
            // 
            this.button_on_off.Location = new System.Drawing.Point(115, 92);
            this.button_on_off.Name = "button_on_off";
            this.button_on_off.Size = new System.Drawing.Size(209, 31);
            this.button_on_off.TabIndex = 12;
            this.button_on_off.Text = "ON";
            this.button_on_off.UseVisualStyleBackColor = true;
            this.button_on_off.Click += new System.EventHandler(this.button_on_off_Click);
            // 
            // button_setVoltage
            // 
            this.button_setVoltage.Location = new System.Drawing.Point(34, 92);
            this.button_setVoltage.Name = "button_setVoltage";
            this.button_setVoltage.Size = new System.Drawing.Size(75, 32);
            this.button_setVoltage.TabIndex = 11;
            this.button_setVoltage.Text = "Set";
            this.button_setVoltage.UseVisualStyleBackColor = true;
            this.button_setVoltage.Click += new System.EventHandler(this.button_setVoltage_Click);
            // 
            // label_current
            // 
            this.label_current.AutoSize = true;
            this.label_current.Location = new System.Drawing.Point(154, 51);
            this.label_current.Name = "label_current";
            this.label_current.Size = new System.Drawing.Size(55, 13);
            this.label_current.TabIndex = 10;
            this.label_current.Text = "current: ---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "current:";
            // 
            // label_voltage
            // 
            this.label_voltage.AutoSize = true;
            this.label_voltage.Location = new System.Drawing.Point(31, 51);
            this.label_voltage.Name = "label_voltage";
            this.label_voltage.Size = new System.Drawing.Size(57, 13);
            this.label_voltage.TabIndex = 10;
            this.label_voltage.Text = "voltage: ---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "voltage:";
            // 
            // timer_log
            // 
            this.timer_log.Interval = 1000;
            this.timer_log.Tick += new System.EventHandler(this.timer_log_Tick);
            // 
            // label_logFilename
            // 
            this.label_logFilename.AutoSize = true;
            this.label_logFilename.Location = new System.Drawing.Point(585, 287);
            this.label_logFilename.Name = "label_logFilename";
            this.label_logFilename.Size = new System.Drawing.Size(62, 13);
            this.label_logFilename.TabIndex = 11;
            this.label_logFilename.Text = "Log File: ----";
            // 
            // textBox_logInterval
            // 
            this.textBox_logInterval.Location = new System.Drawing.Point(655, 313);
            this.textBox_logInterval.Name = "textBox_logInterval";
            this.textBox_logInterval.Size = new System.Drawing.Size(42, 20);
            this.textBox_logInterval.TabIndex = 12;
            this.textBox_logInterval.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(703, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "second";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(585, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Log Interval:";
            // 
            // cbo_IVI_devices
            // 
            this.cbo_IVI_devices.FormattingEnabled = true;
            this.cbo_IVI_devices.Location = new System.Drawing.Point(73, 24);
            this.cbo_IVI_devices.Name = "cbo_IVI_devices";
            this.cbo_IVI_devices.Size = new System.Drawing.Size(244, 21);
            this.cbo_IVI_devices.TabIndex = 5;
            // 
            // btnGetIVIdevices
            // 
            this.btnGetIVIdevices.Location = new System.Drawing.Point(323, 24);
            this.btnGetIVIdevices.Name = "btnGetIVIdevices";
            this.btnGetIVIdevices.Size = new System.Drawing.Size(75, 41);
            this.btnGetIVIdevices.TabIndex = 14;
            this.btnGetIVIdevices.Text = "Refresh";
            this.btnGetIVIdevices.UseVisualStyleBackColor = true;
            this.btnGetIVIdevices.Click += new System.EventHandler(this.btnGetIVIdevices_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "IVI Device:";
            // 
            // btnKeithleyConnect
            // 
            this.btnKeithleyConnect.Location = new System.Drawing.Point(404, 24);
            this.btnKeithleyConnect.Name = "btnKeithleyConnect";
            this.btnKeithleyConnect.Size = new System.Drawing.Size(118, 41);
            this.btnKeithleyConnect.TabIndex = 16;
            this.btnKeithleyConnect.Text = "Connect";
            this.btnKeithleyConnect.UseVisualStyleBackColor = true;
            this.btnKeithleyConnect.Click += new System.EventHandler(this.btnKeithleyConnect_Click);
            // 
            // lbl_KeithleyDevice
            // 
            this.lbl_KeithleyDevice.AutoSize = true;
            this.lbl_KeithleyDevice.Location = new System.Drawing.Point(7, 52);
            this.lbl_KeithleyDevice.Name = "lbl_KeithleyDevice";
            this.lbl_KeithleyDevice.Size = new System.Drawing.Size(41, 13);
            this.lbl_KeithleyDevice.TabIndex = 17;
            this.lbl_KeithleyDevice.Text = "IDN: ---";
            // 
            // btn_Keithley_output
            // 
            this.btn_Keithley_output.Location = new System.Drawing.Point(211, 205);
            this.btn_Keithley_output.Name = "btn_Keithley_output";
            this.btn_Keithley_output.Size = new System.Drawing.Size(283, 33);
            this.btn_Keithley_output.TabIndex = 18;
            this.btn_Keithley_output.Text = "ON";
            this.btn_Keithley_output.UseVisualStyleBackColor = true;
            this.btn_Keithley_output.Click += new System.EventHandler(this.btn_Keithley_output_Click);
            // 
            // lbl_voltage_ch1
            // 
            this.lbl_voltage_ch1.AutoSize = true;
            this.lbl_voltage_ch1.Location = new System.Drawing.Point(24, 80);
            this.lbl_voltage_ch1.Name = "lbl_voltage_ch1";
            this.lbl_voltage_ch1.Size = new System.Drawing.Size(57, 13);
            this.lbl_voltage_ch1.TabIndex = 19;
            this.lbl_voltage_ch1.Text = "voltage: ---";
            // 
            // lbl_current_ch1
            // 
            this.lbl_current_ch1.AutoSize = true;
            this.lbl_current_ch1.Location = new System.Drawing.Point(26, 106);
            this.lbl_current_ch1.Name = "lbl_current_ch1";
            this.lbl_current_ch1.Size = new System.Drawing.Size(55, 13);
            this.lbl_current_ch1.TabIndex = 19;
            this.lbl_current_ch1.Text = "current: ---";
            // 
            // timer_keithley_poll
            // 
            this.timer_keithley_poll.Interval = 1000;
            this.timer_keithley_poll.Tick += new System.EventHandler(this.timer_keithley_poll_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_set_ch1);
            this.groupBox2.Controls.Add(this.lbl_current_ch1);
            this.groupBox2.Controls.Add(this.textBox_current_ch1);
            this.groupBox2.Controls.Add(this.lbl_voltage_ch1);
            this.groupBox2.Controls.Add(this.textBox_voltage_ch1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(20, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 177);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "voltage:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "current:";
            // 
            // textBox_voltage_ch1
            // 
            this.textBox_voltage_ch1.Location = new System.Drawing.Point(73, 21);
            this.textBox_voltage_ch1.Name = "textBox_voltage_ch1";
            this.textBox_voltage_ch1.Size = new System.Drawing.Size(48, 20);
            this.textBox_voltage_ch1.TabIndex = 1;
            this.textBox_voltage_ch1.Text = "16.0";
            // 
            // textBox_current_ch1
            // 
            this.textBox_current_ch1.Location = new System.Drawing.Point(73, 48);
            this.textBox_current_ch1.Name = "textBox_current_ch1";
            this.textBox_current_ch1.Size = new System.Drawing.Size(48, 20);
            this.textBox_current_ch1.TabIndex = 2;
            this.textBox_current_ch1.Text = "1.0";
            // 
            // btn_set_ch1
            // 
            this.btn_set_ch1.Location = new System.Drawing.Point(25, 135);
            this.btn_set_ch1.Name = "btn_set_ch1";
            this.btn_set_ch1.Size = new System.Drawing.Size(96, 27);
            this.btn_set_ch1.TabIndex = 3;
            this.btn_set_ch1.Text = "Set";
            this.btn_set_ch1.UseVisualStyleBackColor = true;
            this.btn_set_ch1.Click += new System.EventHandler(this.btn_set_ch1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_set_ch2);
            this.groupBox3.Controls.Add(this.lbl_current_ch2);
            this.groupBox3.Controls.Add(this.textBox_current_ch2);
            this.groupBox3.Controls.Add(this.lbl_voltage_ch2);
            this.groupBox3.Controls.Add(this.textBox_voltage_ch2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(182, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(149, 177);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Channel2";
            // 
            // btn_set_ch2
            // 
            this.btn_set_ch2.Location = new System.Drawing.Point(25, 135);
            this.btn_set_ch2.Name = "btn_set_ch2";
            this.btn_set_ch2.Size = new System.Drawing.Size(96, 27);
            this.btn_set_ch2.TabIndex = 3;
            this.btn_set_ch2.Text = "Set";
            this.btn_set_ch2.UseVisualStyleBackColor = true;
            this.btn_set_ch2.Click += new System.EventHandler(this.btn_set_ch2_Click);
            // 
            // lbl_current_ch2
            // 
            this.lbl_current_ch2.AutoSize = true;
            this.lbl_current_ch2.Location = new System.Drawing.Point(26, 106);
            this.lbl_current_ch2.Name = "lbl_current_ch2";
            this.lbl_current_ch2.Size = new System.Drawing.Size(55, 13);
            this.lbl_current_ch2.TabIndex = 19;
            this.lbl_current_ch2.Text = "current: ---";
            // 
            // textBox_current_ch2
            // 
            this.textBox_current_ch2.Location = new System.Drawing.Point(73, 48);
            this.textBox_current_ch2.Name = "textBox_current_ch2";
            this.textBox_current_ch2.Size = new System.Drawing.Size(48, 20);
            this.textBox_current_ch2.TabIndex = 2;
            this.textBox_current_ch2.Text = "1.0";
            // 
            // lbl_voltage_ch2
            // 
            this.lbl_voltage_ch2.AutoSize = true;
            this.lbl_voltage_ch2.Location = new System.Drawing.Point(24, 80);
            this.lbl_voltage_ch2.Name = "lbl_voltage_ch2";
            this.lbl_voltage_ch2.Size = new System.Drawing.Size(57, 13);
            this.lbl_voltage_ch2.TabIndex = 19;
            this.lbl_voltage_ch2.Text = "voltage: ---";
            // 
            // textBox_voltage_ch2
            // 
            this.textBox_voltage_ch2.Location = new System.Drawing.Point(73, 21);
            this.textBox_voltage_ch2.Name = "textBox_voltage_ch2";
            this.textBox_voltage_ch2.Size = new System.Drawing.Size(48, 20);
            this.textBox_voltage_ch2.TabIndex = 1;
            this.textBox_voltage_ch2.Text = "28.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "current:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "voltage:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_set_ch3);
            this.groupBox4.Controls.Add(this.lbl_current_ch3);
            this.groupBox4.Controls.Add(this.textBox_current_ch3);
            this.groupBox4.Controls.Add(this.lbl_voltage_ch3);
            this.groupBox4.Controls.Add(this.textBox_voltage_ch3);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Location = new System.Drawing.Point(344, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(149, 177);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Channel3";
            // 
            // btn_set_ch3
            // 
            this.btn_set_ch3.Location = new System.Drawing.Point(25, 135);
            this.btn_set_ch3.Name = "btn_set_ch3";
            this.btn_set_ch3.Size = new System.Drawing.Size(96, 27);
            this.btn_set_ch3.TabIndex = 3;
            this.btn_set_ch3.Text = "Set";
            this.btn_set_ch3.UseVisualStyleBackColor = true;
            this.btn_set_ch3.Click += new System.EventHandler(this.btn_set_ch3_Click);
            // 
            // lbl_current_ch3
            // 
            this.lbl_current_ch3.AutoSize = true;
            this.lbl_current_ch3.Location = new System.Drawing.Point(26, 106);
            this.lbl_current_ch3.Name = "lbl_current_ch3";
            this.lbl_current_ch3.Size = new System.Drawing.Size(55, 13);
            this.lbl_current_ch3.TabIndex = 19;
            this.lbl_current_ch3.Text = "current: ---";
            // 
            // textBox_current_ch3
            // 
            this.textBox_current_ch3.Location = new System.Drawing.Point(73, 48);
            this.textBox_current_ch3.Name = "textBox_current_ch3";
            this.textBox_current_ch3.Size = new System.Drawing.Size(48, 20);
            this.textBox_current_ch3.TabIndex = 2;
            this.textBox_current_ch3.Text = "1.0";
            // 
            // lbl_voltage_ch3
            // 
            this.lbl_voltage_ch3.AutoSize = true;
            this.lbl_voltage_ch3.Location = new System.Drawing.Point(24, 80);
            this.lbl_voltage_ch3.Name = "lbl_voltage_ch3";
            this.lbl_voltage_ch3.Size = new System.Drawing.Size(57, 13);
            this.lbl_voltage_ch3.TabIndex = 19;
            this.lbl_voltage_ch3.Text = "voltage: ---";
            // 
            // textBox_voltage_ch3
            // 
            this.textBox_voltage_ch3.Location = new System.Drawing.Point(73, 21);
            this.textBox_voltage_ch3.Name = "textBox_voltage_ch3";
            this.textBox_voltage_ch3.Size = new System.Drawing.Size(48, 20);
            this.textBox_voltage_ch3.TabIndex = 1;
            this.textBox_voltage_ch3.Text = "3.3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "current:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "voltage:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbl_KeithleyDevice);
            this.groupBox5.Controls.Add(this.btnKeithleyConnect);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnGetIVIdevices);
            this.groupBox5.Controls.Add(this.cbo_IVI_devices);
            this.groupBox5.Location = new System.Drawing.Point(8, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(533, 81);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Communication";
            // 
            // groupBox_keithley
            // 
            this.groupBox_keithley.Controls.Add(this.btnKeithleyReset);
            this.groupBox_keithley.Controls.Add(this.groupBox4);
            this.groupBox_keithley.Controls.Add(this.groupBox3);
            this.groupBox_keithley.Controls.Add(this.groupBox2);
            this.groupBox_keithley.Controls.Add(this.btn_Keithley_output);
            this.groupBox_keithley.Enabled = false;
            this.groupBox_keithley.Location = new System.Drawing.Point(8, 105);
            this.groupBox_keithley.Name = "groupBox_keithley";
            this.groupBox_keithley.Size = new System.Drawing.Size(533, 252);
            this.groupBox_keithley.TabIndex = 22;
            this.groupBox_keithley.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox_keithley);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Location = new System.Drawing.Point(12, 25);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(551, 374);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "KEITHLEY";
            // 
            // btnKeithleyReset
            // 
            this.btnKeithleyReset.Location = new System.Drawing.Point(20, 205);
            this.btnKeithleyReset.Name = "btnKeithleyReset";
            this.btnKeithleyReset.Size = new System.Drawing.Size(181, 33);
            this.btnKeithleyReset.TabIndex = 21;
            this.btnKeithleyReset.Text = "RESET";
            this.btnKeithleyReset.UseVisualStyleBackColor = true;
            this.btnKeithleyReset.Click += new System.EventHandler(this.btnKeithleyReset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "COM:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox_main);
            this.groupBox7.Controls.Add(this.groupBox1);
            this.groupBox7.Location = new System.Drawing.Point(583, 25);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(398, 241);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "XANTRAX";
            // 
            // RemotePS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 429);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_logInterval);
            this.Controls.Add(this.label_logFilename);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemotePS";
            this.Text = "Unknown";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_main.ResumeLayout(false);
            this.groupBox_main.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox_keithley.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetSerialPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cboPorts;
        private System.Windows.Forms.Timer timer_poll;
        private System.Windows.Forms.TextBox textBox_voltage;
        private System.Windows.Forms.TextBox textBox_current;
        private System.Windows.Forms.GroupBox groupBox_main;
        private System.Windows.Forms.Label label_current;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_voltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_setVoltage;
        private System.Windows.Forms.Button button_on_off;
        private System.Windows.Forms.Timer timer_log;
        private System.Windows.Forms.Label label_logFilename;
        private System.Windows.Forms.TextBox textBox_logInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_IVI_devices;
        private System.Windows.Forms.Button btnGetIVIdevices;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnKeithleyConnect;
        private System.Windows.Forms.Label lbl_KeithleyDevice;
        private System.Windows.Forms.Button btn_Keithley_output;
        private System.Windows.Forms.Label lbl_voltage_ch1;
        private System.Windows.Forms.Label lbl_current_ch1;
        private System.Windows.Forms.Timer timer_keithley_poll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_set_ch1;
        private System.Windows.Forms.TextBox textBox_current_ch1;
        private System.Windows.Forms.TextBox textBox_voltage_ch1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_set_ch2;
        private System.Windows.Forms.Label lbl_current_ch2;
        private System.Windows.Forms.TextBox textBox_current_ch2;
        private System.Windows.Forms.Label lbl_voltage_ch2;
        private System.Windows.Forms.TextBox textBox_voltage_ch2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_set_ch3;
        private System.Windows.Forms.Label lbl_current_ch3;
        private System.Windows.Forms.TextBox textBox_current_ch3;
        private System.Windows.Forms.Label lbl_voltage_ch3;
        private System.Windows.Forms.TextBox textBox_voltage_ch3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox_keithley;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnKeithleyReset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}

