using System.Text.RegularExpressions;

namespace GoatTools
{
    public class regular
    {
            //            repositoryItemTextEdit1.Mask.MaskType = MaskType.RegEx;
            //    repositoryItemTextEdit1.Mask.EditMask = @"[0-9a-fA-F ]+";  只允许输入16进制 和 空格 
            //repositoryItemTextEdit1.Mask.EditMask = @"\d+";  // 只允许输入 整数

        public static bool Is16(string input)
        {
            Regex regex = new Regex("[0-9a-fA-F ]+"); // 只允许输入16进制数 和 空格
            return regex.IsMatch(input);
        }

        public static bool IsMac_mark(string input)
        {
            Regex regex = new Regex("^[A-F0-9]{2}(:[A-F0-9]{2}){5}$");//只允许输入 16进制 和 :  并按照指定格式 (7A:DF:13:12:43:55)
            return regex.IsMatch(input);
        }
        public static bool IsMac(string input)
        {
            // (25[0-5]|2[0-4]\d|1\d\d|[1-9]\d|[1-9])  只允许输入1-255之间的数字
            Regex regex = new Regex("^[A-F0-9]{2}([A-F0-9]{2}){5}$");//只允许输入 16进制 和 :  并按照指定格式 (7ADF13124355)
            return regex.IsMatch(input);
        } 
    }
}
