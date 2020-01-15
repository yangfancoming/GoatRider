using Dll.log4c;

namespace chapter1_3_1.item01 {

    public class Cat :Pet,IClimbTree,ICatchMice {
        public void ClimbTree() {
            Log4C.log.Debug("我是cat 我会爬树");
        }

        public void CatchMice() {
            Log4C.log.Debug("我是cat 我会抓老鼠");
        }



    }
}