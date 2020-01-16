using System;

namespace chapter3_5_5 {
    class Program {
        static void Main(string[] args) {
            FileSystemWatcher1.initWatcher(@"D:\123");
            FileSystemWatcher1.startWatcher();
            Console.ReadKey();
        }
    }
}