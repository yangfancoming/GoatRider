using chapter1_9_3;
using NUnit.Framework;

namespace UnitTest {


    public class Ftp1Test {

        string host = "ftp://192.168.211.128/";

        [Test]
        public void upLoad() {
            Ftp1.UploadFile(host,"test","test","D:\\123\\2222\\123.txt");
        }

        /// <summary>
        /// FTP服务器文件下载到本地
        /// </summary>
        /// <param name="ftphost">ftp地址：ftp://192.168.1.200/</param>
        /// <param name="user">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <param name="saveLocalPath">下载到本地的地址：d:\\doctument\\0F5GAHRT4A484TRA5D15FEA.pdf</param>
        /// <param name="downPath">将要下载的文件在FTP上的路径：/DownFile/0F5GAHRT4A484TRA5D15FEA</param>
        [Test]
        public void Test1() {
            Ftp1.DownloadFile(host,"test","test","D:\\123\\2222\\222.txt","/123.txt");
        }


    }
}