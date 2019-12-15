using System.Linq;
using Dll;
using DataBase;

namespace chapter1_6_1
{
    class Program
    {
        static void Main() {
//            test1();
//            test2();
//            test3();
//            test4();
//            test5();
            test6();
        }

        // Linq 语法 基础1
        public static void test1()        {
            var result =
                // 获取数据源 ( string[] )
                from n in BaseData.names
                // 定义查询条件(每条记录以字符串S开头)
                where n.StartsWith("S")
                // 返回结果
                select n;
            result.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 Where 字符串查询条件 简化方式
        public static void test2() {
            // 在指定数据源中  定义查询条件(每条记录以字符串S开头)
            var result = BaseData.names.Where(n => n.StartsWith("S"));
            result.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 OrderBy 查询结果排序功能
        public static void test3() {
            var result = BaseData.names.Where(n => n.StartsWith("S")).OrderBy(n=>n);
            result.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 Where 数字查询条件
        public static void test4() {
            // 未排序输出结果： 6 5 4
            var result1 = BaseData.nums.Where(n => n>3 );
            result1.ForEach(x => Log4C.log.Debug(x));
            // 排序后输出结果： 4 5 6
            var result2 = BaseData.nums.Where(n => n>3 ).OrderBy(n=>n);
            result2.ForEach(x => Log4C.log.Debug(x));
        }


        // 演示
        public static void test5() {
            var result = BaseData.nums.Where(n => n>3 );
            result.ForEach(x => Log4C.log.Debug(x));
            Log4C.log.Debug("记录数" + result.Count());
            Log4C.log.Debug("最大值" + result.Max());
            Log4C.log.Debug("最小值" + result.Min());
            Log4C.log.Debug("平均数" + result.Average());
            Log4C.log.Debug("求和" + result.Sum());
        }

        public static void test6() {
            var result = BaseData.customers.Where(c => c.Region == "Asia");
            result.ForEach(x => Log4C.log.Debug(x));
        }

    }
}