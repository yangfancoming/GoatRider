#  FileSystemWatcher 用法
 
       要注意的是：
       
       1.添加文件或文件夹时，会触发Created事件，然后修改默认文件夹或文件名称再触发Changed事件。
       2.复制或移动文件夹文件时则是触发Created事件。
       3.删除文件夹或文件时触发Deleted事件。
       
        对包括隐藏文件(夹)在内的所有文件(夹)进行监控。
        您可以为 InternalBufferSize 属性（用于监视网络上的目录）设置的最大大小为 64 KB。