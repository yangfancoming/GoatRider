
using chapter3_4_1;
using NUnit.Framework;

namespace UnitTest {

    public class QuartzsTest {

        [Test]
        public void test() {
            Quartzs.RunProgram().GetAwaiter().GetResult();
        }


        [Test]
        public void test2() {
//            Log4C.log.Debug($"Created at {task}");
        }
    }
}