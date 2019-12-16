using System.Text.RegularExpressions;

namespace GoatTools
{
    public class JudgeUtil
    {
        public static  bool IsOk(string hex) //用来判断 给定字符串里 是否全部都是16进制数据
        {
            string PATTERN = @"([^A-Fa-f0-9]|\s+?)+";
            return Regex.IsMatch(hex, PATTERN);
        }
        public static bool EqualsByteArr(byte[] b1, byte[] b2)//判断两个字节数组 是否相等
        {
            if (b1.Length != b2.Length) return false;
            if (b1 == null || b2 == null) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
    }
}
