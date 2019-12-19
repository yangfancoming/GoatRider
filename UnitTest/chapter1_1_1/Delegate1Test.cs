using System.Collections.Generic;
using chapter1_1_1;
using Dll.log4c;
using NUnit.Framework;


namespace UnitTest {

    public class Delegate1Test {

        List<int> list = new List<int>(){1,2,3,4,5};

        [Test]
        public void Test1() {
            Log4C.log.Debug("数组中的最大值" + Delegate1.getMax(list));
        }

        [Test]
        public void Test2() {
            Log4C.log.Debug("数组中的最大值" + Delegate1.getMax2(list));
            Log4C.log.Debug("数组中的最小值" + Delegate1.getMin2(list));
        }


        [Test]
        public void Test4() {
            List<int> for1 = Delegate1.for1(list);
            Log4C.log.Debug("数组中大于2的元素" + for1.Count);

            List<int> for2 = Delegate1.for2(list);
            Log4C.log.Debug("数组中偶数的元素" + for2.Count);
        }
    }
}