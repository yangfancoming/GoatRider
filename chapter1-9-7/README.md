#  PostAsJsonAsync 方法 不支持/没找到
    await client.PostAsJsonAsync("hello/success2", product);
    原因：需要引入  
    System.Net.Http.Formatting 
    System.Net.Http;
    System.Net.Http.Headers;



