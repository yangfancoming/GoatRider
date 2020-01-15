













using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;

namespace chapter3_4_1 {

    class Program {

        public static void Main() {
            Run().GetAwaiter().GetResult();
        }


        private static async Task Run() {
            var simpleTypeLoadHelper = new SimpleTypeLoadHelper();
            XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(simpleTypeLoadHelper);

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            await processor.ProcessFileAndScheduleJobs("E:\\Code\\C#_code\\RiderLearning\\GoatRider\\chapter3-4-1\\quartz_jobs.xml", scheduler);
            await scheduler.Start();
            await Task.Delay(TimeSpan.FromSeconds(20));
            await scheduler.Shutdown();
        }
    }
}





































