using System;
using System.Xml;
using Dll.log4c;

namespace chapter3_6_4 {
    class Program {


        static void Main(string[] args) {
//            test1();
            test2();
        }

        //XML转换成JSON  
        public static void test1() {

            XmlDocument document = new XmlDocument();//XmlDocument对象     
            document.Load(@"E:\Code\C#_code\RiderLearning\GoatRider\chapter3-6-4\student.xml"); //加载Xml文件
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(document);//转换成json文件
            Log4C.log.Debug(json);
            System.IO.File.AppendAllText(@"D:\123\Books.json",json);//保存
        }

        //JSON转换成XML
        public static void test2() {
            string json = System.IO.File.ReadAllText(@"D:\123\Books.json");           //json文件
            XmlDocument document = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json);      //转换成XML文件   
        }
    }
}