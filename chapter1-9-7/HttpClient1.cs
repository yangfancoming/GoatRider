using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dll.log4c;
using HttpClientSample;

namespace chapter1_9_7 {

    public static class HttpClient1 {

        public static readonly HttpClient client = new HttpClient();

        private static void init() {
            client.BaseAddress = new Uri("http://localhost:8290/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async void test1() {
            init();
            Product product = new Product { name = "Gizmo", price = 100, category = "Widgets" };
            var url = await CreateProductAsync(product);
            Log4C.log.Debug($"Created at {url}");
        }

        private static async Task<Uri> CreateProductAsync(Product product) {
            HttpResponseMessage response = await client.PostAsJsonAsync("test/error2", product);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        public static async Task<Product> test2() {
            init();
            Task<Product> task = get(0);
            Log4C.log.Debug($"Created at {task}");
            return task.Result;
        }

        static async Task<Product> get(int id){
            Product product = null;
            string url = "test/get?id=0";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode){
                product = await response.Content.ReadAsAsync<Product>();
            }
            return product;
        }



    }
}