using System.Collections.Generic;

namespace chapter1_7_1.yield {

    public class Yield3 {

//一个返回类型为IEnumerable<int>，其中包含三个yield return  返回结果：1,2,3
        public static IEnumerable<int> enumerableFuc1(){
            yield return 1;
            yield return 2;
            yield return 3;
        }

//一个返回类型为IEnumerable<int>，其中包含三个yield return  返回结果：1
        public static IEnumerable<int> enumerableFuc2()
        {
            yield return 1;
            yield break;
            yield return 2;
            yield return 3;
        }


    }
}