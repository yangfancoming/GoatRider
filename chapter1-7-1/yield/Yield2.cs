using System.Collections;
using System.Collections.Generic;

namespace chapter1_7_1.yield {

    public class Yield2 {


        // 对比 FindBobs1() 和 FindBobs2() 两个方法就能知道 yield 简化的都是哪些代码
        // Yield 的总结就是  你不用再new一个集合添加数据后 返回了  使用 Yield 就可以直接返回想要的结果类型集合

        /**
        这是我们平常的思路。但是这样做就有个问题。
        这儿要new一个List,或者任何实现了IEnumerable接口的类型。
        这样也太麻烦了吧。要知道IEnumerable是一个常用的返回类型。
        每次使用都要new一个LIst,或者其他实现了该接口的类型。与其使用其他类型，
        不如我们自己定制一个实现了IEnumerable接口专门用来返回IEnumerable类型的类型。
        我们自己定制也很麻烦。所以微软帮我们定制好了。这个类是什么，那就是yield关键字这个语法糖。
        */
        public static IList<string> FindBobs1(IEnumerable<string> names){
            var bobs = new List<string>();
            foreach(var currName in names){
                if(currName == "Bob")
                    bobs.Add(currName);
            }
            return bobs;
        }


        public static IEnumerable<string> FindBobs2(IEnumerable<string> names){
            foreach(var currName in names){
                if(currName == "Bob")
                    yield return currName;
            }
        }

    }
}