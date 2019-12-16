using System.Collections;
using System.Collections.Generic;

namespace chapter1_7_1.yield {

    public class Yield2 {


        // 对比 FindBobs1() 和 FindBobs2() 两个方法就能知道 yield 简化的都是哪些代码
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