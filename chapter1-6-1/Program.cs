using System.Linq;
using Dll;

namespace chapter1_6_1
{
    class Program
    {
        static void Main() {
            test1();
        }

        public static void test1()        {
            var queryResults =
                from n in BaseData.names
                where n.StartsWith("S")
                select n;

            Log4C.log.Debug("Names beginning with S:");
            queryResults.ForEach(x => Log4C.log.Debug(x));
            Log4C.log.Debug("Program finished ");
        }

    }
}