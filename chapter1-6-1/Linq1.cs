using System.Linq;
using DataBase;
using Dll.log4c;

namespace chapter1_6_1 {

    public class Linq1 {

        // Linq 语法 基础1
        public static void test1() {
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

        /** 演示 OrderBy 多级排序  即使国家的顺序被反转了，印度和中国的城市仍按升序排序。
                 from c in customers
                 orderby c.Region, c.Country descending, c.City
                 select new { c.ID, c.Region, c.Country, c.City }
        */
        public static void test33() {
            var result = BaseData.customers.OrderBy(c=> c.Region ).ThenByDescending(c => c.Country).ThenBy(c => c.City).Select(c => new { c.ID, c.Region, c.Country, c.City });;
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

        // 演示 聚合函数
        public static void test5() {
            var result = BaseData.nums.Where(n => n>3 );
            result.ForEach(x => Log4C.log.Debug(x));
            Log4C.log.Debug("记录数" + result.Count());
            Log4C.log.Debug("最大值" + result.Max());
            Log4C.log.Debug("最小值" + result.Min());
            Log4C.log.Debug("平均数" + result.Average());
            Log4C.log.Debug("求和" + result.Sum());
        }

        // 演示 LINQ 操作实体类集合1
        public static void test6() {
            var result = BaseData.customers.Where(c => c.Region == "Asia");
            result.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 LINQ 操作实体类集合2  投影操作
        /**
            如果熟悉 SQL 数据查询语言中的 SELECT 关
            键字，就很熟悉从数据对象中选择某个字段的操作，而不是选择整个对象。在 LINQ 中，也可以这
            么做，例如，前面的例于只从Customer 列表中选挥City 字段，只需修改查询语句中的select 子句，
            以便仅引用City 属性
        * @Date:   2019/12/15
        */
        public static void test7() {
            var result = BaseData.customers.Where(c => c.Region == "North America").Select(c=> new {c.City, c.Country, c.Sales} );
            result.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 Distinct 去重
        public static void test8() {
            var result = BaseData.customers.Select(c => c.Region);
            result.ForEach(x => Log4C.log.Debug(x));
            Log4C.log.Debug("-----------------------");
            var result2 = result.Distinct();
            result2.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 Any 条件判断： 若集合内有一条记录满足条件那么结果就是true 否则为 false
        public static void test9() {
            var result = BaseData.customers.Any(c => c.Country == "USA");
            if (result) {
                Log4C.log.Debug("Some customers are in the USA");
            }
            else {
                Log4C.log.Debug("No customers are in the USA");
            }
        }

        // 演示 All 条件判断： 集合内必须所有记录都要满足条件 结果才是true 否则 false
        public static void test10() {
            bool allAsia = BaseData.customers.All(c => c.Region == "Asia");
            if (allAsia) {
                Log4C.log.Debug("All customers are in Asia");
            }
            else {
                Log4C.log.Debug("Not all customers are in Asia");
            }
        }
    }
}