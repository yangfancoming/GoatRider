using System.Net.Http;
using Dll.log4c;

namespace chapter1_9_7 {

    public class HttpClient1 {

        public async void test1() {
            string uri = "http://www.baidu.com/";
            HttpClient client = new HttpClient();
            string body = await client.GetStringAsync(uri);
            Log4C.log.Debug("UserInfo---" + body);
        }

    }
}