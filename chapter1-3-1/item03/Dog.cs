using Dll.log4c;

namespace chapter1_3_1.item03 {

    public class Dog : IShout{

        public void shout() {
            Log4C.log.Debug($"我是狗：汪汪汪！");
        }
    }
}