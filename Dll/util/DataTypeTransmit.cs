using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoatTools
{
    //String To Byte[]：
//byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);

//Byte[] To String：
//string str = System.Text.Encoding.Default.GetString(byteArray);
    public class DataTypeTransmit 
    {
        // 调用示例：Debug.WriteLine(HexToFloat("AEE7CC43"));
        public static  float HexToFloat(string p_strRaw){ //16进制转浮点数
            int len = p_strRaw.Length;
            byte[] TempArry = new byte[len / 2];
            for (int i = 0; i < len / 2; i++) {
                TempArry[i] = Convert.ToByte(p_strRaw.Substring(i * 2, 2), 16);
            }
            return BitConverter.ToSingle(TempArry, 0);
        }

        public static Int16 HexToInt16(string p_strRaw){ //16进制转整数
            int len = p_strRaw.Length;
            byte[] TempArry = new byte[len / 2];
            for (int i = 0; i < p_strRaw.Length / 2; i++){
                TempArry[i] = Convert.ToByte(p_strRaw.Substring(i * 2, 2), 16);
            }
            return BitConverter.ToInt16(TempArry, 0);
        }

        //   P1= "02000300040005000600070008000a00" P2= 4   返回：  0200 0300 0400 0500 0600 0700 0800 0a00
        public static byte[] StringToByteArray(string hex) {// 十六进制string 转换成 byte[]  该函数不能输入单个字符  eg：“A”
            hex = hex.Replace(" ", "");
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }


        public static string ByteArr2hexStr(byte[] arrByte){//实现byte[]转换成十六进制string功能即可
            StringBuilder sb = new StringBuilder();
            foreach (byte b in arrByte) {
                sb.Append(b > 15 ? Convert.ToString(b, 16) : '0' + Convert.ToString(b, 16));
            }
            return sb.ToString();
        }




        public static string strArr2string(string[] strArr)//将String[]数组转换为String字符串 01 53 00 00 00 01 44 06 =>0x01,0x53,0x00,0x00,0x00,0x01,0x44,0x06
        {
            String strNew = String.Empty;
            for (int i = 0; i < strArr.Length; i++)
            {
                strNew += strArr[i];
            }
            return strNew;
        }


        public static string[] string2strArr(string str)//string 转换成string[]
        {
            str.Replace(" ", "");// 干掉用户输入或是粘贴进来的 字符串中的所有空格
            StringBuilder SB = DataTypeAction.InsertSpace(str.ToCharArray()); //将字符数组中的数据 每个两位加入一个空格 ****************插入规范空格 SB={01 53 00 00 00 01}******************
            string[] LightHex = Regex.Split(SB.ToString(), " ");//把用户输入的16进制数 拆分成字符数组  ****************干掉规范空格后操作数据******************
            return LightHex;
        }

        public static byte[] StringToByte(string[] StringArray) //将string[]转换成byte[]
        {
            //int len = ((StringArray.Length - 1) / 8 + 1) * 8; //数组长度
            byte[] Bytes = new byte[StringArray.Length];                 //输入内容数组
            for (int i = 0; i < StringArray.Length; i++)
            {
                try { Bytes[i] = byte.Parse(Convert.ToInt32(StringArray[i], 16).ToString()); }//把输入的字符串转换成byte[]数组
                catch (Exception E) { throw E; }
                finally { }
            }
            return Bytes;
        }

    }
}


//C# 中字符串string和字节数组byte[]的转换

//string转byte[]:

//byte[] byteArray = System.Text.Encoding.Default.GetBytes ( str );
//byte[]转string：

//string str = System.Text.Encoding.Default.GetString ( byteArray );
//string转ASCII byte[]:

//byte[] byteArray = System.Text.Encoding.ASCII.GetBytes ( str );
//ASCII byte[]转string:

//string str = System.Text.Encoding.ASCII.GetString ( byteArray );