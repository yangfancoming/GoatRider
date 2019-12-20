using System.Collections.Generic;
using chapter1_1_1;
using Dll.log4c;
using NUnit.Framework;


namespace UnitTest {

    public class Delegate2Test {

        List<int> list = new List<int>(){1,2,3,4,5};


        [Test]
        public void Test1() {
            Log4C.log.Debug("数组中的最大值" + Delegate2.getMaxMinTest1(list,Delegate2.getMax2));
            Log4C.log.Debug("数组中的最小值" + Delegate2.getMaxMinTest1(list,Delegate2.getMin2));
        }

        [Test]
        public void Test2() {

        }

    }
}