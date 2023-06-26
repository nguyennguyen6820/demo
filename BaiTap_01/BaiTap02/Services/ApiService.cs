using BaiTap02.Dtos;
using BaiTap02.Models;
using BaiTap02.Settings;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace BaiTap02.Services
{
    public class ApiService
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public ApiService(AppSetting appSetting, HttpClient httpClient) {
            _apiUrl = appSetting.ApiUrl;
            _httpClient = httpClient;
        }

        public async Task<Category> AddCategory(CategoryAddDTO dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var url = $"{_apiUrl}/api/category";
            var result = await _httpClient.PostAsync(url, content);
            if(result.IsSuccessStatusCode)
            {
               var category = await result.Content.ReadFromJsonAsync<Category>();
                return category;
            }
            return null;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var url = $"{_apiUrl}/api/category";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var categories = await result.Content.ReadFromJsonAsync<List<Category>>();
                return categories;
            }
            return new List<Category>();
        }

        public async Task<Category> EditCategory(int id)
        {
            var url = $"{_apiUrl}/api/category/{id}";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var category = await result.Content.ReadFromJsonAsync<Category>();
                return category;
            }
            return null;
        }
        public async Task<Category> UpdateCategory(CategoryAddDTO dto)
        {
            var url = $"{_apiUrl}/api/category/edit";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var category = await result.Content.ReadFromJsonAsync<Category>();
                return category;
            }
            return null;
        }
        public async Task<int> DeleteCategory(int id)
        {
            var url = $"{_apiUrl}/api/category/delete?id={id}";
            var result = await _httpClient.DeleteAsync(url);
            if(result.IsSuccessStatusCode)
            {
                return id;

            }
            return -1;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var url = $"{_apiUrl}/api/category/getcategorybyid?id={id}";
            var result = await _httpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                var category = await result.Content.ReadFromJsonAsync<Category>();
                return category;
            }
            return null;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var url = $"{_apiUrl}/api/product";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var products = await result.Content.ReadFromJsonAsync<List<Product>>();
                return products;
            }
            return new List<Product>();
        }
        public async Task<Product> AddProduct(ProductDTO dto)
        {
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var url = $"{_apiUrl}/api/product";
            var result = await _httpClient.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var product = await result.Content.ReadFromJsonAsync<Product>();
                return product;
            }
            return null;
        }
        public async Task<Product> EditProduct(int id)
        {
            var url = $"{_apiUrl}/api/product/{id}";
            var result = await _httpClient.GetAsync(url);
            if(result.IsSuccessStatusCode)
            {
                var product = await result.Content.ReadFromJsonAsync<Product>();
                return product;
            }
            return null;
        }
        public async Task<Product> UpdateProduct(ProductDTO dto)
        {
            var url = $"{_apiUrl}/api/product/edit";
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, MediaTypeNames.Application.Json);
            var result = await _httpClient.PutAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                var product = await result.Content.ReadFromJsonAsync<Product>();
                return product;
            }
            return null;
        }
        public async Task<int> DeleteProduct(int id)
        {
            var url = $"{_apiUrl}/api/product/delete?id={id}";
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode)
            {
                return id;
            }
            return -1;
        }
        public async Task<List<Product>> SearchProduct(string productname)
         {
            var url = $"{_apiUrl}/api/product/searchproduct?productname={productname}";
            var result = await _httpClient.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var product = await result.Content.ReadFromJsonAsync<List<Product>>();
                return product;

            }
            return null;
        }




    }
}
