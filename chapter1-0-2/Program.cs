using System;

namespace chapter1_0_2 {

    class Program {


        static void Main() {
            int sum1 = Function1.SumVals(1, 5, 2, 9, 8);
            Console.WriteLine("Summed Values = {0}", sum1);

            int sum2 = Function1.SumVals(1, 5);
            Console.WriteLine("Summed Values = {0}", sum2);
        }
    }
}