using System.Linq;
using DataBase;
using Dll;

namespace chapter1_6_1 {

    public class Linq2 {

        // 分组的结果集实现了 LINQ 接口 IGrouping，它支持 Key 属性。我们总是要以某种方式引用 Key属性，
        // 来处理组合的结果，因为该属性表示创建数据中的每个组时使用的条件。
        public static void test1() {
            var queryResults =
                    from c in BaseData.customers
                    group c by c.Region into cg
                    select new { TotalSales = cg.Sum(c => c.Sales), Region = cg.Key };

            queryResults.ForEach(x => Log4C.log.Debug(x));
        }


        // 演示 take 取出前N个
        // 演示 skip 跳过前N个
        public static void test2() {
            var enumerable = BaseData.customers.OrderByDescending(x=>x.Sales).Select(c=>new { c.ID, c.City, c.Country, c.Sales });
            enumerable.ForEach(x => Log4C.log.Debug(x));
            Log4C.log.Debug("---------演示 take ---------");
            var take = enumerable.Take(5);
            take.ForEach(x => Log4C.log.Debug(x));

            Log4C.log.Debug("---------演示 skip ---------");
            var skip = enumerable.Skip(5);
            skip.ForEach(x => Log4C.log.Debug(x));
        }


        //使用FirstOrDefault()时，当查询条件不满足时，将为customers 列表返回默认元素，
        //而使用First()时则是返回null(因为这些元素的类型未知)
        public static void test3() {
            var list = BaseData.customers.Select(c=>new { c.City, c.Country, c.Region });
            var first = list.First(c => c.Region == "Africa");
            Log4C.log.Debug("---------演示 first ---------" + first);

            var firstOrDefault = list.FirstOrDefault(c => c.Region == "Antartica");
            Log4C.log.Debug("---------演示 FirstOrDefault ---------" + firstOrDefault);


            var temp = list.First(c => c.Region == "Antartica");
            Log4C.log.Debug("---------演示 null ---------" + temp);
        }


    }
}