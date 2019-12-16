using System;
using System.Linq;
using System.Text;

namespace GoatTools
{
    public class DataTypeAction
    {
        public static byte[] ByteArrAppend(byte[] a, byte[] b){ //byte[] 字节数组拼接 把b接在a的后面
            return a = a.Concat(b).ToArray(); //.net3.5以上的linq方法
        }




        //123----00000123
        //1231----00001231
        //123123----00123123
        //12312312----12312312
        // P1=要补足的目标字符串，P2=填充标记，P3=填充后的字符串总长度 P4= 填充方向 true向右  false向左
        public static String PadStr(String str, char mark, int totalWidth, bool direction) {
            String temp;
            if (direction) {
                temp = str.PadRight(totalWidth, mark);//在字符串左边用 paddingChar 补足 totalWidth 长度
            }
            else {
                temp = str.PadLeft(totalWidth, mark);//在字符串左边用 paddingChar 补足 totalWidth 长度
            }
            return temp;
        }


        //4字节(8位)字符串     每两个字节倒序  
        //00000123----23010000
        //00001231----31120000
        //00123123----23311200
        //12312312----12233112
        public static String StrReverse(String str)  {
            StringBuilder heihei = new StringBuilder();
            for (int i = 2; i <= str.Length; i = i + 2){
                heihei.Append(str.Substring(str.Length - i, 2));
            }
            return heihei.ToString();
        }

        // 20180112 123456   2018-01-12 12:34:56
        // 20090320 153927   2009-03-20 15:39:27
        // P1 = 要转换的字符串  P2= 日期间隔标识  P3= 时间间隔标识 P4=日期和时间的间隔标识
        public static String str2Date(String str,String dateMark,String timeMark,String midMark) { //要求输入字符串长度为 14
            StringBuilder sb = new StringBuilder();
            sb.Append(str.Substring(0, 4));
            sb.Append(dateMark);
            sb.Append(str.Substring(4, 2));
            sb.Append(dateMark);
            sb.Append(str.Substring(6, 2));
            sb.Append(midMark);

            sb.Append(str.Substring(8, 2));
            sb.Append(timeMark);
            sb.Append(str.Substring(10, 2));
            sb.Append(timeMark);
            sb.Append(str.Substring(12, 2));
            return sb.ToString();

        }
        //P1= "02000300040005000600070008000a00" P2= 4   返回：  0200 0300 0400 0500 0600 0700 0800 0a00
        public static String[] StrSplit(String hoho, int space){ // P1 要拆分的字符串  P2 拆分间隔
            int length = hoho.Length / space;
            String[] shcuy = new String[length];
            for (int i = 0; i < length; i++)
            {
                shcuy[i] = hoho.Substring(i * space, space);
            }
            return shcuy;
        }

        public static string[] insert0x(string[] strArr) {//将String[]数组 加入0x 和 逗号
            for (int i = 0; i < strArr.Length; i++){
                if (i == strArr.Length - 1) { strArr[i] = "0x" + strArr[i]; break; }//循环到最后一个字符的时候 不要再追加“,”
                strArr[i] = "0x" + strArr[i] + ",";
            }
            return strArr;
        }

        public static StringBuilder InsertSpace(char[] temp){ //将给定的字符数组中 每个两位字符增加一个空格
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)  {
                if (i > 1 && i % 2 == 0) { SB.Append(" "); }
                SB.Append(temp[i].ToString());
            }
            return SB;
        }

        public static StringBuilder InsertSpace(char[] temp,String replace) { //将给定的字符数组中 每个两位字符增加一个 指定的字符串
            StringBuilder SB = new StringBuilder();
            for (int i = 0; i < temp.Length; i++) {
                if (i > 1 && i % 2 == 0) { SB.Append(replace); }
                SB.Append(temp[i].ToString());
            }
            return SB;
        }
      
    }
}
