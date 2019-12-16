using System.Collections.Generic;
using chapter1_7_1.yield;
using Dll.log4c;
using NUnit.Framework;

namespace UnitTest {

    public class Yield2Test {

        public string[] temp = {"hha", "gag", "Bob"};

        [Test]
        public void Test1() {
            IList<string> findBobs1 = Yield2.FindBobs1(temp);
            Log4C.log.Debug(findBobs1);
        }

        [Test]
        public void Test2() {
            IEnumerable<string> findBobs2 = Yield2.FindBobs2(temp);
            Log4C.log.Debug(findBobs2);
        }

    }

}