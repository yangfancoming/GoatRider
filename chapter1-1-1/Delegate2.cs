using System.Collections.Generic;

namespace chapter1_1_1 {

    public static class Delegate2 {

        /**
         * 完成了 把变化部分的代码 当做参数传递
        */

        // 定义函数指针
        public delegate bool MyDelegate(int num);

        // 给函数指针赋值
        public static readonly MyDelegate getMax2 = Max2;
        public static readonly MyDelegate getMin2 = Min2;

        private static bool Max2(int num) {
            return num > 2;
        }
        private static bool Min2(int num) {
            return num < 2;
        }

        // 将函数指针作为参数传递
        public static int getMaxMinTest1(List<int> nums,MyDelegate myDelegate) {
            int max = nums[0];
            foreach (var num in nums) {
                if (myDelegate(num))  max = num;
            }
            return max;
        }

//        public static int getMaxTest2(List<int> nums) {
//            int max = nums[0];
//            foreach (var num in nums) {
//                if (getMin2(num))  max = num;
//            }
//            return max;
//        }

//        // 遍历数组 获取所有大于 2 的元素  传统方式
//        public static List<int> for1(List<int> nums) {
//            List<int> result = new List<int>();
//            foreach (var num in nums) {
//                if (num>2 )  result.Add(num);
//            }
//            return result;
//        }
//
//        // 遍历数组 获取所有 偶数 元素  传统方式
//        public static List<int> for2(List<int> nums) {
//            List<int> result = new List<int>();
//            foreach (var num in nums) {
//                if (num%2==0)  result.Add(num);
//            }
//            return result;
//        }
    }
}