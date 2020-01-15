using Dll.log4c;

namespace chapter1_3_1.item03 {

    public class Cat :IShout{

        public void shout() {
            Log4C.log.Debug($"我是猫：喵喵喵！");
        }
    }
}