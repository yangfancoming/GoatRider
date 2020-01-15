using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace chapter3_4_1 {


    public class TimeJob1 : IJob {

        public async Task Execute(IJobExecutionContext context) {

            using (StreamWriter sw = new StreamWriter(@"F:\YYYest.txt",true,Encoding.UTF8)) {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("");
                sw.Close();
            }
            await Task.Delay(1);
        }
    }
}