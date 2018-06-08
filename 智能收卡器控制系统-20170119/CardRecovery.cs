using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFTest
{
    enum SlaveID
    {
	    NCicle_SlaveID = 0x40,   //单次发送
		Cicle_SlaveID  = 0x80,   //循环发送
    };			

	struct QueryCommand_Request
	{
		private byte head;
		public byte HEAD
		{
			get { return head ;}
			set { head = value ;}		
		}
		
		private byte rpf_slaveid;
		public byte RPF_SlaveID
		{
			get { return rpf_slaveid;}
			set { rpf_slaveid = value;}			
		}
		
		private byte length;
		public byte LENGTH
		{
			get { return length;}
			set { length = value;}			
		}
		
		private byte data;
		public byte DATA
		{
			get { return data; }
			set { data = value; }			
		}
		
		private byte crch;
		public byte CRCH
		{
			get { return crch; }
			set { crch = value; }			
		}
		
		private byte crcl;
        public byte CRCL
		{
			get {return crcl;}
			set {crcl = value;}			
		}	
		
		public QueryCommand_Request(byte head, byte rpf_slaveid,byte length,byte data,byte crch,byte crcl)
		{
			this.head =head;
			this.rpf_slaveid = rpf_slaveid;
			this.length = length;
			this.data = data;
			this.crch = crch;
			this.crcl =crcl;
		}	
	};
	
	enum QueryCommand_Response          //上位机发送查询命令0x07后响应
    {
		RET_GetCard 	= 0xc0,			//卡机中有卡插入，并且在进卡
		RET_WaitCmd 	= 0xc1,			//卡机在等待上位机命令
		RET_Receiving 	= 0xc2,			//卡机正在收卡
		RET_Received 	= 0xc3,			//卡已回收
		RET_Exiting 	= 0xc4,			//卡机正在退卡
		RET_Exited 		= 0xc5,			//卡已退出
		RET_EntryJam 	= 0xc7,			//卡在收卡时超时或阻塞
		RET_ExitJam 	= 0xc8,			//卡在退卡时超时或阻塞
	    RET_RDY 		= 0xf0			//卡机中没有卡，等待插入卡
    };

    enum CardCommand_Response           //3.收卡:0x20  4.退卡:0x21  5.进卡:0x25  6.允许卡机工作:0x0A  7.禁止卡机工作:0x09  --------卡片控制响应
    {
        AckCmdRecv = 0xF1, 		        //命令已接收，并可以执行
        AckUndo = 0xF5,				    //命令不能被执行
        AckBusy = 0xE1,				    //收卡机正忙，不能接收命令
        AckUnRdy = 0xE0,				//收卡机没有准备好
        AckDisable = 0xF8,				//收卡机被禁止
        AckEnable = 0xf9	            //卡机工作允许
    };

    enum Status
    {
        FALSE = 0x00,
        TRUE = 0x01
    };

	struct QueryStatusCommand_Response  //上位机发送查询命令0x05后响应
    {
		public  bool  Empty; 			//置1时为入口处有卡插入。
		public  bool  Out;				//为卡片送至出口处。
		public  bool  Error; 			//置1时为有错误发生，超时或者是堵塞。
		public  bool  Receiving; 		//当此标志置1时，表明收卡机正在执行收卡操作。
		public  bool  Exiting; 			//当此标志置1时，表明收卡机正在退出卡片。
		public  bool  Waitting; 	    //当此标志置1时， 表明收卡机已自动接收到卡片，正在等待处理命令。
		public  bool  Idle;				//表明收卡机已准备好，可以插入卡片。
    };


    struct CalendarDateTime   //上位机发送查询命令0x05后响应
    {
        //DateTime 数字型
        //System.DateTime currentTime = new System.DateTime();
        //取当前年月日时分秒 currentTime = System.DateTime.Now;
        //取当前年 int 年 = currentTime.Year;
        //取当前月 int 月 = currentTime.Month;
        //取当前日 int 日 = currentTime.Day;
        //取当前时 int 时 = currentTime.Hour;
        //取当前分 int 分 = currentTime.Minute;
        //取当前秒 int 秒 = currentTime.Second;
        //取当前毫秒 int 毫秒 = currentTime.Millisecond; （变量可用中文）
        public string year;      //取当前年
        public string month;     //取当前月
        public string day ;      //取当前月
        public string hour;      //取当前月
        public string minute;    //取当前月
        public string second;    //取当前月
    }



     class CardRecovery
    {
        private static readonly int[] CRC_Table = new int[]//crc高位表
        {
			0x0000,0x8005,0x800F,0x000A,0x801B,0x001E,0x0014,0x8011,    
			0x8033,0x0036,0x003C,0x8039,0x0028,0x802D,0x8027,0x0022, 
			0x8063,0x0066,0x006C,0x8069,0x0078,0x807D,0x8077,0x0072, 
			0x0050,0x8055,0x805F,0x005A,0x804B,0x004E,0x0044,0x8041, 
			0x80C3,0x00C6,0x00CC,0x80C9,0x00D8,0x80DD,0x80D7,0x00D2, 
			0x00F0,0x80F5,0x80FF,0x00FA,0x80EB,0x00EE,0x00E4,0x80E1, 
			0x00A0,0x80A5,0x80AF,0x00AA,0x80BB,0x00BE,0x00B4,0x80B1, 
			0x8093,0x0096,0x009C,0x8099,0x0088,0x808D,0x8087,0x0082, 
			0x8183,0x0186,0x018C,0x8189,0x0198,0x819D,0x8197,0x0192, 
			0x01B0,0x81B5,0x81BF,0x01BA,0x81AB,0x01AE,0x01A4,0x81A1, 
			0x01E0,0x81E5,0x81EF,0x01EA,0x81FB,0x01FE,0x01F4,0x81F1, 
			0x81D3,0x01D6,0x01DC,0x81D9,0x01C8,0x81CD,0x81C7,0x01C2, 
			0x0140,0x8145,0x814F,0x014A,0x815B,0x015E,0x0154,0x8151, 
			0x8173,0x0176,0x017C,0x8179,0x0168,0x816D,0x8167,0x0162, 
			0x8123,0x0126,0x012C,0x8129,0x0138,0x813D,0x8137,0x0132, 
			0x0110,0x8115,0x811F,0x011A,0x810B,0x010E,0x0104,0x8101,
			0x8303,0x0306,0x030C,0x8309,0x0318,0x831D,0x8317,0x0312, 
			0x0330,0x8335,0x833F,0x033A,0x832B,0x032E,0x0324,0x8321, 
			0x0360,0x8365,0x836F,0x036A,0x837B,0x037E,0x0374,0x8371, 
			0x8353,0x0356,0x035C,0x8359,0x0348,0x834D,0x8347,0x0342, 
			0x03C0,0x83C5,0x83CF,0x03CA,0x83DB,0x03DE,0x03D4,0x83D1, 
			0x83F3,0x03F6,0x03FC,0x83F9,0x03E8,0x83ED,0x83E7,0x03E2, 
			0x83A3,0x03A6,0x03AC,0x83A9,0x03B8,0x83BD,0x83B7,0x03B2, 
			0x0390,0x8395,0x839F,0x039A,0x838B,0x038E,0x0384,0x8381, 
			0x0280,0x8285,0x828F,0x028A,0x829B,0x029E,0x0294,0x8291, 
			0x82B3,0x02B6,0x02BC,0x82B9,0x02A8,0x82AD,0x82A7,0x02A2, 
			0x82E3,0x02E6,0x02EC,0x82E9,0x02F8,0x82FD,0x82F7,0x02F2, 
			0x02D0,0x82D5,0x82DF,0x02DA,0x82CB,0x02CE,0x02C4,0x82C1, 
			0x8243,0x0246,0x024C,0x8249,0x0258,0x825D,0x8257,0x0252, 
			0x0270,0x8275,0x827F,0x027A,0x826B,0x026E,0x0264,0x8261, 
			0x0220,0x8225,0x822F,0x022A,0x823B,0x023E,0x0234,0x8231, 
			0x8213,0x0216,0x021C,0x8219,0x0208,0x820D,0x8207,0x0202 
		}; 


        //CRC16校验
        public byte[] CRC16(byte[]DataSource, int Sset, int Eset)
        {
            byte CRCH;
            byte CRCL;
            int table_addr;
            CRCH = DataSource[Eset + 1];
            CRCL = DataSource[Eset + 2];            
            for (int i = Sset; i <= Eset; i++)
            {
                table_addr = (CRCH ^ DataSource[i]);
                CRCH = (byte) ((CRC_Table[table_addr] >> 8) ^ CRCL);
                CRCL = (byte) (CRC_Table[table_addr] & 0x00FF);
            }
            DataSource[Eset+1] = CRCH;
            DataSource[Eset+2] = CRCL;
            return DataSource;
        }


        //字节数组转16进制字符串
        public string byteToHexStr(byte[] bytes)
        {
            string returnstr = "";
            if (bytes != null)
            {
                for (int i = 0; i< bytes.Length; i++)
                {
                    returnstr += bytes[i].ToString("X2");
                }           
            }
            return returnstr;
        }

        //字符串转16进制字节数组
        public byte[] strToHexBytes(string hexString)
        {
            hexString = hexString.Replace(" ","");
            if ((hexString.Length % 2) != 0)
            {
                hexString += "";
            }
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
                return returnBytes;
        }

        public int CheckDataLength( byte data)
        {
            int datalength =3;
            switch (data)
            {
                case 01:
                    datalength = 3;
                    break;
                case 02:
                    datalength = 4;
                    break;
                case 03:
                    datalength = 5; 
                    break;
                default:
                    break;
            }
            return datalength; 
        }


        //字符串转10进制
        public int HexToOct(string Hex)
        {
            int Oct = 0;
            switch (Hex)
            { 
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Oct = int.Parse(Hex);
                    break;
                case "A":
                    Oct = 10;
                    break;
                case "B":
                    Oct = 11;
                    break;
                case "C":
                    Oct = 12;
                    break;
                case "D":
                    Oct = 13;
                    break;
                case "E":
                    Oct = 14;
                    break;
                case "F":
                    Oct = 15;
                    break;
                default:
                    break;
            }
            return Oct;
        }


        //字符串转10进制字符串
        public string OctToHex(int Oct)
        {
            string Hex = "";
            switch (Oct)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    Hex = Oct.ToString();
                    break;
                case 10:
                    Hex = "A";
                    break;
                case 11:
                    Hex = "B";
                    break;
                case 12:
                    Hex = "C";
                    break;
                case 13:
                    Hex = "D";
                    break;
                case 14:
                    Hex = "E";
                    break;
                case 15:
                    Hex = "F";
                    break;
                default:
                    break;
            }
            return Hex;
        }

        //16进制字符串运算后转10进制字符串
        public double strHexTodoubleOct(string hexStr)
        {
            int length = hexStr.Length;
            double data = 0;
            double sum = 0; 
            for(int i = 0; i< length; i++)
            {
                data = HexToOct(hexStr.Substring(i, 1)) * Math.Pow(16,length - i - 1);
                sum = sum + data;
            }
            return sum;
        }


        //10进制转16进制
        public string strOctTostrHex(int octStr)
        {
            String datastr = octStr.ToString("x8");
            return datastr;
        }


        //10进制数组转16进制字符串
        public string OctToHexStr(byte[] bytes)
        {
            string returnstr = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                returnstr += ((char)bytes[i]).ToString();
            }
            return returnstr;
        }


        //10转16进制得到3位数的16进制字符串
        public string OctToHex3BitStr(int datas)   //进行转换
        {
            //string datastr = datas.ToString();
            //int length = datastr.Length;
            int length = 4;
            int [] Hex3BitStr = new int[4];
            string data = ""; 
            for (int i = 0; i < length; i++)
            {
                int pow =(int)(Math.Pow(16, length - 1 - i));
                Hex3BitStr[i] = datas / pow;
                datas = datas % pow;
                data += OctToHex(Hex3BitStr[i]);                
            }
            return data.Substring(1,3);
        }











    }
}



