using System.IO;
using Dll.log4c;

namespace chapter3_5_5 {

    public static class FileSystemWatcher1 {

       private static readonly FileSystemWatcher watcher = new FileSystemWatcher();

        public static void startWatcher() {
            watcher.EnableRaisingEvents = true; // 收到改变通知时是否提交事件。如果EnableRaisingEvents属性设为假，对象将不会提交改变事件。如果设为真，它将提交改变事件
        }

        public static void stopWatcher() {
            watcher.EnableRaisingEvents = false;
        }

        /**
        若要监视所有文件中的更改，请将 Filter 属性设置为空字符串 ("") 或使用通配符（“*.*”）。
        若要监视特定的文件，请将 Filter 属性设置为该文件名。
        例如，若要监视文件 MyDoc.txt 中的更改，请将 Filter 属性设置为“MyDoc.txt”。
        也可以监视特定类型文件中的更改。
        例如，若要监视文本文件中的更改，请将 Filter 属性设置为“*.txt”。
        指定类型文件，格式如:*.txt,*.doc,*.rar
        */
        public static void initWatcher(string path, string filter = "*.*") {

            watcher.Path = path; //  监控 指定目录下发生的所有改变。
            watcher.Filter = filter; // 过滤掉某些类型的文件发生的变化。例如，如果我们只希望在TXT文件被修改/新建/删除时提交通知，可以将这个属性设为“*txt”。在处理高流量或大型目录时，使用这个属性非常方便。
            watcher.Changed += OnChanged; // 当被监控的目录中有一个文件被修改时，就提交这个事件。值得注意的是，这个事件可能会被提交多次，即使文件的内容仅仅发生一项改变。这是由于在保存文件时，文件的其它属性也发生了改变。
            watcher.Created += OnCreated; // 当被监控的目录新建一个文件时，触发。如果你计划用这个事件移动新建的事件，你必须在事件处理器中写入一些错误处理代码，它能处理当前文件被其它进程使用的情况。之所以要这样做，是因为Created事件可能在建立文件的进程释放文件之前就被提交。如果你没有准备正确处理这种情况的代码，就可能出现异常。
            watcher.Deleted += OnDeleted; // 当被监控的目录中有一个文件被删除，触发。
            watcher.Renamed += OnRenamed; // 当被监控的目录中有一个文件被重命名，就提交这个事件。
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size;
            watcher.EnableRaisingEvents = false;
            watcher.IncludeSubdirectories = true; // 是否应该监控子目录中发生的改变
        }

        /**
            Name——这个属性中使事件被提交的文件的名称。其中并不包含文件的路径——只包含使用事件被提交的文件或目录名称。
            ChangeType——这是一个WatcherChangeTypes，它指出要提交哪个类型的事件。其有效值包括：Changed、Created、Deleted、Renamed
            FullPath——这个属性中包含使事件被提交的文件的完整路径，包括文件名和目录名。
        */
        private static void OnCreated(object source, FileSystemEventArgs e) {
            Log4C.log.DebugFormat("文件新建事件 ChangeType： {0}  FullPath：{1} Name： {2}", e.ChangeType, e.FullPath, e.Name);
        }
        
        private static void OnChanged(object source, FileSystemEventArgs e){
            Log4C.log.DebugFormat("文件 改变 事件 ChangeType： {0}  FullPath：{1} Name： {2}", e.ChangeType, e.FullPath, e.Name);
        }

        private static void OnDeleted(object source, FileSystemEventArgs e) {
            Log4C.log.DebugFormat("文件 删除 事件 ChangeType： {0}  FullPath：{1} Name： {2}", e.ChangeType, e.FullPath, e.Name);
        }

        private static void OnRenamed(object source, RenamedEventArgs e){
            Log4C.log.DebugFormat("文件 重命名 事件 ChangeType： {0}  FullPath：{1} Name： {2}", e.ChangeType, e.FullPath, e.Name);
        }

    }
}