using NUnit.Framework;

using chapter2_5_1.excel;
using Dll.log4c;

namespace UnitTest {

    public class Demo1Test {

        [Test]
        public void Test1() {
            Demo1.test();
        }

        [Test]
        public void Test2() {
            Demo1.test1();
        }

        // 生成路径： E:\Code\C#_code\RiderLearning\GoatRider\UnitTest\bin\Debug\netcoreapp3.0
        [Test]
        public void Test3() {
            Demo1.test3();
        }

    }
}