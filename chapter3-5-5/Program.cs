using System;

namespace chapter3_5_5 {
    class Program {
        static void Main(string[] args) {
            FileSystemWatcher1.WatcherStrat(@"D:\123", "*.*");
            Console.ReadKey();
        }
    }
}