using System;
using Dll.log4c;

namespace chapter1_5_1 {

    class Program {


        static void Main(string[] args) {
            Enum1.weekday(Enum1.Weekdays.Tues);
            // Parse() 第一个是要使用的枚举类型，第二个是要转换的枚举成员的字符串，第三个是bool类型，定义转换时是否忽略大小写
            Enum1.Weekdays day = (Enum1.Weekdays)Enum.Parse(typeof(Enum1.Weekdays), "Mon", true);
            Log4C.log.DebugFormat("Mon的值是{0}",(int)day);

            foreach (Enum1.Weekdays temp in Enum.GetValues(typeof(Enum1.Weekdays))){
                Log4C.log.Debug((int)temp + ":" + temp);//int可以获取枚举值
            }
        }

        public class MyClass1 {
            // 默认情况下枚举中每个元素的基本类型都是int。可以使用冒号指定另一种整数类型。
            enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        }


        public class MyClass2 {
            // 默认情况下，第一个枚举值具有值0，并且每个连续枚举数的值将增加1。
            // 枚举数可以使用初始值设定项来替代默认值。
            // 若设置某一枚举数的值，之后的枚举数仍然按1递增。
            enum Day : byte {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};
        }

        public class MyClass3 {
//            每个枚举都有一个基础类型，该基础类型可以是除char外的任何整数类型，枚举元素的默认基础类型是int。
//            已批准的枚举类型有byte、sbyte、short、ushort、int、uint、long或ulong。
//            可以为枚举类型的枚举器列表中的元素分配任何值，也可以使用计算值。
            enum Day {Sat=1, Sun, Mon, Tue=5, Wed, Thu, Fri};
        }

    }
}