namespace WFTest
{
    partial class FrmMain
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.button31 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button34 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.button33 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button32 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.comboBox41 = new System.Windows.Forms.ComboBox();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.button31.Location = new System.Drawing.Point(22, 33);
            this.button31.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(166, 26);
            this.button31.TabIndex = 19;
            this.button31.Text = "闸机程序运行";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM2";
            // 
            // button34
            // 
            this.button34.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.button34.Location = new System.Drawing.Point(20, 71);
            this.button34.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(168, 26);
            this.button34.TabIndex = 26;
            this.button34.Text = "系统退出";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM4";
            // 
            // button33
            // 
            this.button33.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.button33.Location = new System.Drawing.Point(224, 69);
            this.button33.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(167, 26);
            this.button33.TabIndex = 32;
            this.button33.Text = "清空内容";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(33, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 610);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "闸机输出信息";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(498, 563);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox21);
            this.groupBox2.Controls.Add(this.groupBox22);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(550, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 142);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "闸机方向控制";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(215, 37);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox5.Size = new System.Drawing.Size(196, 95);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "出站闸机站点";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(21, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(155, 24);
            this.comboBox3.TabIndex = 7;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.comboBox2);
            this.groupBox21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox21.Location = new System.Drawing.Point(9, 37);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox21.Size = new System.Drawing.Size(196, 95);
            this.groupBox21.TabIndex = 37;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "进站闸机站点";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(13, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(155, 24);
            this.comboBox2.TabIndex = 7;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.radioButton5);
            this.groupBox22.Controls.Add(this.radioButton6);
            this.groupBox22.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox22.Location = new System.Drawing.Point(11, 144);
            this.groupBox22.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.groupBox22.Size = new System.Drawing.Size(194, 101);
            this.groupBox22.TabIndex = 36;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "二维码闸机方向";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(65, 59);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(69, 24);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "出门";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Checked = true;
            this.radioButton6.Location = new System.Drawing.Point(65, 35);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(69, 24);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "进门";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox3.Controls.Add(this.button32);
            this.groupBox3.Controls.Add(this.button31);
            this.groupBox3.Controls.Add(this.button33);
            this.groupBox3.Controls.Add(this.button34);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(550, 613);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 123);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "闸机命令控制";
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.button32.Location = new System.Drawing.Point(224, 33);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(167, 27);
            this.button32.TabIndex = 33;
            this.button32.Text = "卡片注册或充值";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(290, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(691, 94);
            this.label1.TabIndex = 39;
            this.label1.Text = "一芯智能科技闸机控制系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // serialPort3
            // 
            this.serialPort3.PortName = "COM7";
            this.serialPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort3_DataReceived);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox4.Controls.Add(this.label59);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.textBox53);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.textBox52);
            this.groupBox4.Controls.Add(this.comboBox41);
            this.groupBox4.Controls.Add(this.textBox51);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.label42);
            this.groupBox4.Controls.Add(this.label44);
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.label48);
            this.groupBox4.Controls.Add(this.label43);
            this.groupBox4.Controls.Add(this.label49);
            this.groupBox4.Controls.Add(this.label47);
            this.groupBox4.Controls.Add(this.label45);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.label51);
            this.groupBox4.Controls.Add(this.label56);
            this.groupBox4.Controls.Add(this.label57);
            this.groupBox4.Controls.Add(this.label58);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(550, 271);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 336);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "M1卡内金额";
            // 
            // label59
            // 
            this.label59.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label59.ForeColor = System.Drawing.Color.LimeGreen;
            this.label59.Location = new System.Drawing.Point(156, 25);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(258, 18);
            this.label59.TabIndex = 9;
            this.label59.Text = "0";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label52.Location = new System.Drawing.Point(29, 243);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(110, 16);
            this.label52.TabIndex = 8;
            this.label52.Text = "扣款前金额：";
            // 
            // textBox53
            // 
            this.textBox53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox53.Location = new System.Drawing.Point(159, 239);
            this.textBox53.Name = "textBox53";
            this.textBox53.ReadOnly = true;
            this.textBox53.Size = new System.Drawing.Size(222, 26);
            this.textBox53.TabIndex = 7;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label53.Location = new System.Drawing.Point(46, 274);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(93, 16);
            this.label53.TabIndex = 8;
            this.label53.Text = "扣款金额：";
            // 
            // textBox52
            // 
            this.textBox52.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox52.Location = new System.Drawing.Point(159, 269);
            this.textBox52.Name = "textBox52";
            this.textBox52.ReadOnly = true;
            this.textBox52.Size = new System.Drawing.Size(222, 26);
            this.textBox52.TabIndex = 7;
            // 
            // comboBox41
            // 
            this.comboBox41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox41.FormattingEnabled = true;
            this.comboBox41.Items.AddRange(new object[] {
            "0.00",
            "10.00",
            "20.00",
            "50.00",
            "100.00",
            "200.00",
            "500.00",
            "1000.00"});
            this.comboBox41.Location = new System.Drawing.Point(159, 211);
            this.comboBox41.Name = "comboBox41";
            this.comboBox41.Size = new System.Drawing.Size(222, 24);
            this.comboBox41.TabIndex = 4;
            // 
            // textBox51
            // 
            this.textBox51.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.textBox51.Location = new System.Drawing.Point(159, 299);
            this.textBox51.Name = "textBox51";
            this.textBox51.ReadOnly = true;
            this.textBox51.Size = new System.Drawing.Size(222, 26);
            this.textBox51.TabIndex = 7;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label55.Location = new System.Drawing.Point(46, 212);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(93, 16);
            this.label55.TabIndex = 3;
            this.label55.Text = "充值金额：";
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label42.ForeColor = System.Drawing.Color.Fuchsia;
            this.label42.Location = new System.Drawing.Point(156, 55);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(258, 18);
            this.label42.TabIndex = 6;
            this.label42.Text = "1";
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label44.ForeColor = System.Drawing.Color.Fuchsia;
            this.label44.Location = new System.Drawing.Point(156, 85);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(258, 18);
            this.label44.TabIndex = 6;
            this.label44.Text = "2";
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label46.Location = new System.Drawing.Point(156, 115);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(258, 18);
            this.label46.TabIndex = 6;
            this.label46.Text = "3";
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label50.ForeColor = System.Drawing.Color.Red;
            this.label50.Location = new System.Drawing.Point(156, 175);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(258, 18);
            this.label50.TabIndex = 6;
            this.label50.Text = "5";
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label48.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label48.Location = new System.Drawing.Point(156, 145);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(258, 18);
            this.label48.TabIndex = 6;
            this.label48.Text = "4";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label43.Location = new System.Drawing.Point(29, 88);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(110, 16);
            this.label43.TabIndex = 5;
            this.label43.Text = "地铁进站口：";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label49.Location = new System.Drawing.Point(46, 181);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(93, 16);
            this.label49.TabIndex = 5;
            this.label49.Text = "进出状态：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label47.Location = new System.Drawing.Point(29, 150);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(110, 16);
            this.label47.TabIndex = 5;
            this.label47.Text = "地铁出站口：";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label45.Location = new System.Drawing.Point(46, 119);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(93, 16);
            this.label45.TabIndex = 5;
            this.label45.Text = "出站日期：";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label40.Location = new System.Drawing.Point(44, 26);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(95, 16);
            this.label40.TabIndex = 5;
            this.label40.Text = "卡    号：";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label41.Location = new System.Drawing.Point(46, 57);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(93, 16);
            this.label41.TabIndex = 5;
            this.label41.Text = "进站日期：";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label54.Location = new System.Drawing.Point(29, 305);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(110, 16);
            this.label54.TabIndex = 2;
            this.label54.Text = "扣款后金额：";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label51.Location = new System.Drawing.Point(387, 215);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(25, 16);
            this.label51.TabIndex = 1;
            this.label51.Text = "元";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label56.Location = new System.Drawing.Point(387, 243);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(25, 16);
            this.label56.TabIndex = 1;
            this.label56.Text = "元";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label57.Location = new System.Drawing.Point(387, 274);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(25, 16);
            this.label57.TabIndex = 1;
            this.label57.Text = "元";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label58.Location = new System.Drawing.Point(387, 304);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(25, 16);
            this.label58.TabIndex = 1;
            this.label58.Text = "元";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1022, 747);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.MaximumSize = new System.Drawing.Size(1024, 800);
            this.MinimumSize = new System.Drawing.Size(1022, 726);
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "闸机控制程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.ListBox listBox1;
        private System.IO.Ports.SerialPort serialPort3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ComboBox comboBox41;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label59;
    }
}