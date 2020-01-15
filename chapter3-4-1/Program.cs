







using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;

namespace chapter3_4_1 {

    class Program {

        public static void Main() {
//            Run1().GetAwaiter().GetResult();
            Run2().GetAwaiter().GetResult();
//            Run3().GetAwaiter().GetResult();
        }


        // 使用 xml 配置文件方式
        private static async Task Run1() {
            var simpleTypeLoadHelper = new SimpleTypeLoadHelper();
            XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(simpleTypeLoadHelper);

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            await processor.ProcessFileAndScheduleJobs("E:\\Code\\C#_code\\RiderLearning\\GoatRider\\chapter3-4-1\\quartz_jobs.xml", scheduler);
            await scheduler.Start();
            await Task.Delay(TimeSpan.FromSeconds(20));
            await scheduler.Shutdown();
        }


        // 使用 代码配置方式
        private static async Task Run2() {
            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            IJobDetail job = JobBuilder.Create<TimeJob2>().WithIdentity("jobName2", "jobGroup2").Build();
            IJobDetail job2 = JobBuilder.Create<TimeJob3>().WithIdentity("jobName3", "jobGroup3").Build();

            ISimpleTrigger trigger1 = (ISimpleTrigger)TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow().WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever()).Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("trigger2", "group2")
                .WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
                .Build();

            await scheduler.ScheduleJob(job, trigger1);
            await scheduler.ScheduleJob(job2, trigger2);
            await scheduler.Start();
            await Task.Delay(TimeSpan.FromSeconds(40));
            await  scheduler.Shutdown();
        }


        private static async Task Run3() {
            //调度器工厂
            ISchedulerFactory factory = new StdSchedulerFactory();
            //创建一个调度器
            IScheduler scheduler = await factory.GetScheduler();
            IJobDetail job = JobBuilder.Create<TimeJob3>().WithIdentity("jobName3", "jobGroup3").Build();
            //3、创建触发器
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger2", "group2")
                .WithCronSchedule("0/5 * * * * ?")     //5秒执行一次
                .Build();
            //4、将任务与触发器添加到调度器中
            await scheduler.ScheduleJob(job, trigger);
            //5、开始执行
            await scheduler.Start();
            await Task.Delay(TimeSpan.FromSeconds(20));
            await  scheduler.Shutdown();
        }
    }
}





































