using chapter1_9_7;
using Dll.log4c;
using NUnit.Framework;

namespace UnitTest {
    public class HttpClient1Test {

        [Test]
        public void test() {
            HttpClient1.test1();
        }


        [Test]
        public void test2() {
            var task = HttpClient1.test2();
            Log4C.log.Debug($"Created at {task}");
        }
    }
}