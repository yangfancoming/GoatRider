


# log4net
    log4net不输出日志的原因及解决方案:
    原因：运行程序目录下没有log4net.config配置文件。
    解决方法有两种：
     
     1.手动将log4net.config复制到运行程序
     2.选择解决方案中的log4net.config，在属性–>复制到输出目录，选择始终复制。
        右键 log4net.config 文件 点击 properties 后弹出框中  更改 Copy to output directory目录为 Copy always 
        
        
        
# Rider 工程配置
     配置 大括号 C#成对显示 还是 java单行显示  在 工程设置里的 
     Editor --- Code Style --- C# --- Braces Layout Tab 标签页 --- 选项不多自己挨个试