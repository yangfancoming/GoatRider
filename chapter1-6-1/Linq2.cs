using System.Linq;
using DataBase;
using Dll.log4c;

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

        // 演示 集运算符  Intersect()  Except() Union()
        public static void test4() {
            // 用户表id
            var customerIDs = BaseData.customers.Select(c=>c.ID);
            // 订单表id
            var orderIDs = BaseData.orders.Select(c=>c.ID);
            Log4C.log.Debug("---------获取两个表的交集  Intersect() ---------" );
            var customersWithOrders = customerIDs.Intersect(orderIDs);
            customersWithOrders.ForEach(x => Log4C.log.Debug(x));

            Log4C.log.Debug("---------获取两个表的差集 Except()---------" );
            var ordersNoCustomers = orderIDs.Except(customerIDs);
            ordersNoCustomers.ForEach(x => Log4C.log.Debug(x));

            // 注意，ID 的输出顺序与它们在顾客和订单列表中的顺序相同，只是删除了重复的项。
            Log4C.log.Debug("---------获取两个表的并集 Union()---------" );
            var allCustomerOrderIDs = orderIDs.Union(customerIDs);
            allCustomerOrderIDs.ForEach(x => Log4C.log.Debug(x));
        }

        // 演示 Join查询
        public static void test5() {
            var queryResults =
                from c in BaseData.customers
                // on 关键字在关键字段 ID 的后面，equals 关键字指定另一个集合中的对应字段。查询结果仅包含两个集中ID 字段值相同的对象数据
                join o in BaseData.orders on c.ID equals o.ID
                select new { c.ID, c.City, SalesBefore = c.Sales, NewOrder = o.Amount, SalesAfter = c.Sales+o.Amount };
            queryResults.ForEach(x => Log4C.log.Debug(x));
        }
    }
}