namespace chapter1_0_2 {

    public class Function1 {


        /// <summary>
        /// 参数数组
        /// </summary>
        /// <param name="vals"></param>
        /// <returns></returns>
        /// 这个示例用关键字 params 定义函数 SumVals()，该函数可以接受任意个 int 参数(但不接受其他类型的参数)：
        public static int SumVals(params int[] vals) {
            int sum = 0;
            foreach (int val in vals) {
                sum += val;
            }
            return sum;
        }

    }
}