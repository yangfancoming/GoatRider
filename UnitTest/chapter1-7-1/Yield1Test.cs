using Dll.log4c;
using NUnit.Framework;

using chapter1_7_1.yield;

namespace UnitTest {

    public class Yield1Test {


        [Test]
        public void Test1() {
            foreach (string item in Yield1.SimpleList())
                Log4C.log.Debug(item);
        }



    }
}