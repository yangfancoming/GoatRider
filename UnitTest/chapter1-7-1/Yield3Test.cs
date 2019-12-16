using System.Collections.Generic;
using chapter1_7_1.yield;
using Dll.log4c;
using NUnit.Framework;

namespace UnitTest {

    public class Yield3Test {

        [Test]
        public void Test1() {
            IEnumerable<int> findBobs1 = Yield3.enumerableFuc1();
            Log4C.log.Debug(findBobs1);
        }

        [Test]
        public void Test2() {
            IEnumerable<int> findBobs2 = Yield3.enumerableFuc2();
            Log4C.log.Debug(findBobs2);
        }

    }

}