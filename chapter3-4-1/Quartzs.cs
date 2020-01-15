




using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace chapter3_4_1 {


    public class Quartzs  {

        public static async Task  RunProgram(){
            // 从Factory获取Scheduler实例
            NameValueCollection props = new NameValueCollection{ { "quartz.serializer.type", "binary" }  };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            IScheduler scheduler = await factory.GetScheduler();
            // 并启动它
            await scheduler.Start();
            // some sleep to show what's happening
            await Task.Delay(TimeSpan.FromSeconds(10));
            // 当您准备关闭程序时，最后关闭调度程序
            await scheduler.Shutdown();
        }


    }
}