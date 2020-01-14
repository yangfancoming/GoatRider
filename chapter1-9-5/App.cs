


using System;
using Dll.log4c;
using WebApiClient;

namespace chapter1_9_5 {


    public class App {

        public static async void test1() {
            Init();
            var api = HttpApi.Resolve<IUserApi>();
//            var user = new UserInfo { Account = "laojiu", Password = "123456" };
            UserInfo user1 = await api.GetAsync("laojiu");
//            var state = await api.AddAsync(user);
            Log4C.log.Debug("UserInfo---" + user1);
//            Log4C.log.Debug("UserInfo---" + user);

        }

        static void Init()
        {

        }
    }
}