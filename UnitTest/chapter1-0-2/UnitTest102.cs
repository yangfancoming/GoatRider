using System;
using System.Linq;
using chapter1_0_2;
using NUnit.Framework;

namespace UnitTest {

    public class UnitTest102 {

        [SetUp]
        public void Setup() {

        }

        [Test]
        public void Test1() {
            string s = "Hello";
            s.Foo();
        }

        [Test]
        public void Test2() {
            int[] myArray = { 1, 8, 3, 6, 2, 5, 9, 3, 0, 2 };
            var max = myArray.Select(n=>n).Max();
            Console.WriteLine("The maximum value in myArray is {0}", max);
        }
    }
}