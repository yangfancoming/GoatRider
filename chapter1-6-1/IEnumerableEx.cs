using System;
using System.Collections.Generic;

namespace chapter1_6_1 {

    public static class IEnumerableEx{
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action){
            foreach(var item in items){
                action(item);
            }
        }
    }
}
