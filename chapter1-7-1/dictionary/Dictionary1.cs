using System.Collections.Generic;
using Dll.log4c;

namespace chapter1_7_1.dictionary {

    public class Dictionary1 {

        private static Dictionary<int,string> myDictionary = new Dictionary<int,string>();

        public static void test() {
            myDictionary.Add(1,"C#");
            myDictionary.Add(2,"C++");
            myDictionary.Add(3,"ASP.NET");
            myDictionary.Add(4,"MVC");

            // 获取元素
            var s = myDictionary[1];
            Log4C.log.Debug(s);

            // 判断元素
            if(myDictionary.ContainsKey(1)){
                Log4C.log.DebugFormat("3、 通过Key查找元素   Key---{0},Value---{1}","1", s);
            }

            foreach (var kvp  in myDictionary) {
                Log4C.log.DebugFormat(" 4、通过KeyValuePair遍历元素     Key = {0}, Value = {1}",kvp.Key, kvp.Value);
            }

            Dictionary<int,string>.KeyCollection keyCol = myDictionary.Keys;
            foreach (var key in keyCol) {
                Log4C.log.DebugFormat("5、仅遍历键 Keys 属性    Key = {0}", key);
            }

            Dictionary<int,string>.ValueCollection valueCol=myDictionary.Values;
            foreach (var value in valueCol) {
                Log4C.log.DebugFormat("6、仅遍历值 Valus属性 Value = {0}", value);
            }


            // 删除元素
            myDictionary.Remove(1);
            if(myDictionary.ContainsKey(1)){
                Log4C.log.DebugFormat(" 7、通过Remove方法移除指定的键值 Key:{0},Value:{1}","1", s);
            }
            else{
                Log4C.log.DebugFormat(" 7、通过Remove方法移除指定的键值 不存在 Key : 1");
            }
        }

    }
}