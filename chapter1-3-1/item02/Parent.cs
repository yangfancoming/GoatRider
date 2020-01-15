using Dll.log4c;

namespace chapter1_3_1.item02 {

    public class Parent {

        public void F() {
            Log4C.log.Debug("Parent.F()");
        }

        public virtual void G()  {//抽象方法
            Log4C.log.Debug("Parent.G()");
        }

        public int Add(int x, int y) {
            return x + y;
        }

        //重载(overload)Add函数
        public float Add(float x, float y)  {
            return x + y;
        }

    }
}