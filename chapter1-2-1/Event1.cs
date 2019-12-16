using Dll.log4c;

namespace chapter1_2_1 {


    // 函数指针
    public class Event1 {

        public delegate void GreetingDelegate(string name);

        private static void EnglishGreeting(string name) {
            Log4C.log.Debug("Good Morning, " + name);
        }

        private static void ChineseGreeting(string name){
            Log4C.log.Debug("早上好, " + name);
        }

        private static void GreetPeople(string name, GreetingDelegate MakeGreeting) {
            MakeGreeting(name);
        }

        public static void app() {
            GreetPeople("Liker", EnglishGreeting);
            GreetPeople("李志中", ChineseGreeting);
        }
    }
}