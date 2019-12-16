using Dll.log4c;

namespace chapter1_0_2 {

    public static class MyExtension {

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        ///
        /// 为什么这里会有一个this关键字，做什么用？其实这就是扩展方法！
        /// 这个扩展方法在静态类中声明，定义一个静态方法，其中第一个参数定义可它的扩展类型。Foo()方法扩展了String类，
        /// 因为它的第一个参数定义了String类型，为了区分扩展方法和一般的静态方法，扩展方法还需要给第一个参数使用this关键字。
        ///
        /// 归纳：扩展方法可以写入最初没有提供该方法的类中。还可以把方法添加到实现某个接口的任何类中，这样多个类可以使用相同的实现代码。
        public static void Foo(this string s) {
            Log4C.log.DebugFormat("Foo invoked for {0}", s);
        }
    }
}