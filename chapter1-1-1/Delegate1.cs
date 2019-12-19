using System.Collections.Generic;
using System.Linq;

namespace chapter1_1_1 {

    /**
     * 从下面的传统方法中可以看出问题
     *     第一对函数示例：大于和小于 方法 只是一个大于号/小于号的不同
     *     第二对函数示例：大于2的元素和偶数 也只是一个 if 条件的不同
     * 却要两个函数来实现 因为 无法封装在一个方法里  这样就造成大量的代码重复
     *
     * 不变部分的代码 要能够重复利用，我们只要关心变化部分的代码，
     * 那么能否把变化部分的代码 当做参数传递呢？   委托由此应运而生！ 想见 Delegate2
     *
    */
    public static class Delegate1 {

        // 获取数组中的最大值  linq 方式
        public static int getMax(List<int> nums) {
            return nums.Max();
        }

        // 获取数组中的最大值  传统方式
        public static int getMax2(List<int> nums) {
            int max = nums[0];
            foreach (var num in nums) {
                if (num>max)  max = num;
            }
            return max;
        }

        // 获取数组中的最小值  传统方式
        public static int getMin2(List<int> nums) {
            int max = nums[0];
            foreach (var num in nums) {
                if (num<max)  max = num;
            }
            return max;
        }

        // 遍历数组 获取所有大于 2 的元素  传统方式
        public static List<int> for1(List<int> nums) {
            List<int> result = new List<int>();
            foreach (var num in nums) {
                if (num>2 )  result.Add(num);
            }
            return result;
        }

        // 遍历数组 获取所有 偶数 元素  传统方式
        public static List<int> for2(List<int> nums) {
            List<int> result = new List<int>();
            foreach (var num in nums) {
                if (num%2==0)  result.Add(num);
            }
            return result;
        }
    }
}