using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using lduggan_backend_dot_net.Models;

namespace lduggan_backend_dot_net.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static readonly System.Net.Http.HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
        };

        private static readonly System.Text.Json.JsonSerializerOptions jsonSerializerOptions
            = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        public async Task<T> Add(T entity, string path)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, path)
            {
                Content = JsonContent.Create(entity)
            };

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async void Delete(int id, string path)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, $"{path}/{id}");
            
            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task<T> Get(string path, int id)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{path}/{id}");

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        //public async Task<IEnumerable<T>[]> GetAll<U>()
        //{
        //    var tasks = new[]{
        //        Get<Post>("posts"),
        //        Get<Album>("albums"),
        //        Get<User>("users")
        //        };

        //    return await Task.WhenAll(tasks);
        //}

        public async Task<IEnumerable<T>> GetAll<U>(string path)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, path);

            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
        }

        public async Task<T> Update(T entity, string path, int id)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, $"{path}/{id}")
            {
                Content = JsonContent.Create(entity)
            };

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
