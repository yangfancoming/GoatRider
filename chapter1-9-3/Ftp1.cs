

using System.IO;
using System.Net;
using FluentFTP;

namespace chapter1_9_3 {


    public class Ftp1 {

        /// <summary>
        /// FTP服务器文件下载到本地
        /// </summary>
        /// <param name="ftphost">ftp地址：ftp://192.168.1.200/</param>
        /// <param name="user">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <param name="saveLocalPath">下载到本地的地址：d:\\doctument\\0F5GAHRT4A484TRA5D15FEA.pdf</param>
        /// <param name="downPath">将要下载的文件在FTP上的路径：/DownFile/0F5GAHRT4A484TRA5D15FEA</param>
        public static void DownloadFile(string ftphost, string user, string password, string saveLocalPath, string downPath)
        {
            using (FtpClient conn = new FtpClient())
            {
                conn.Host = ftphost;
                conn.Credentials = new NetworkCredential(user, password);

                byte[] outBuffs;
                bool flag = conn.Download(out outBuffs, downPath);

                string s = saveLocalPath.Substring(0, saveLocalPath.LastIndexOf('\\'));
                Directory.CreateDirectory(s);//如果文件夹不存在就创建它

                FileStream fs = new FileStream(saveLocalPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Write(outBuffs, 0, outBuffs.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }

          }


        /// <summary>
        /// 将文件上传到FTP服务器
        /// </summary>
        /// <param name="ftphost">ftp地址</param>
        /// <param name="user">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        /// <param name="localPath">本地文件所在的路径："D:\doctument\test.pdf"</param>
        public static bool UploadFile(string ftphost, string user, string password, string localPath)
        {
                using (FtpClient conn = new FtpClient())
                {
                    conn.Host = ftphost;
                    conn.Credentials = new NetworkCredential(user, password);
                    using (FileStream fs = new FileStream(localPath, FileMode.Open))
                    {
                        string path = localPath.Substring(localPath.LastIndexOf('\\') + 1);       //取文件名
                        bool flag = conn.Upload(fs, path);
                        return flag;
                    }
                }
        }


    }
}