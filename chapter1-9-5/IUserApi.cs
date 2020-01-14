




using WebApiClient;
using WebApiClient.Attributes;

namespace chapter1_9_5 {

    public interface IUserApi : IHttpApi
    {
        // GET api/user?account=laojiu
        // Return json或xml内容
        [HttpGet("api/user")]
        ITask<UserInfo> GetAsync(string account);

        // POST api/user
        // Body Account=laojiu&password=123456
        // Return json或xml内容
//        [HttpPost("api/user")]
//        ITask<boo> AddAsync([FormContent] UserInfo user);
    }

}