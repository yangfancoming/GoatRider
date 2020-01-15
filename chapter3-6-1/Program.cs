using Dll.log4c;

namespace chapter3_6_1 {

    class Program {

        static void Main(string[] args) {
            Log4C.log.Debug("Starting up");
            Xml1.parse(@"E:\Code\C#_code\RiderLearning\GoatRider\chapter3-6-1\student.xml");
        }
    }
}