using chapter1_3_1.item02;
using chapter1_3_1.item03;
using Dll.log4c;
using Cat = chapter1_3_1.item01.Cat;

namespace chapter1_3_1 {

    class Program {

        public static void Main(string[] args) {
//            item02();
            item03();
        }

        public static void item03() {
//            IShout iShout = new item03.Cat();
            IShout iShout = new item03.Dog();
            iShout.shout();
        }

        public static void item02() {
            Parent parent = new ChildOne();
            //调用Parent.F()
            parent.F();
            //实现多态
            parent.G();

            //重载(overload)
            Log4C.log.Debug(parent.Add(1, 2));
            Log4C.log.Debug(parent.Add(3.4f, 4.5f));
        }


        public static void item01() {
            //实例化一个猫咪对象
            Cat cat = new Cat();
            cat.Eat();
            cat.ClimbTree();
            cat.CatchMice();
        }
    }
}