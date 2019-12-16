using Dll.log4c;

namespace chapter2_1_1.temp {
    public class C {

        public C(A a)
        {
            a.RaiseEvent += a_RaiseEvent; // 订阅举杯事件
            a.FallEvent += a_FallEvent; // 订阅摔杯事件
        }
        public void Attack()
        {
            Log4C.log.Debug("部下C发起攻击"); //
        }

        void a_RaiseEvent(string hand)
        {
            if (hand.Equals("右"))
            {
                Attack();
            }
        }
        void a_FallEvent()
        {
            Attack();
        }
    }
}