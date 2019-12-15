using System.Linq;
using Dll;

namespace chapter1_6_1
{
    class Program
    {
        static void Main() {
            test1();
//            test2();
        }

        // Linq 语法 基础1
        public static void test1()        {
            var queryResults =
                // 获取数据源 ( string[] )
                from n in BaseData.names
                // 定义查询条件(每条记录以字符串S开头)
                where n.StartsWith("S")
                // 返回结果
                select n;
            queryResults.ForEach(x => Log4C.log.Debug(x));
        }

        // Linq 语法 基础2   简化方式
        public static void test2()        {
            // 在指定数据源中  定义查询条件(每条记录以字符串S开头)
            var queryResults = BaseData.names.Where(n => n.StartsWith("S"));
            queryResults.ForEach(x => Log4C.log.Debug(x));
        }


    }
}