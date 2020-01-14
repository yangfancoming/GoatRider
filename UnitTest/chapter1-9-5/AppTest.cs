

using chapter1_9_5;
using Dll.log4c;
using NUnit.Framework;

namespace UnitTest {

    public class AppTest {


        [Test]
        public void test() {

            App.test1();
            Log4C.log.Debug("数组中的最大值" );
        }


    }
}