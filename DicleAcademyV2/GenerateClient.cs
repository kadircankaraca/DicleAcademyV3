namespace DicleAcademyV2
{
    public static class GenerateClient
    {
        public static HttpClient Client { get; set; }
        //public static IConfiguration _configuration{get; }

        public static HttpClient InitializeClientBaseAddress(this IServiceCollection services, IConfiguration configuration)
        {
            var result = configuration.GetSection("ClientBaseUrl").Value;
            Client = new HttpClient();
            //var uri = url[0];
            //string baseAddress = await Client.GetStringAsync(url);
            Client.BaseAddress = new Uri(result.ToString());
            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); 
            return Client;
        }
        public static string UriAddress(string uri)
        {
            Client = new HttpClient();
            string url = Client.BaseAddress + uri;
            //string baseAddress = await Client.GetStringAsync(url);

            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); 
            return url;
        }
    }
}
