namespace chapter2_1_1.temp {
    public class App {

        public static void app() {
            A a = new A(); // 定义首领A
            B b = new B(a); // 定义部下B
            C c = new C(a); // 定义部下C
            a.Raise("左");
            a.Raise("右");
            a.Fall();
        }
    }
}