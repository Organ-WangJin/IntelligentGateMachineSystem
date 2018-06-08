
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace WFTest
{
    public partial class FrmMain : System.Windows.Forms.Form
    {
        #region dll
        [DllImport("dcrf32.dll")]
        public static extern int dc_init(Int16 port, Int32 baud);  //初试化
        [DllImport("dcrf32.dll")]
        public static extern short dc_exit(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_beep(int icdev, ushort misc);
        [DllImport("dcrf32.dll")]
        public static extern short dc_reset(int icdev, uint sec);
        [DllImport("dcrf32.dll")]
        public static extern short dc_config_card(int icdev, byte cardType);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card(int icdev, byte model, ref ulong snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_double(int icdev, byte model, [Out] byte[] snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_double_hex(int icdev, byte model, [Out]char[] snr);
        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_reset(int icdev, ref byte rlen, [Out] byte[] recvbuff);
        [DllImport("dcrf32.dll")]
        public static extern short dc_pro_command(int icdev, byte slen, byte[] sendbuff, ref byte rlen, [Out]byte[] recvbuff, byte timeout);
        [DllImport("dcrf32.dll")]
        public static extern short dc_card_b(int icdev, [Out] byte[] atqb);
        [DllImport("dcrf32.dll")]
        public static extern short dc_setcpu(int icdev, byte address);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpureset(int icdev, ref byte rlen, byte[] rdata);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapdu(int icdev, byte slen, byte[] sendbuff, ref byte rlen, [Out]byte[] recvbuff);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapduInt(int icdev, byte slen, byte[] sendbuffer, ref byte rlen, [Out]byte[] databuffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_cpuapduInt_hex(int icdev, byte slen, byte[] sendbuffer, ref byte rlen, [Out]byte[] databuffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpincount_4442(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4442(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4442(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4442(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpin_4442(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_changepin_4442(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpincount_4428(int icdev);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_4428(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_4428(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_verifypin_4428(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_readpin_4428(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern short dc_changepin_4428(int icdev, byte[] password);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication(int icdev, int _Mode, int _SecNr);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass(int icdev, int _Mode, int _SecNr, byte[] nkey);
        [DllImport("dcrf32.dll")]
        public static extern int dc_authentication_pass_hex(int icdev, int _Mode, int _SecNr, string nkey);
        [DllImport("dcrf32.dll")]
        public static extern int dc_load_key(int icdev, int mode, int secnr, byte[] nkey);  //密码装载到读写模块中
        [DllImport("dcrf32.dll")]
        public static extern int dc_write(int icdev, int adr, [In] byte[] sdata);  //向卡中写入数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_write_hex(int icdev, int adr, [In] string sdata);  //向卡中写入数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_read(int icdev, int adr, [Out] byte[] sdata);  //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_read_hex(int icdev, int adr, [Out] byte[] sdata);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_24c(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_24c(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_read_24c64(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern short dc_write_24c64(int icdev, Int16 offset, Int16 lenth, byte[] buffer);
        [DllImport("dcrf32.dll")]
        public static extern int dc_readval(int icdev, int adr, [Out] byte[] value); //从卡中读数据
        [DllImport("dcrf32.dll")]
        public static extern int dc_increment(int icdev, int adr, [In] Int32 value);  //块加值
        [DllImport("dcrf32.dll")]
        public static extern int dc_decrement(int icdev, int adr, [In] Int32 value);  //块减值
        #endregion

        /***********************************************----------------------------------------------**********************************************/
        public FrmMain()
        {
            InitializeComponent();
        }

        //public string SN;
        //public string Key;
        //public string PartA;
        //public string PartB;
        public delegate void getstring(string dataRe);    //定义委托         
        //getstring getmystring;                          //定义委托变量 
        CardRecovery cardrecovery = new CardRecovery();
        Byte[] DataPage = new Byte[10];
        byte[] receivebuffer;
        byte[] sendbuffer;
        int readcardflag;
        string CardIdNum;                       //本次读取到的卡号
        string cardstr;                         //读取系统所以卡
        int icdev1;                             //读写器设备描述符 icdev1: 出闸机
        int icdev2;                             //读写器设备描述符 icdev1: 出闸机, icdev2:进闸机
        bool CardRecoveryflag;                  //卡接收标志位
        Thread thread1;
        double invaluebefore;                    //充值或扣款前金额
        double invalueafter;                     //充值或扣款后金额
        double incrementvalue;                   //充值金额
        double decrementvalue;                   //减值金额
        string cardbackblockvaluestr;               //备份区金额
        string cardblockvaluestr;                   //卡内金额  
        bool GetYRecovryReaderProessFlag;

        string strenter3 = "7f400120ffff";         //收卡
        string strenter4 = "7f400121ffff";         //退卡
        string str1 = "ATOP1\r\n";                 //进闸机
        string str2 = "ATOP2\r\n";                 //出闸机
        DialogResult dialogresult;
        CalendarDateTime getcurrentdatetime;       //获取当前日期和站点
        CalendarDateTime getcardentredatetime;     //获取卡片进站日期和站点
        CalendarDateTime getcardexitdatetime;      //获取卡片出站日期和站点
        string currentdatetimestr;                 //当前时间（YYYMDDHHMMSS——> 占12位）
        string setinitstation = "FFF";             //设置注册使用的站点

        string getentrecurrentstation;             //进站时的车站编号（XXX——> 占3位）
        string getexitcurrentstation;              //出站时的车站编号（XXX——> 占3位）
        string setentreandexitflag;                //进出站标志位置（01:出站；10： 进站;占2位）
        string setcurrentdatetimeandstationenter;  //进站时间和站点（——> 占2位）
        string setcurrentdatetimeandstationexit;   //出站时间和站点（——> 占2位）
        string getcardenterandexitmessage;
        string getentreandexitflag;
        bool entreandexitenableflag;
        bool cardblockcheckAndcopyflag;           //比较标志位



        private void FrmMain_Load(object sender, EventArgs e)
        {
            CardRecoveryflag = false;
            GetYRecovryReaderProessFlag = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            entreandexitenableflag = false;
            radioButton5.Checked = true;
            groupBox22.Hide();
            for (int i = 0; i < 13; i++)
            {
                comboBox2.Items.Add(StationRecognition(i.ToString()));
                comboBox3.Items.Add(StationRecognition(i.ToString()));
            }
            comboBox41.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            comboBox41.Enabled = false;
            timer3.Enabled = true;
        }


        private void button31_Click(object sender, EventArgs e)
        {
            if (button31.Text == "闸机程序运行")
            {
                comboBox41.Enabled = false;
                CardRecoveryflag = true;
                button31.Text = "闸机程序停止";
                listBox1.Items.Add(DateTime.Now.ToString() + "  闸机程序运行 !!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                //listBox1.Items.Add(DateTime.Now.ToString() + "  请刷卡或二维码通过闸机!!!");
                listBox1.Items.Add(DateTime.Now.ToString() + "  请刷卡通过闸机!!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                button32.Enabled = false;
                button33.Enabled = true;
                button34.Enabled = true;
                timer1.Enabled = true;                  //不带收卡机的读写器
                timer2.Enabled = true;                  //用于收卡器
            }
            else
            {
                CardRecoveryflag = false;
                button31.Text = "闸机程序运行";
                timer2.Enabled = false;
                timer1.Enabled = false;
                comboBox41.Enabled = true;
                listBox1.Items.Add(DateTime.Now.ToString() + "  闸机程序停止 !!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                button32.Enabled = true;
                button33.Enabled = false;
                button34.Enabled = true;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Card_Init();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            CardRecoveryflag = false;
            timer2.Enabled = false;
            timer1.Enabled = false;
            dc_exit(icdev1);
            dc_exit(icdev2);
            this.Close();
            this.Dispose();
            Application.Exit();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CardRecoveryflag)
            {
                timer1.Enabled = false;
                GetNRecovryReaderProess();
            }
            else
            {
                timer1.Enabled = false;
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (CardRecoveryflag)
            {
                timer2.Enabled = false;
                if (GetYRecovryReaderProessFlag)
                {
                    GetYRecovryReaderProessFlag = false;
                    GetYRecovryReaderProess();
                    timer2.Enabled = true;
                }
                string strenter1 = "7f400107ffff";   //查询卡的状态
                serialPort3_DataSend(strenter1);
            }
            else
            {
                timer2.Enabled = false;
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            listBox1.Items.Add(DateTime.Now.ToString() + "  初始化设备!!!");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            /*
             *      //控件                 //计划端口                   //当前端口    
             * 根据实际连接的COMx       //控制读卡器设备出闸机comx         COM3
             * 根据实际连接的COMx       //控制读卡器设备进闸机comx         COM4
             */
            //初始化读卡器装置
            thread1 = new Thread(new ThreadStart(Port_init));
            icdev1 = dc_init(2, 115200);      //设置出站闸机读卡器端口为COM3
            if (icdev1 < 0)
            {
                listBox1.Items.Add(DateTime.Now.ToString() + "  请检查出闸机读卡器是否连接!!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                button34.Enabled = true;
                return;
            }
            else
            {
                listBox1.Items.Add(DateTime.Now.ToString() + "  出闸机读卡器已连接!!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                dc_beep(icdev1, 10);

                icdev2 = dc_init(3, 115200);       //设置进站闸机读卡器端口为COM4
                if (icdev2 < 0)
                {
                    listBox1.Items.Add(DateTime.Now.ToString() + "  请检查进闸机读卡器是否连接!!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    button34.Enabled = true;
                    return;
                }
                else
                {
                    listBox1.Items.Add(DateTime.Now.ToString() + "  进闸机读卡器已连接!!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    dc_beep(icdev2, 10);
                    radioButton5.Enabled = true;
                    radioButton6.Enabled = true;
                    comboBox41.Enabled = true;
                    button31.Enabled = true;
                    button32.Enabled = true;
                    button33.Enabled = false;
                    button34.Enabled = true;
                }
            }
        }
        public void Port_init()
        {
            /*  
             *  //控件                     //计划端口                  //当前端口    
             * serialPort1              //控制机旋转装置com2               com2
             * serialPort2              //控制二维码设备com1               com1
             * serialPort3              //控制收卡机设备comx               COM7           
             */

            //初始化闸机旋转装置
            //serialPort1.Close();
            //serialPort1.PortName = "COM2";  //设置闸机旋转装置端口
            //serialPort1.BaudRate = 115200;
            //serialPort1.Open();

            ////初始化二维码扫描装置
            //serialPort2.Close();
            //serialPort2.PortName = "COM5";  //设置二维码扫描装置端口
            //serialPort2.BaudRate = 115200;
            //serialPort2.Open();
            //serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);//添加数据接收事件

            //初始化收卡机
            serialPort3.Close();
            serialPort3.PortName = "COM7";  //设置收卡机端口为COM7
            serialPort3.BaudRate = 9600;
            serialPort3.Open();
            serialPort3.DataReceived += new SerialDataReceivedEventHandler(serialPort3_DataReceived);//添加数据接收事件
        }

        //void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)   //二维码接收
        //{
        //    try
        //    {
        //        string mystring = serialPort2.ReadExisting();
        //        getmystring = new getstring(DoUpdate);
        //        Invoke(getmystring, mystring);
        //    }
        //    catch (Exception EX)
        //    {
        //        MessageBox.Show(EX.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //}


        public void serialPort3_DataSend(string strenter)
        {
            int Ssetinfo = 1;
            int Esetinfo = 1;
            sendbuffer = cardrecovery.strToHexBytes(strenter);
            Esetinfo = cardrecovery.CheckDataLength(sendbuffer[2]);
            DataPage = cardrecovery.CRC16(sendbuffer, Ssetinfo, Esetinfo);
            string str = cardrecovery.byteToHexStr(DataPage);
            //listBox1.Items.Add(DateTime.Now.ToString() + "  "+ str);
            //listBox1.SelectedIndex = listBox1.Items.Count - 1;
            if (serialPort3.IsOpen == false)
            {
                serialPort3.Open();
            }
            serialPort3.Write(DataPage, 0, DataPage.Length);
        }

        private void serialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int Ssetinfo = 1;
            int Esetinfo = 1;
            int readCount = 0;
            try
            {
                System.Threading.Thread.Sleep(100);
                int bytes = serialPort3.BytesToRead;
                receivebuffer = new byte[bytes];
                readCount = serialPort3.Read(receivebuffer, 0, bytes);
                string receivestr = cardrecovery.byteToHexStr(receivebuffer);
                if (readCount < 5)
                {
                    return;
                }
                else
                {
                    listBox1.Invoke(new MethodInvoker(delegate {
                        //listBox1.Items.Add(receivestr);
                        //listBox1.SelectedIndex = listBox1.Items.Count - 1; 
                    }));
                    Esetinfo = cardrecovery.CheckDataLength(receivebuffer[2]);
                    DataPage = cardrecovery.CRC16(receivebuffer, Ssetinfo, Esetinfo);
                    if (DataPage[Esetinfo + 1] == receivebuffer[Esetinfo + 1] && DataPage[Esetinfo + 2] == receivebuffer[Esetinfo + 2])
                    {
                        CheckReceiveStatus(receivebuffer[3]);
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        public void CheckReceiveStatus(byte receivebyte)
        {
            byte[] recv_buffer = new byte[128];
            switch (receivebyte)
            {
                //上位机发送查询命令0x07后响应
                case (int)QueryCommand_Response.RET_GetCard:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡机中有卡插入，并且在进卡!!!");
                        timer2.Enabled = true;
                        timer1.Enabled = false;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_WaitCmd:
                    listBox1.Invoke(new MethodInvoker(delegate
                    {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡机在等待上位机命令!!!");
                        GetYRecovryReaderProessFlag = true;
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_Receiving:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡机正在收卡!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_Received:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡已回收!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_Exiting:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡机正在退卡!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_Exited:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡已退出!!!");
                        //System.Threading.Thread.Sleep(3000);  //3s收卡
                        //string strenter3 = "7f400120ffff";
                        //int Ssetinfo = 1;
                        //int Esetinfo = 1;
                        //sendbuffer = cardrecovery.strToHexBytes(strenter3);
                        //Esetinfo = cardrecovery.CheckDataLength(sendbuffer[2]);
                        //DataPage = cardrecovery.CRC16(sendbuffer, Ssetinfo, Esetinfo);
                        //string str = cardrecovery.byteToHexStr(DataPage);
                        ////listBox1.Items.Add(str);
                        ////listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        //serialPort3.Write(DataPage, 0, DataPage.Length);
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_EntryJam:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡在收卡时超时或阻塞!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_ExitJam:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡在退卡时超时或阻塞!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)QueryCommand_Response.RET_RDY:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        //listBox1.Items.Add(DateTime.Now.ToString() + "  卡机中没有卡，等待插入卡!!!");
                        timer2.Enabled = true;
                        timer1.Enabled = true;
                    }));
                    break;


                //3.收卡:0x20  4.退卡:0x21  5.进卡:0x25  6.允许卡机工作:0x0A  7.禁止卡机工作:0x09  --------卡片控制响应
                case (int)CardCommand_Response.AckUnRdy:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  收卡机没有准备好!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)CardCommand_Response.AckBusy:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  收卡机正忙，不能接收命令!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)CardCommand_Response.AckUndo:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  命令不能被执行!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)CardCommand_Response.AckCmdRecv:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  命令已接收，并可以执行!!!");
                        GetProessResult();
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)CardCommand_Response.AckDisable:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  收卡机被禁止!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                case (int)CardCommand_Response.AckEnable:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡机工作允许!!!");
                        timer2.Enabled = true;
                    }));
                    break;
                //未知异常    
                default:
                    listBox1.Invoke(new MethodInvoker(delegate {
                        listBox1.Items.Add(DateTime.Now.ToString() + "  未知错误!!!");
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                    }));
                    break;
            }
            listBox1.Invoke(new MethodInvoker(delegate {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }));

        }


        public void Card_Init()
        {
            int st1, st2, st3;
            char[] ssnr = new char[128];
            byte[] recv_buff = new byte[4];
            byte[] read_buff = new byte[32];
            string value;
            invaluebefore = 0;
            invalueafter = 0;
            incrementvalue = 0;
            label42.Text = "";
            label44.Text = "";
            label46.Text = "";
            label48.Text = "";
            label50.Text = "";
            label59.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            entreandexitenableflag = false;
            //对卡片进行初始化
            st1 = dc_config_card(icdev2, 0x41); //读取M1卡ID
            st2 = dc_card_double_hex(icdev2, 0, ssnr);
            if (st1 == 0 && st2 == 0)
            {
                dc_beep(icdev2, 10);
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                label59.Text = CardIdNum;
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                cardstr = File.ReadAllText(@".\Test\Card.txt");
                ////对卡片权限进行操作
                //string str = File.ReadAllText(@".\Test\Card.txt");
                //File.WriteAllText(@".\Test\CardNew.txt", str);
                //File.WriteAllText(@".\Test\CardOld.txt", "//test\r\n");
                //File.AppendAllText(@".\Test\CardNew.txt", str);
                //listBox1.Items.Add(DateTime.Now.ToString() + "  初始化卡片完成!!!");
                //listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (cardstr.Contains(CardIdNum) == false)  //卡号存在数据库中
                {
                    dialogresult = MessageBox.Show("此卡未注册，是否注册卡片 !!!", "卡片注册提示", MessageBoxButtons.OKCancel);
                    if (dialogresult == DialogResult.OK)//如果点击“确定”按钮
                    {
                        setcurrentdatetimeandstationenter = GetCurrentDataTime() + setinitstation;  //进站时间
                        setcurrentdatetimeandstationexit = GetCurrentDataTime() + setinitstation;   //出站时间
                        setentreandexitflag = "01";                                             //进出站标志位（01：出站，10：进站）
                        st3 = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                        if (st3 == 0)            //密钥认证
                        {                                                             //读余额
                            st1 = dc_write_hex(icdev2, 12, "00000000FFFFFFFF0000000011EE11EE");
                            st2 = dc_write_hex(icdev2, 13, "00000000FFFFFFFF0000000012ED12ED");
                            st3 = dc_write_hex(icdev2, 14, setcurrentdatetimeandstationenter + setcurrentdatetimeandstationexit + setentreandexitflag);   //初始信息（YYYMDDHHMMSSsssYYYMDDHHMMSSsssXX）
                            if (st1 == 0 && st2 == 0 && st3 == 0)             //注册卡片成功
                            {
                                readcardflag = 22;
                                MessageBox.Show("注册卡片成功 !!!", "提示信息", MessageBoxButtons.OK);
                                File.AppendAllText(@".\Test\Card.txt", CardIdNum + "\r\n");
                                GetProessResult();
                                dc_beep(icdev2, 10);
                                return;
                            }
                            else
                            {
                                readcardflag = 18;    //注册卡片失败
                                MessageBox.Show("注册卡片失败 !!!", "提示信息", MessageBoxButtons.OK);
                                GetProessResult();
                                dc_beep(icdev2, 10);
                                return;
                            }
                        }
                        else
                        {
                            readcardflag = 7;   //密钥验证失败
                            MessageBox.Show("密钥验证失败 !!!", "提示信息", MessageBoxButtons.OK);
                            GetProessResult();
                            dc_beep(icdev2, 10);
                            return;
                        }
                    }
                    else  //如果点击“取消”按钮
                    {
                        readcardflag = 19;   //取消注册
                        MessageBox.Show("取消注册卡片 !!!", "提示信息", MessageBoxButtons.OK);
                        GetProessResult();
                        dc_beep(icdev2, 10);
                        return;
                    }
                }
                else
                {
                    dialogresult = MessageBox.Show("此卡已经注册,是否进行充值 !!!", "卡片充值提示:    (充值金额为大于0的整数)", MessageBoxButtons.YesNo);
                    if (dialogresult == DialogResult.Yes)
                    {
                        //读取卡中金额,并进行验证
                        st1 = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                        if (st1 == 0)            //密钥认证
                        {
                            //读取卡片信息
                            st1 = dc_read_hex(icdev2, 14, read_buff);
                            if (st1 == 0)
                            {
                                getcardenterandexitmessage = GetCardEnterAndExitMessage(read_buff);
                                recv_buff = new byte[4];
                                cardblockcheckAndcopyflag = CardBlockCheckAndCopy(icdev2, true, true, true);
                                if (cardblockcheckAndcopyflag)
                                {
                                    st3 = dc_readval(icdev2, 12, recv_buff);  //读取卡内金额
                                    if (st3 == 0)     //读充值前卡内金额
                                    {
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  读充值前卡内余额成功!!!");
                                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                        invaluebefore = (recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                        value = ChangeValue((double)invaluebefore / 10);
                                        textBox53.Text = value;
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  充值前卡内余额： " + value + "元");
                                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                        if (double.Parse(ChangeValue(double.Parse(comboBox41.Text))) > 0)
                                        {
                                            //充值
                                            dialogresult = MessageBox.Show("充值金额为： " + comboBox41.Text + " 元,请确认是否充值!", "卡片充值确认提示", MessageBoxButtons.OKCancel);
                                            if (dialogresult == DialogResult.OK)//如果点击“确定”按钮
                                            {
                                                incrementvalue = 0.00;
                                                incrementvalue = double.Parse(comboBox41.Text) * 10;
                                                listBox1.Items.Add(DateTime.Now.ToString() + "  充值金额为：" + ChangeValue(double.Parse(comboBox41.Text)) + "元");
                                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                                if (Double.Parse(value) + Double.Parse(incrementvalue.ToString()) / 10 <= 6553.50)
                                                {
                                                    st1 = dc_increment(icdev2, 12, Int32.Parse(incrementvalue.ToString()));  //充值
                                                    if (st1 == 0 )
                                                    {
                                                        //读充值后余额
                                                        recv_buff = new byte[4];
                                                        st1 = dc_readval(icdev2, 12, recv_buff);
                                                        if (st1 == 0)
                                                        {
                                                            invalueafter = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                                            value = ChangeValue((double)invalueafter / 10);
                                                            textBox51.Text = value.ToString();
                                                            listBox1.Items.Add(DateTime.Now.ToString() + "  充值后卡内余额： " + value.ToString() + "元");
                                                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                                            //进行判断是否充值成功有效
                                                            if (invalueafter == invaluebefore + incrementvalue)
                                                            {
                                                                CardBlockCheckAndCopy(icdev2,true,false,false);  //比较并赋值块12->块13
                                                                MessageBox.Show("充值成功 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                                readcardflag = 27;    //充值成功       
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("充值失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                                readcardflag = 15;  //充值失败
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("读充值后卡内金额失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                            readcardflag = 14;  //读充值后卡内金额失败
                                                        }
                                                    }
                                                    else
                                                    {
                                                        CardBlockCheckAndCopy(icdev2, true, true,true);  //比较并赋值(true);
                                                        MessageBox.Show("充值指令返回失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                        readcardflag = 13;  //充值指令返回失败
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("充值金额已经超限，请消费后再进行充值!!!", "充值结果提示", MessageBoxButtons.OK);
                                                    readcardflag = 12; //充值金额已经超限，请消费后再进行充值!!!
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("取消充值 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                readcardflag = 20;    //取消充值
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("充值失败，充值金额必须大于 0 元 !!!", "提示信息", MessageBoxButtons.OK);
                                            readcardflag = 21;    //充值失败，充值金额必须大于 0 元
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("读充值前卡内余额失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                                        readcardflag = 11;    // 读充值前卡内余额失败   
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("卡内金额与备份金额相互交换失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                                    readcardflag = 28;    // 卡内金额与备份金额相互交换失败  
                                }
                            }
                            else
                            {
                                MessageBox.Show("已经进站，不允许充值，需出站后才进行充值 !!!", "充值结果提示", MessageBoxButtons.OK);
                                readcardflag = 23;      //已经进站，不允许充值，需出站后才进行充值

                            }
                        }
                        else
                        {
                            MessageBox.Show("密钥验证失败 !!!", "充值结果提示", MessageBoxButtons.OK);
                            readcardflag = 7;    //密钥验证失败
                        }
                    }
                    else
                    {
                        MessageBox.Show("取消充值 !!!", "充值结果提示", MessageBoxButtons.OK);
                        readcardflag = 20;    //取消充值
                    }
                }
            }
            else
            {
                readcardflag = 17; //未检测到卡
            }
            GetProessResult();
            dc_beep(icdev2, 10);
        }

        public void GetYRecovryReaderProess()
        {
            int Ssetinfo = 1;
            int Esetinfo = 1;
            int st;
            char[] ssnr = new char[128];
            byte[] read_buff = new byte[32];
            CardIdNum = "";
            getentrecurrentstation = "";
            getexitcurrentstation = "";
            setcurrentdatetimeandstationenter = "";
            setcurrentdatetimeandstationexit = "";
            getcardenterandexitmessage = "";
            getentrecurrentstation = "";
            getexitcurrentstation = "";
            label42.Text = "";
            label44.Text = "";
            label46.Text = "";
            label48.Text = "";
            label50.Text = "";
            label59.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            invaluebefore = 0;
            invalueafter = 0;
            decrementvalue = 0;
            entreandexitenableflag = false;
            cardstr = File.ReadAllText(@".\Test\Card.txt");
            st = dc_config_card(icdev1, 0x41); //读取M1卡ID
            st = dc_card_double_hex(icdev1, 0, ssnr);
            if (st == 0)
            {
                dc_beep(icdev1, 10);
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                label59.Text = CardIdNum;
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (cardstr.Contains(CardIdNum))  //卡号存在数据库中
                {
                    //读取卡中金额,并进行验证
                    st = dc_authentication_pass_hex(icdev1, 0, 3, "ffffffffffff");  //第3扇区第一块
                    if (st == 0)
                    {
                        bool flag = CardBlockCheckAndCopy(icdev1,false,true,false);  //比较金额是否一致
                        if (flag)
                        {
                            st = dc_read_hex(icdev1, 14, read_buff);
                            if (st == 0)      //读卡内进出站信息
                            {
                                getcardenterandexitmessage = GetCardEnterAndExitMessage(read_buff);
                                if (!entreandexitenableflag)   //判断卡是否有进站信息
                                {
                                    byte[] recv_buff = new byte[128];
                                    st = dc_readval(icdev1, 12, recv_buff);
                                    st = dc_readval(icdev1, 13, recv_buff);
                                    if (st == 0) //读扣款前卡内余额
                                    {
                                        invaluebefore = (recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                        string value = ChangeValue(invaluebefore / 10);
                                        textBox53.Text = value;
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  扣款前卡内余额:" + value + "元");
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  此卡出站口:" + label44.Text + "地铁站");
                                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                        //当前车站（出站点） - （进站点）后需要扣款项 
                                        getexitcurrentstation = cardrecovery.OctToHex3BitStr(comboBox3.SelectedIndex);   //int 类型转为hex且为三位
                                        getentrecurrentstation = getcardenterandexitmessage.Substring(12, 3);  //进站点
                                        double getexitdecremententervalue = CalculationExitDecrementEnterValue(getexitcurrentstation, getentrecurrentstation);
                                        textBox52.Text = ChangeValue(getexitdecremententervalue);
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  扣款金额:" + getexitdecremententervalue + "元");
                                        if (double.Parse(value) > 0.00 && double.Parse(value) >= getexitdecremententervalue)
                                        {
                                            //减值
                                            decrementvalue = getexitdecremententervalue * 10;
                                            st = dc_decrement(icdev1, 12, Int32.Parse(decrementvalue.ToString()));
                                            if (st == 0)
                                            {
                                                //读扣款后卡内余额
                                                recv_buff = new byte[128];
                                                st = dc_readval(icdev1, 12, recv_buff);   //
                                                if (st == 0)
                                                {
                                                    invalueafter = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                                    value = ChangeValue(invalueafter / 10);
                                                    textBox51.Text = value;
                                                    listBox1.Items.Add(DateTime.Now.ToString() + "  扣款后卡内余额:" + value + "元");
                                                    if (invalueafter == invaluebefore - decrementvalue)
                                                    {
                                                        CardBlockCheckAndCopy(icdev1,true, false ,false);  //比较
                                                        listBox1.Items.Add(DateTime.Now.ToString() + "  扣款成功!!!");
                                                        setcurrentdatetimeandstationenter = getcardenterandexitmessage.Substring(0, 15);          //进站时间和地点                                                   
                                                        setcurrentdatetimeandstationexit = GetCurrentDataTime() + getexitcurrentstation;          //出站时间和站点

                                                        setentreandexitflag = "01";
                                                        st = dc_write_hex(icdev1, 14, setcurrentdatetimeandstationenter + setcurrentdatetimeandstationexit + setentreandexitflag);
                                                        if (st == 0)  //写入信息成功
                                                        {
                                                            st = dc_read_hex(icdev1, 14, read_buff);
                                                            if (st == 0)      //读卡内进出站信息
                                                            {
                                                                getcardenterandexitmessage = GetCardEnterAndExitMessage(read_buff);
                                                            }
                                                            sendbuffer = cardrecovery.strToHexBytes(strenter3);  //收卡
                                                            readcardflag = 1;      //出站
                                                        }
                                                        else
                                                        {
                                                            sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                                            readcardflag = 25; //写入进出站信息失败
                                                        }
                                                    }
                                                    else  //减值失败
                                                    {
                                                        CardBlockCheckAndCopy(icdev1, true, true,false);  //比较并恢复金额
                                                        sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                                        readcardflag = 16;
                                                    }
                                                }
                                                else//读扣款后卡内余额错误
                                                {
                                                    CardBlockCheckAndCopy(icdev1, true, true,false);  //比较并恢复金额
                                                    sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                                    readcardflag = 3;
                                                }
                                            }
                                            else//减值指令返回失败                                                                                
                                            {
                                                CardBlockCheckAndCopy(icdev1, true, true,false);  //比较并恢复金额
                                                sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                                readcardflag = 4;
                                            }
                                        }
                                        else//余额不足 
                                        {
                                            sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                            readcardflag = 5;
                                        }
                                    }
                                    else //读扣款前卡内余额
                                    {
                                        sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                        readcardflag = 6;
                                    }
                                }
                                else
                                {
                                    sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                    readcardflag = 9;   //此卡没有进站,不能出站

                                }
                            }
                            else
                            {
                                sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                readcardflag = 24;    //读卡内进出站信息失败
                            }
                        }
                        else
                        {
                            sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                            readcardflag = 26;   //读备份区金额和卡内金额指令失败
                        }
                    }
                    else
                    {
                        readcardflag = 7;  //密钥认证失败
                        sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                    }
                }
                else
                {
                    readcardflag = 8;  //此卡未注册
                    sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                }
            }
            else
            {
                readcardflag = 10;  //收卡机未检测到卡
                sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
            }
            Esetinfo = cardrecovery.CheckDataLength(sendbuffer[2]);
            DataPage = cardrecovery.CRC16(sendbuffer, Ssetinfo, Esetinfo);
            //string str = cardrecovery.byteToHexStr(DataPage);     //发送的数据转换为字符串
            //listBox1.Items.Add(str);     
            serialPort3.Write(DataPage, 0, DataPage.Length);
            //GetProessResult();

        }


        public void GetNRecovryReaderProess()
        {
            int st;
            char[] ssnr = new char[128];
            byte[] read_buff = new byte[128];
            CardIdNum = "";
            getentreandexitflag = "";
            setcurrentdatetimeandstationenter = "";
            setcurrentdatetimeandstationexit = "";
            getentrecurrentstation = "";
            getexitcurrentstation = "";
            label42.Text = "";
            label44.Text = "";
            label46.Text = "";
            label48.Text = "";
            label50.Text = "";
            label59.Text = "";
            textBox51.Text = "";
            textBox52.Text = "";
            textBox53.Text = "";
            cardstr = File.ReadAllText(@".\Test\Card.txt");
            st = dc_config_card(icdev2, 0x41);         //读取M1卡ID
            st = dc_card_double_hex(icdev2, 0, ssnr);  //寻卡操作
            if (st == 0)
            {
                dc_beep(icdev2, 10);
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                label59.Text = CardIdNum;
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (cardstr.Contains(CardIdNum))  //卡号存在数据库中
                {
                    //读取卡中金额,并进行验证
                    st = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                    if (st == 0)
                    {
                        bool flag = CardBlockCheckAndCopy(icdev2, false, true, false);  //比较并赋值
                        if (flag)
                        {
                            //相等
                            byte[] recv_buff = new byte[128];
                            st = dc_readval(icdev2, 12, recv_buff);
                            if (st == 0) //读卡内余额
                            {
                                double invalue = (recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                string value = ChangeValue(invalue / 10);
                                listBox1.Items.Add(DateTime.Now.ToString() + "  卡内余额:" + value + "元");
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                textBox53.Text = value;
                                if (cardstr.Contains(CardIdNum))  //卡号存在数据库中
                                {
                                    //读卡内进出站信息标志位
                                    st = dc_read_hex(icdev2, 14, read_buff);
                                    if (st == 0)  //读卡内进出站信息成功
                                    {
                                        getcardenterandexitmessage = GetCardEnterAndExitMessage(read_buff);  //读取进出站信息返回为10进制数                             
                                        if (entreandexitenableflag)
                                        {
                                            //确认能进站
                                            listBox1.Items.Add(DateTime.Now.ToString() + "  进站口:" + comboBox2.Text + "地铁站");
                                            listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                            if (double.Parse(value) > 0.00)     //&& value >= Double.Parse(comboBox1.Text) )
                                            {
                                                getentrecurrentstation = cardrecovery.OctToHex3BitStr(comboBox2.SelectedIndex);
                                                setcurrentdatetimeandstationenter = GetCurrentDataTime() + getentrecurrentstation;               //进站时间和站点
                                                setcurrentdatetimeandstationexit = getcardenterandexitmessage.Substring(15, 15);
                                                setentreandexitflag = "10";
                                                st = dc_write_hex(icdev2, 14, setcurrentdatetimeandstationenter + setcurrentdatetimeandstationexit + setentreandexitflag);
                                                if (st == 0)
                                                {
                                                    st = dc_read_hex(icdev2, 14, read_buff);
                                                    if (st == 0)      //读卡内进出站信息
                                                    {
                                                        getcardenterandexitmessage = GetCardEnterAndExitMessage(read_buff);
                                                    }
                                                    readcardflag = 2;    //进站
                                                }
                                                else
                                                {
                                                    readcardflag = 25;  //进站日期和进站口写入失败
                                                }
                                            }
                                            else
                                            {
                                                readcardflag = 5;  //卡内余额不足,请充值
                                            }
                                        }
                                        else
                                        {
                                            readcardflag = 23; //卡已经进站
                                        }
                                    }
                                    else
                                    {
                                        readcardflag = 24; //读卡内进出站信息失败
                                    }
                                }
                                else
                                {
                                    readcardflag = 8;  //卡未注册或已进站
                                }
                            }
                            else
                            {
                                readcardflag = 6;  //读卡内余额失败!
                            }
                        }
                        else
                        {
                            readcardflag = 26; //备份区金额和卡内金额不一致
                        }
                    }
                    else
                    {
                        readcardflag = 7;  //密钥验证失败!
                    }
                }
                else
                {
                    readcardflag = 8;  //此卡未注册
                    sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                }
            }
            else
            {
                readcardflag = 17;  //寻卡失败，未检测到卡
            }
            GetProessResult();
        }


        public void GetProessResult()
        {
            switch (readcardflag)
            {
                case 1:
                    //serialPort1.WriteLine(str1);      // 控制进闸机指令
                    listBox1.Items.Add(DateTime.Now.ToString() + "  闸机门已经打开,请尽快通过 !!!");
                    break;
                case 2:
                    //serialPort1.WriteLine(str2);      // 控制出闸机指令
                    listBox1.Items.Add(DateTime.Now.ToString() + "  闸机门已经打开,请尽快通过 !!!");
                    break;
                case 3:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读扣款后余额失败 !!!");
                    break;
                case 4:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  减值指令返回失败 !!!");
                    break;
                case 5:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡内余额不足 !!!");
                    break;
                case 6:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读扣款前卡内余额失败 !!!");
                    break;
                case 7:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  密钥认证失败 !!!");
                    break;
                case 8:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  此卡未注册 !!!");
                    break;
                case 9:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  此卡无进站记录 !!!");
                    break;
                case 10:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  收卡机未检测到卡,请刷卡通过闸机 !!!");
                    break;
                case 11:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读充值前卡内余额失败 !!!");
                    break;
                case 12:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值金额已经超限 !!!");
                    break;
                case 13:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值指令返回失败 !!!");
                    break;
                case 14:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读充值后卡内金额失败 !!!");
                    break;
                case 15:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值失败 !!!");
                    break;
                case 16:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  减值失败 !!!");
                    break;
                case 17:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  未检测到卡,请刷卡通过闸机 !!!");
                    break;
                case 18:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  初始化卡片失败 !!!");
                    break;
                case 19:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  取消注册 !!!");
                    break;
                case 20:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  取消充值 !!!");
                    break;
                case 21:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值失败，充值金额必须大于 0 元 !!!");
                    break;
                case 22:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  注册成功 !!!");
                    break;
                case 23:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡已进站 !!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.Items.Add(DateTime.Now.ToString() + "  进站口:" + label44.Text + "地铁站");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.Items.Add(DateTime.Now.ToString() + "  进站时间:" + label42.Text);

                    break;
                case 24:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读卡内进出站信息失败 !!!");
                    break;
                case 25:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  进站日期和进站口写入失败 !!!");
                    break;
                case 26:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  读备份区金额和卡内金额指令失败 !!!");
                    break;
                case 27:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值成功 !!!");
                    break;
                case 28:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡内金额与备份金额相互交换失败 !!!");
                    break;
                default:
                    break;
            }
            readcardflag = 0;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        public string GetCurrentDataTime()   //获取当前时间
        {
            getcurrentdatetime.year = cardrecovery.strOctTostrHex(DateTime.Now.Year).Substring(5, 3);
            getcurrentdatetime.month = cardrecovery.strOctTostrHex(DateTime.Now.Month).Substring(7, 1);
            getcurrentdatetime.day = cardrecovery.strOctTostrHex(DateTime.Now.Day).Substring(6, 2); ;
            getcurrentdatetime.hour = cardrecovery.strOctTostrHex(DateTime.Now.Hour).Substring(6, 2);
            getcurrentdatetime.minute = cardrecovery.strOctTostrHex(DateTime.Now.Minute).Substring(6, 2);
            getcurrentdatetime.second = cardrecovery.strOctTostrHex(DateTime.Now.Second).Substring(6, 2);
            currentdatetimestr = getcurrentdatetime.year + getcurrentdatetime.month + getcurrentdatetime.day + getcurrentdatetime.hour + getcurrentdatetime.minute + getcurrentdatetime.second;
            return currentdatetimestr;
        }

        public string GetCardEnterAndExitMessage(byte[] buffer)   //获取卡片进出信息
        {
            //1. 将buff值转换为字符串；
            string readbuffstr = cardrecovery.OctToHexStr(buffer);
            //2. 获取进站日期和站点
            getcardentredatetime.year = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(0, 3)).ToString();
            getcardentredatetime.month = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(3, 1)).ToString();
            if (getcardentredatetime.month.Length < 2)
            {
                getcardentredatetime.month = "0" + getcardentredatetime.month;
            }
            getcardentredatetime.day = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(4, 2)).ToString();
            if (getcardentredatetime.day.Length < 2)
            {
                getcardentredatetime.day = "0" + getcardentredatetime.day;
            }
            getcardentredatetime.hour = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(6, 2)).ToString();
            if (getcardentredatetime.hour.Length < 2)
            {
                getcardentredatetime.hour = "0" + getcardentredatetime.hour;
            }
            getcardentredatetime.minute = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(8, 2)).ToString();
            if (getcardentredatetime.minute.Length < 2)
            {
                getcardentredatetime.minute = "0" + getcardentredatetime.minute;
            }
            getcardentredatetime.second = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(10, 2)).ToString();
            if (getcardentredatetime.second.Length < 2)
            {
                getcardentredatetime.second = "0" + getcardentredatetime.second;
            }
            getentrecurrentstation = readbuffstr.Substring(12, 3).ToString();
            label42.Text = getcardentredatetime.year + "-" + getcardentredatetime.month + "-" + getcardentredatetime.day + "-" + getcardentredatetime.hour + "：" + getcardentredatetime.minute + "：" + getcardentredatetime.second; //进站时间
            label44.Text = StationRecognition(cardrecovery.strHexTodoubleOct(getentrecurrentstation).ToString());      //进站名称

            //2. 获取出站日期和站点
            getcardexitdatetime.year = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(15, 3)).ToString();   //2017
            getcardexitdatetime.month = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(18, 1)).ToString();  //01
            if (getcardexitdatetime.month.Length < 2)
            {
                getcardexitdatetime.month = "0" + getcardexitdatetime.month;
            }
            getcardexitdatetime.day = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(19, 2)).ToString();    //21
            if (getcardexitdatetime.day.Length < 2)
            {
                getcardexitdatetime.day = "0" + getcardexitdatetime.day;
            }
            getcardexitdatetime.hour = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(21, 2)).ToString();   //12
            if (getcardexitdatetime.hour.Length < 2)
            {
                getcardexitdatetime.hour = "0" + getcardexitdatetime.hour;
            }

            getcardexitdatetime.minute = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(23, 2)).ToString(); //30
            if (getcardexitdatetime.minute.Length < 2)
            {
                getcardexitdatetime.minute = "0" + getcardexitdatetime.minute;
            }
            getcardexitdatetime.second = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(25, 2)).ToString(); //30
            if (getcardexitdatetime.second.Length < 2)
            {
                getcardexitdatetime.second = "0" + getcardexitdatetime.second;
            }
            getexitcurrentstation = readbuffstr.Substring(27, 3).ToString();
            label46.Text = getcardexitdatetime.year + "-" + getcardexitdatetime.month + "-" + getcardexitdatetime.day + "-" + getcardexitdatetime.hour + "：" + getcardexitdatetime.minute + "：" + getcardexitdatetime.second; //出站时间
            label48.Text = StationRecognition(cardrecovery.strHexTodoubleOct(getexitcurrentstation).ToString());      //出站点名称
            //3.获取进出站标志
            getentreandexitflag = cardrecovery.strHexTodoubleOct(readbuffstr.Substring(30, 2)).ToString();
            label50.Text = EntreAndExitRecognition(getentreandexitflag);

            return readbuffstr;
        }



        public string StationRecognition(string stationstr)  //参数为整形的字符串
        {
            string stationrecognition = "";
            switch (stationstr)
            {
                case "0":
                    stationrecognition = "龙阳路";
                    break;
                case "1":
                    stationrecognition = "华夏中路";
                    break;
                case "2":
                    stationrecognition = "罗山路";
                    break;
                case "3":
                    stationrecognition = "周浦东";
                    break;
                case "4":
                    stationrecognition = "鹤沙航城";
                    break;
                case "5":
                    stationrecognition = "航头东";
                    break;
                case "6":
                    stationrecognition = "新场";
                    break;
                case "7":
                    stationrecognition = "野生动物园";
                    break;
                case "8":
                    stationrecognition = "惠南";
                    break;
                case "9":
                    stationrecognition = "惠南东";
                    break;
                case "10":
                    stationrecognition = "书院";
                    break;
                case "11":
                    stationrecognition = "临港大道";
                    break;
                case "12":
                    stationrecognition = "滴水湖";
                    break;
                case "4095":
                    stationrecognition = "初始化站名";
                    break;
                default:
                    stationrecognition = "未知站名";
                    break;
            }
            return stationrecognition;
        }


        public double CalculationExitDecrementEnterValue(string exitstr, string entrestr)  // int类型string(出站点 ，进站点)
        {
            double exitdecremententrevalue = 0.0;
            Int32 decvalue = Math.Abs(Int32.Parse(cardrecovery.strHexTodoubleOct(exitstr).ToString()) - Int32.Parse(cardrecovery.strHexTodoubleOct(entrestr).ToString()));
            switch (decvalue)
            {
                case 0:

                case 2:

                case 3:
                    exitdecremententrevalue = 3.00;
                    break;
                case 4:

                case 5:

                case 6:
                    exitdecremententrevalue = 5.00;
                    break;
                case 7:

                case 8:

                case 9:
                    exitdecremententrevalue = 8.00;
                    break;
                case 10:
                    break;
                case 11:
                case 12:
                    exitdecremententrevalue = 10.00;
                    break;
                default:
                    break;
            }
            return exitdecremententrevalue;
        }



        public string EntreAndExitRecognition(string stationstr)
        {
            string entreandexitrecognition = "";
            switch (stationstr)
            {
                case "1":
                    entreandexitrecognition = "出站!!!";
                    entreandexitenableflag = true;
                    break;
                case "16":
                    entreandexitrecognition = "进站!!!";
                    entreandexitenableflag = false;
                    break;
                default:
                    entreandexitrecognition = "未知状态!!!";
                    entreandexitenableflag = false;
                    break;
            }
            return entreandexitrecognition;
        }


//——————————————————————————————————————————————————//
        public bool Str1AndStr2Check(string str1, string str2)     //（将str1数据与str2数据对比，相等为：true,不等为：false）
        {
            bool str1andstr2checkflag;
            if (str1.Substring(0,24) == str2.Substring(0,24))
            {
                str1andstr2checkflag = true;
            }
            else
            {
                str1andstr2checkflag = false;
            }
            return str1andstr2checkflag;
        }


        public bool Str1CopyStr2Andaddr(int icdev,string str1, string str2, int addr)     //（将str1数据写入到str2数据地址中，str2写入地址addr）
        {
            bool str1Copystr2Andaddrflag = false;
            int st1;
            string read_buff3str = str1.Substring(0, 24) + str2.Substring(24, 8);
            st1 = dc_write_hex(icdev, addr, read_buff3str);
            if (st1 == 0)
            {
                str1Copystr2Andaddrflag = true;
            }
            else
            {
                str1Copystr2Andaddrflag = false;
            }
            return str1Copystr2Andaddrflag ;
        }

        //返回值说明： -1： 读指令失败； 0：卡内备份金额写入到卡内金额不相等； 1：卡内备份金额写入到卡内金额相等
        public bool CardBlockCheckAndCopy(int icdev  ,bool copyflag,bool addrflag ,bool diaglogflag)  //addrflag =true；将卡内备份金额写入到卡内金额13-12
        {
            bool str1copystr2andaddr;
            bool cardblockcheckflag = false;
            byte[] read_buff1 = new byte[32];   //读金额      ---> 3扇区12块
            byte[] read_buff2 = new byte[32];   //读备份金额  ---> 3扇区13块
            byte[] read_buff3 = new byte[4];    //读金额      ---> 3扇区12块
            byte[] read_buff4 = new byte[4];    //读备份金额  ---> 3扇区13块

            int cardst1, cardst2,cardst3,cardst4;
            double cardblockvalue, cardbackblockvalue;

            cardst1 = dc_read_hex(icdev, 12, read_buff1);  //读取卡内数据
            cardst2 = dc_read_hex(icdev, 13, read_buff2);  //读取卡内备份数据 

            cardst3 = dc_readval(icdev, 12, read_buff3);  //读取卡内金额
            cardst4 = dc_readval(icdev, 13, read_buff4);  //读取卡内备份金额  

            //卡内金额  
            if (cardst1 == 0 && cardst2 == 0 && cardst3 ==0 && cardst4 == 0)
            {
                cardblockvalue = (read_buff3[3] * Math.Pow(16, 8) + read_buff3[2] * Math.Pow(16, 4) + read_buff3[1] * Math.Pow(16, 2) + read_buff3[0] * Math.Pow(16, 0));
                cardblockvaluestr = ChangeValue(cardblockvalue / 10);
                cardbackblockvalue = (read_buff4[3] * Math.Pow(16, 8) + read_buff4[2] * Math.Pow(16, 4) + read_buff4[1] * Math.Pow(16, 2) + read_buff4[0] * Math.Pow(16, 0));
                cardbackblockvaluestr = ChangeValue(cardbackblockvalue / 10);
                string str1 = Encoding.UTF8.GetString(read_buff1);   //12
                string str2 = Encoding.UTF8.GetString(read_buff2);   //13
                if (!Str1AndStr2Check(str2, str1))
                {
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡内金额和备份区金额不一致!!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡内金额为：" + cardblockvaluestr + "、备份区金额为：" + cardbackblockvaluestr);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    //MessageBox.Show("备份区金额和卡内金额不一致!!!","提示信息",MessageBoxButtons.OK);
                    if (copyflag)
                    {
                        if(diaglogflag)
                        { 
                            dialogresult = MessageBox.Show("    备份区金额和卡内金额不一致!!!\n\r    卡内金额为：" + cardblockvaluestr + "、备份区金额为：" + cardbackblockvaluestr + "\n\r" + "   Yes（将备份区金额转为卡内金额）、No（将卡内金额转为备份区金额）!!!", "提示信息", MessageBoxButtons.YesNoCancel);
                            if (dialogresult == DialogResult.Yes)//如果点击“确定”按钮
                            {
                                str1copystr2andaddr = Str1CopyStr2Andaddr(icdev, str2, str1, 12);   //将卡内备份金额写入到卡内金额13-12
                                if (str1copystr2andaddr)
                                {
                                    cardblockcheckflag = true;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将备份金额写入到卡内金额成功!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内备份金额写入到卡内金额成功!!!", "提示信息", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    cardblockcheckflag = false;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将备份金额写入到卡内金额失败!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内备份金额写入到卡内金额失败!!!", "提示信息", MessageBoxButtons.OK);
                                }
                            }
                            else if (dialogresult == DialogResult.No)
                            {
                                str1copystr2andaddr = Str1CopyStr2Andaddr(icdev, str1, str2, 13);   //将卡内金额写入到卡内备份金额 12-13
                                if (str1copystr2andaddr)
                                {
                                    cardblockcheckflag = true;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将卡内金额写入到备份金额成功!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内金额写入到卡内备份金额成功!!!", "提示信息", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    cardblockcheckflag = false;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将卡内金额写入到备份金额失败!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内金额写入到卡内备份金额失败!!!", "提示信息", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                cardblockcheckflag = false;
                                listBox1.Items.Add(DateTime.Now.ToString() + "  取消将卡内金额与备份金额交换!!!");
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                //MessageBox.Show("将卡内金额写入到卡内备份金额失败!!!", "提示信息", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            if (addrflag)
                            {
                                str1copystr2andaddr = Str1CopyStr2Andaddr(icdev, str2, str1, 12);   //将卡内备份金额写入到卡内金额13-12
                                if (str1copystr2andaddr)
                                {
                                    cardblockcheckflag = true;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将备份金额写入到卡内金额成功!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内备份金额写入到卡内金额成功!!!", "提示信息", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    cardblockcheckflag = false;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将备份金额写入到卡内金额失败!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内备份金额写入到卡内金额失败!!!", "提示信息", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                str1copystr2andaddr = Str1CopyStr2Andaddr(icdev, str1, str2, 13);   //将卡内金额写入到卡内备份金额 12-13
                                if (str1copystr2andaddr)
                                {
                                    cardblockcheckflag = true;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将卡内金额写入到备份金额成功!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内金额写入到卡内备份金额成功!!!", "提示信息", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    cardblockcheckflag = false;
                                    listBox1.Items.Add(DateTime.Now.ToString() + "  将卡内金额写入到备份金额失败!!!");
                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                    //MessageBox.Show("将卡内金额写入到卡内备份金额失败!!!", "提示信息", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
                else
                {
                    cardblockcheckflag = true;
                    listBox1.Items.Add(DateTime.Now.ToString() + "  备份区金额和卡内金额一致!!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    //MessageBox.Show("备份区金额和卡内金额一致!!!", "提示信息", MessageBoxButtons.OK);
                }
            }
            else
            {
                cardblockcheckflag = false;
                listBox1.Items.Add(DateTime.Now.ToString() + "  读取卡内金额和备份区金额指令失败!!!");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }

            return cardblockcheckflag;

        }



        public string ChangeValue(double datavalue)
        {
            //判断一个字符串中是否包含另一个字符串，可用以下两种方法
            //方法一： str1.Contains(str2);
            //方法二： str1.indexOf(str2)

            string changevalue = datavalue.ToString();

            if (changevalue.Contains("."))
            {
                //int length =changevalue.Length;
                //int n = changevalue.IndexOf(".");
                //int m = length- 1 - n;
                changevalue = changevalue + "0";
            }
            else
            {
                changevalue = changevalue + ".00";
            }
            return changevalue;
        }


        //——————————————————————————————————————————————————//

        //private void DoUpdate(string data)
        //{
        //    if (data == "")
        //    {
        //        return;
        //    }
        //    string receivecardidnum = data.Substring(0, 11);
        //    string cardnew = File.ReadAllText(@".\Test\CardNew.txt");
        //    if (cardnew.Contains(receivecardidnum))
        //    {
        //        if (radioButton5.Checked)
        //        {
        //            serialPort1.WriteLine(str1);  //打开闸机命令
        //        }
        //        if (radioButton6.Checked)
        //        {
        //            serialPort1.WriteLine(str2);  //打开闸机命令
        //        }
        //        int n = cardnew.IndexOf(receivecardidnum);
        //        cardnew = cardnew.Remove(n - 1, 12);
        //        File.WriteAllText(@".\Test\CardNew.txt", cardnew);
        //        File.AppendAllText(@".\test\cardold.txt", receivecardidnum + "\r\n");

        //        listBox1.Items.Add(DateTime.Now.ToString() + "  " + receivecardidnum +"闸机门已经打开,请尽快通过!!!");
        //        listBox1.SelectedIndex = listBox1.Items.Count - 1;
        //    }
        //    else
        //    {
        //        listBox1.Items.Add(DateTime.Now.ToString() + "  " + receivecardidnum + "此二维码已过期,请再更换一张进行刷卡!!!");
        //        listBox1.SelectedIndex = listBox1.Items.Count - 1;
        //    }
        //    Thread.Sleep(1000);
        //}

    }
}

