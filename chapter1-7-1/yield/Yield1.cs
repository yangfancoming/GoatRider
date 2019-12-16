using System.Collections;

namespace chapter1_7_1.yield {

    public class Yield1 {

        public static IEnumerable SimpleList(){
            yield return "string 1";
            yield return "string 2";
            yield return "string 3";
        }


    }
}