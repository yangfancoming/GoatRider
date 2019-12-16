using Dll.log4c;

namespace chapter2_1_1.temp {
    public class A {

        public delegate void RaiseEventHandler(string hand); //首领A举杯事件
        public delegate void FallEventHandler(); //首领A摔杯事件

        public event RaiseEventHandler RaiseEvent;
        public event FallEventHandler FallEvent;

        public void Raise(string hand){
            Log4C.log.Debug("首领A"+hand+"手举杯");
            RaiseEvent(hand);// 调用举杯事件，传入左或右手作为参数
        }

        public void Fall() {
            Log4C.log.Debug("首领A摔杯"); // 调用摔杯事件
            FallEvent();
        }
    }
}