


# log4net
    log4net不输出日志的原因及解决方案:
    原因：运行程序目录下没有log4net.config配置文件。
    解决方法有两种：
     
     1.手动将log4net.config复制到运行程序
     2.选择解决方案中的log4net.config，在属性–>复制到输出目录，选择始终复制。
        右键 log4net.config 文件 点击 properties 后弹出框中  更改 Copy to output directory目录为 Copy always 
        
        
# log4net 再 winform项目中的用方法：
    1.下载并引入Log4Net.dll程序集到项目中  下载地址：http://logging.apache.org/log4net/download_log4net.cgi   页面中的 log4net-2.0.8-bin-oldkey.zip
    　　
    2.在App.Config中添加对应的节点
        <!--重点configsections必须是第一个节点1og4net配置-->
        <configSections>
            <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
        </configSections>
        
     3.在App.Config中添加Log4Net.dll初始化信息
            <log4net>
                <appender name="Console" type="log4net.Appender.ConsoleAppender">
                    <layout type="log4net.Layout.PatternLayout">
                        <!-- Pattern to output the caller's file name and line number -->
                        <conversionPattern value="%utcdate %5level [%thread] - %message%newline" />
                    </layout>
                </appender>
                
                <appender name="RollingFile" type="log4net.Appender.RollingFileAppender">
                    <file value="logf123ile.log" />
                    <appendToFile value="true" />
                    <maximumFileSize value="100KB" />
                    <maxSizeRollBackups value="2" />
             
                    <layout type="log4net.Layout.PatternLayout">
                        <conversionPattern value="%utcdate %level %thread %logger - %message%newline" />
                    </layout>
                </appender>
                
                <root>
                    <level value="DEBUG" />
                    <appender-ref ref="Console" />
                    <appender-ref ref="RollingFile" />
                </root>
            </log4net>
     4.在AssemblyInfo.cs：配置文件中读取配置Log4net.dll
        [assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "config", Watch = true)]   
        
        
     5. //首先实例化Log4net
        public static readonly ILog log = LogManager.GetLogger(typeof(Log4C)); 
        或者
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        //使用记录信息
        log.Debug("Debug", new Exception("Debug"));
        log.Info("Info", new Exception("Info"));
        log.Warn("Warn", new Exception("Warn"));
        log.Error("Error", new Exception("Error"));
        log.Fatal("Fatal", new Exception("Fatal"));   
        
# Rider 工程配置
     配置 大括号 C#成对显示 还是 java单行显示  在 工程设置里的 
     Editor --- Code Style --- C# --- Braces Layout Tab 标签页 --- 选项不多自己挨个试