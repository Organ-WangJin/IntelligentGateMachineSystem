
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
        public static extern short dc_pro_command(int icdev, byte slen, byte[] sendbuff, ref byte rlen,                                                    [Out]byte[] recvbuff, byte timeout);
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
        getstring getmystring;                            //定义委托变量 
        CardRecovery cardrecovery = new CardRecovery();
        Byte[] DataPage = new Byte[10];
        byte[] receivebuffer;
        byte[] sendbuffer;
        int readcardflag;
        string CardIdNum;                       //本次读取到的卡号
        string cardidnum;                       //上一次读取到的卡号
        string cardnewstr;                      
        string cardoldstr;
        int icdev1;                             //读写器设备描述符 icdev1: 出闸机
        int icdev2;                             //读写器设备描述符 icdev1: 出闸机, icdev2:进闸机
        bool CardRecoveryflag;                  //卡接收标志位
        Thread thread1;
        Int32 invaluebefore;                    //充值或扣款前金额
        Int32 invalueafter;                     //充值或扣款后金额
        Int32 incrementvalue;                   //充值金额
        Int32 decrementvalue;                   //减值金额
        bool GetYRecovryReaderProessFlag;

        string strenter3 = "7f400120ffff";      //收卡
        string strenter4 = "7f400121ffff";      //退卡
        string str1 = "ATOP1\r\n";              //进闸机
        string str2 = "ATOP2\r\n";              //出闸机
        DialogResult dialogresult;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CardRecoveryflag = false;
            GetYRecovryReaderProessFlag = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            radioButton5.Checked = true;
            label2.Hide();
            groupBox22.Hide();
            for (int i = 0; i < 11; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            comboBox1.Enabled = false;
            timer3.Enabled = true;
        }


        private void button31_Click(object sender, EventArgs e)
        {
            if(button31.Text == "闸机程序运行")
            {
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
                    return;
                }
                else
                {
                    listBox1.Items.Add(DateTime.Now.ToString() + "  进闸机读卡器已连接!!!");
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    dc_beep(icdev2, 10);

                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton6.Enabled = true;
                    comboBox1.Enabled = true;
                    label2.Show();
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
                System.Threading.Thread.Sleep(50);
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
            int st;
            char[] ssnr = new char[128];
            byte[] recv_buff = new byte[4];
            Double value;
            invaluebefore = 0;
            invalueafter = 0;
            incrementvalue = 0;
            label2.Text = "";
            //对卡片进行初始化
            st = dc_config_card(icdev2, 0x41); //读取M1卡ID
            st = dc_card_double_hex(icdev2, 0, ssnr);
            if (st == 0)
            {
                dc_beep(icdev2, 10);
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                cardnewstr = File.ReadAllText(@".\Test\CardNew.txt");
                cardoldstr = File.ReadAllText(@".\Test\CardOld.txt");
                ////对卡片权限进行操作
                //string str = File.ReadAllText(@".\Test\Card.txt");
                //File.WriteAllText(@".\Test\CardNew.txt", str);
                //File.WriteAllText(@".\Test\CardOld.txt", "//test\r\n");
                //File.AppendAllText(@".\Test\CardNew.txt", str);
                //listBox1.Items.Add(DateTime.Now.ToString() + "  初始化卡片完成!!!");
                //listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (cardnewstr.Contains(CardIdNum) == false && cardoldstr.Contains(CardIdNum) == false)  //卡号存在数据库中
                {
                    dialogresult = MessageBox.Show("此卡未注册，是否注册卡片 !!!", "卡片注册提示", MessageBoxButtons.OKCancel);
                    if (dialogresult == DialogResult.OK)//如果点击“确定”按钮
                    {
                        File.AppendAllText(@".\Test\CardNew.txt", CardIdNum + "\r\n");
                        st = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                        if (st == 0)            //密钥认证
                        {                                                             //读余额
                            st = dc_write_hex(icdev2, 13, "00000000FFFFFFFF0000000012ED12ED");
                            st = dc_write_hex(icdev2, 12, "00000000FFFFFFFF0000000011EE11EE");
                            if (st == 0)             //注册卡片成功
                            {
                                readcardflag = 22;   //注册卡片成功
                                MessageBox.Show("注册卡片成功 !!!", "提示信息",MessageBoxButtons.OK);
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
                    dialogresult = MessageBox.Show("此卡已经注册,是否进行充值(充值前请确认充值金额大于 0 元) !!!", "卡片充值提示",MessageBoxButtons.YesNo);
                    if (dialogresult == DialogResult.Yes)
                    {
                        //读取卡中金额,并进行验证
                        st = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                        if (st == 0)            //密钥认证
                        {
                            recv_buff = new byte[4];
                            st = dc_readval(icdev2, 12, recv_buff);
                            if (st == 0)     //读充值前卡内金额
                            {
                                listBox1.Items.Add(DateTime.Now.ToString() + "  读充值前卡内余额成功!!!");
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                invaluebefore = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                value = (double)invaluebefore / 100;
                                listBox1.Items.Add(DateTime.Now.ToString() + "  充值前卡内余额： " + value.ToString() + "元");
                                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                label2.Text = Math.Round(value, 2).ToString();
                                if (double.Parse(comboBox1.Text) > 0.00)
                                {
                                    //充值
                                    dialogresult = MessageBox.Show("充值金额为： " + comboBox1.Text + " 元,请确认是否充值!", "卡片充值确认提示", MessageBoxButtons.OKCancel);
                                    if (dialogresult == DialogResult.OK)//如果点击“确定”按钮
                                    {
                                        incrementvalue = 0;
                                        incrementvalue = Int32.Parse((double.Parse(comboBox1.Text) * 100).ToString());
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  充值金额为：" + comboBox1.Text + "元");
                                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                        if (value + Double.Parse(incrementvalue.ToString()) / 100 <= 655.35)
                                        {
                                            st = dc_increment(icdev2, 12, incrementvalue);  //充值
                                            if (st == 0)
                                            {
                                                //读充值后余额
                                                recv_buff = new byte[4];
                                                st = dc_readval(icdev2, 12, recv_buff);
                                                if (st == 0)
                                                {
                                                    invalueafter = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                                    value = (double)invalueafter / 100;
                                                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值后卡内余额： " + value.ToString() + "元");
                                                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                                                    //进行判断是否充值成功有效
                                                    if (invalueafter == invaluebefore + incrementvalue)
                                                    {
                                                        label2.Text = Math.Round(value, 2).ToString();
                                                        MessageBox.Show("充值成功 !!!", "充值结果提示", MessageBoxButtons.OK);
                                                        readcardflag = 23;    //充值成功       
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
                                MessageBox.Show("读充值前卡内余额失败  !!!", "充值结果提示", MessageBoxButtons.OK);
                                readcardflag = 11;    // 读充值前卡内余额失败   
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
            invaluebefore = 0;
            invalueafter = 0;
            decrementvalue = 0;
            CardIdNum = "";
            cardoldstr = File.ReadAllText(@".\Test\CardOld.txt");
            st = dc_config_card(icdev1, 0x41); //读取M1卡ID
            st = dc_card_double_hex(icdev1, 0, ssnr);
            if (st == 0)
            {
                dc_beep(icdev1, 10);
                label2.Text = "";
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (cardoldstr.Contains(CardIdNum))  //卡号存在数据库中
                {
                    //读取卡中金额,并进行验证
                    st = dc_authentication_pass_hex(icdev1, 0, 3, "ffffffffffff");  //第3扇区第一块
                    if (st == 0)
                    {
                        byte[] recv_buff = new byte[128];
                        st = dc_readval(icdev1, 12, recv_buff);
                        if (st == 0) //读扣款前卡内余额
                        {

                            invaluebefore = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                            double value = (double)invaluebefore / 100;
                            listBox1.Items.Add(DateTime.Now.ToString() + "  扣款前卡内余额:" + value.ToString() + "元");
                            label2.Text = value.ToString();
                            if (value > 0)  //&& value >= Double.Parse(comboBox1.Text)
                            {
                                //减值
                                decrementvalue = Int32.Parse((Double.Parse(comboBox1.Text) * 100).ToString());
                                listBox1.Items.Add(DateTime.Now.ToString() + "  扣款金额:" + Double.Parse(comboBox1.Text) + "元");
                                st = dc_decrement(icdev1, 12, decrementvalue);
                                if (st == 0)
                                {
                                    //读扣款后卡内余额
                                    recv_buff = new byte[128];
                                    st = dc_readval(icdev1, 12, recv_buff);
                                    if (st == 0)
                                    {
                                        invalueafter = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                                        value = (double)invalueafter / 100;
                                        listBox1.Items.Add(DateTime.Now.ToString() + "  扣款后卡内余额:" + value.ToString() + "元");
                                        label2.Text = value.ToString();
                                        if (invalueafter == invaluebefore - decrementvalue)
                                        {
                                            listBox1.Items.Add(DateTime.Now.ToString() + "  扣款成功!!!");
                                            sendbuffer = cardrecovery.strToHexBytes(strenter3);  //收卡
                                            if (radioButton3.Checked == true)
                                            {
                                                readcardflag = 1;      //进闸机
                                            }
                                            else
                                            {
                                                readcardflag = 2;      //出闸机
                                            }
                                            int n = cardoldstr.IndexOf(CardIdNum);                        //找到CardIdNum在string类型为cardnew中第一次出现处的索引
                                            cardoldstr = cardoldstr.Remove(n - 1, CardIdNum.Length + 1);  //从索引处删除多少位;  
                                            File.WriteAllText(@".\Test\CardOld.txt", cardoldstr);
                                            File.AppendAllText(@".\Test\CardNew.txt", CardIdNum + "\r\n");
                                        }
                                        else  //减值失败
                                        {
                                            sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                            readcardflag = 16;    
                                        }
                                    }
                                    else//读扣款后卡内余额错误
                                    {
                                        sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                                        readcardflag = 3;
                                    }
                                }
                                else//减值指令返回失败                                                                                
                                {
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
                        readcardflag = 7;  //密钥认证失败
                        sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                    }
                }
                else
                {
                    readcardflag = 9;  //此卡没有进站，请到服务中心处理
                    sendbuffer = cardrecovery.strToHexBytes(strenter4);  //退卡
                }
            }
            else
            {
                readcardflag = 10;  //寻卡失败，未检测到卡
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
            CardIdNum = "";
            cardnewstr = File.ReadAllText(@".\Test\CardNew.txt");
            st = dc_config_card(icdev2, 0x41); //读取M1卡ID
            st = dc_card_double_hex(icdev2, 0, ssnr);  //寻卡操作
            if (st == 0)
            {
                dc_beep(icdev2, 10);
                string stemp = new string(ssnr);
                CardIdNum = stemp.Substring(0, 8);
                listBox1.Items.Add(DateTime.Now.ToString() + "  卡号为:" + CardIdNum);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                if (CardIdNum != cardidnum)
                {
                    label2.Text = "";
                }
                cardidnum = CardIdNum;
                //读取卡中金额,并进行验证
                st = dc_authentication_pass_hex(icdev2, 0, 3, "ffffffffffff");  //第3扇区第一块
                if (st == 0)
                {
                    byte[] recv_buff = new byte[128];
                    st = dc_readval(icdev2, 12, recv_buff);
                    if (st == 0) //读卡内余额
                    {
                        Int32 invalue = (Int32)(recv_buff[3] * Math.Pow(16, 8) + recv_buff[2] * Math.Pow(16, 4) + recv_buff[1] * Math.Pow(16, 2) + recv_buff[0] * Math.Pow(16, 0));
                        double value = (double)invalue / 100;
                        listBox1.Items.Add(DateTime.Now.ToString() + "  卡内余额:" + value.ToString() + "元");
                        label2.Text = value.ToString();
                        if (cardnewstr.Contains(CardIdNum))  //卡号存在数据库中
                        {
                            if (value >= Double.Parse(comboBox1.Text) && value > 0)
                            {
                                if (radioButton1.Checked)
                                {
                                    readcardflag = 1;    //进闸机
                                }
                                else
                                {
                                    readcardflag = 2;    //出闸机
                                }
                                int n = cardnewstr.IndexOf(CardIdNum);                 //找到CardIdNum在string类型为cardnew中第一次出现处的索引
                                cardnewstr = cardnewstr.Remove(n -1, CardIdNum.Length + 1);      //从索引处删除多少位;  
                                File.WriteAllText(@".\Test\CardNew.txt", cardnewstr);
                                File.AppendAllText(@".\Test\CardOld.txt", CardIdNum + "\r\n");
                            }
                            else
                            {
                                readcardflag = 5;  //卡内余额不足,请充值!
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
                    readcardflag = 7;  //密钥验证失败!
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
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 读扣款后余额失败 !!!");
                    break;
                case 4:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 减值指令返回失败 !!!");
                    break;
                case 5:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 卡内余额不足 !!!");
                    break;
                case 6:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 读扣款前卡内余额失败 !!!");
                    break;
                case 7:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 密钥认证失败 !!!");
                    break;
                case 8:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 此卡未注册或已进站 !!!");
                    break;
                case 9:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + " 此卡无进站记录 !!!");
                    break;
                case 10:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  收卡机未检测到卡,请刷卡通过闸机 !!!");
                    break;
                case 11:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "读充值前卡内余额失败 !!!");
                    break;
                case 12:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "充值金额已经超限 !!!");
                    break;
                case 13:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "充值指令返回失败 !!!");
                    break;
                case 14:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "读充值后卡内金额失败 !!!");
                    break;
                case 15:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "充值失败 !!!");
                    break;
                case 16:
                    listBox1.Items.Add(DateTime.Now.ToString() + "  卡号：" + CardIdNum + "减值失败 !!!");
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
                    listBox1.Items.Add(DateTime.Now.ToString() + "  充值成功 !!!");
                    break;
                default:
                    break;
            }
            readcardflag = 0;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton3.Checked = false;
            }
            else
            {
                radioButton3.Checked = true;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton4.Checked = false;
            }
            else
            {
                radioButton4.Checked = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

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

