using System.IO;

namespace GoatTools
{
    public class FileUtil
    {
        //CopyFile(files[j].FullName, textBox5.Text + "\\"+files[j].Name, 1024);
        FileStream FormerOpen;
        FileStream ToFileOpen;
        public void CopyFile(string FormerFile, string toFile, int SectSize) //p1=源文件全路径 p2=目的文件全路径  功能：将p1文件拷贝到p2处
        {
            FileStream fileToCreate = new FileStream(toFile, FileMode.Create);		//创建目的文件，如果已存在将被覆盖
            fileToCreate.Close();										//关闭所有资源
            fileToCreate.Dispose();										//释放所有资源
            FormerOpen = new FileStream(FormerFile, FileMode.Open, FileAccess.Read);//以只读方式打开源文件
            ToFileOpen = new FileStream(toFile, FileMode.Append, FileAccess.Write);	//以写方式打开目的文件
            //根据一次传输的大小，计算传输的个数
            int FileSize;												//要拷贝的文件的大小
            //如果分段拷贝，即每次拷贝内容小于文件总长度
            if (SectSize < FormerOpen.Length)
            {
                byte[] buffer = new byte[SectSize];							//根据传输的大小，定义一个字节数组
                int copied = 0;										//记录传输的大小
                while (copied <= ((int)FormerOpen.Length - SectSize))			//拷贝主体部分
                {
                    FileSize = FormerOpen.Read(buffer, 0, SectSize);			//从0开始读，每次最大读SectSize
                    FormerOpen.Flush();								//清空缓存
                    ToFileOpen.Write(buffer, 0, SectSize);					//向目的文件写入字节
                    ToFileOpen.Flush();									//清空缓存
                    ToFileOpen.Position = FormerOpen.Position;				//使源文件和目的文件流的位置相同
                    copied += FileSize;									//记录已拷贝的大小
                }
                int left = (int)FormerOpen.Length - copied;						//获取剩余大小
                FileSize = FormerOpen.Read(buffer, 0, left);					//读取剩余的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, left);							//写入剩余的部分
                ToFileOpen.Flush();									//清空缓存
            }
            //如果整体拷贝，即每次拷贝内容大于文件总长度
            else
            {
                byte[] buffer = new byte[FormerOpen.Length];				//获取文件的大小
                FormerOpen.Read(buffer, 0, (int)FormerOpen.Length);			//读取源文件的字节
                FormerOpen.Flush();									//清空缓存
                ToFileOpen.Write(buffer, 0, (int)FormerOpen.Length);			//写放字节
                ToFileOpen.Flush();									//清空缓存
            }
            FormerOpen.Close();										//释放所有资源
            ToFileOpen.Close();										//释放所有资源
            // MessageBox.Show("文件复制完成");
        }

    }
}

//获取当前进程的完整路径，包含文件名(进程名)。 //result: X:\xxx\xxx\xxx.exe (.exe文件所在的目录+.exe文件名)
//string str = this.GetType().Assembly.Location;


////获取新的 Process 组件并将其与当前活动的进程关联的主模块的完整路径，包含文件名(进程名)。
//string str = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
////result: X:\xxx\xxx\xxx.exe (.exe文件所在的目录+.exe文件名)

////获取和设置当前目录（即该进程从中启动的目录）的完全限定路径。
//string str = System.Environment.CurrentDirectory;
////result: X:\xxx\xxx (.exe文件所在的目录)

////获取当前 Thread 的当前应用程序域的基目录，它由程序集冲突解决程序用来探测程序集。
//string str = System.AppDomain.CurrentDomain.BaseDirectory;
////result: X:\xxx\xxx\ (.exe文件所在的目录+"\")

////获取和设置包含该应用程序的目录的名称。(推荐)
//string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
////result: X:\xxx\xxx\ (.exe文件所在的目录+"\")

////获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
//string str = System.Windows.Forms.Application.StartupPath;
////result: X:\xxx\xxx (.exe文件所在的目录)

////获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
//string str = System.Windows.Forms.Application.ExecutablePath;
////result: X:\xxx\xxx\xxx.exe (.exe文件所在的目录+.exe文件名)



//4              string str = "获取文件的全路径：" + Path.GetFullPath(filePath);   //-->C:\JiYF\BenXH\BenXHCMS.xml
//16             str = "获取文件所在的目录：" + Path.GetDirectoryName(filePath); //-->C:\JiYF\BenXH
//18             str = "获取文件的名称含有后缀：" + Path.GetFileName(filePath);  //-->BenXHCMS.xml
//20             str = "获取文件的名称没有后缀：" + Path.GetFileNameWithoutExtension(filePath); //-->BenXHCMS
//22             str = "获取路径的后缀扩展名称：" + Path.GetExtension(filePath); //-->.xml
//24             str = "获取路径的根目录：" + Path.GetPathRoot(filePath); //-->C:\