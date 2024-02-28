namespace DicleAcademyV2
{
    public class GenericRequest<T> where T : class
    {
        public async Task<List<T>> GetHttpRequest(string url)
        {
            string ProductCategoryUrl = GenerateClient.Client.BaseAddress + url;
            HttpResponseMessage ProductCategoryResponce = GenerateClient.Client.GetAsync($"{ProductCategoryUrl}").Result;

            List<T> ProductCategoryApi = await ProductCategoryResponce.Content.ReadFromJsonAsync<List<T>>();
            return ProductCategoryApi;
        }
    }
}
