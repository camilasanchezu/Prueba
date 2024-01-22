using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Services
{
    public  class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;


        public APIService()
        {
            _baseUrl = "";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<bool> DeleteTarea(int IdTarea)
        {
            var response = await _httpClient.DeleteAsync($"/api/Tarea/{IdTarea}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        public async Task<Tarea> GetProducto(int IdTarea)
        {
            var response = await _httpClient.GetAsync($"/api/Tarea/{IdTarea}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Tarea tarea = JsonConvert.DeserializeObject<Tarea>(json_response);
                return tarea;
            }
            return new Tarea();
        }

        public async Task<List<Tarea>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Tarea");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Tarea> productos = JsonConvert.DeserializeObject<List<Tarea>>(json_response);
                return productos;
            }
            return new List<Tarea>();

        }

        public async Task<Tarea> PostProducto(Tarea tarea)
        {
            var content = new StringContent(JsonConvert.SerializeObject(tarea), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Tarea tarea2 = JsonConvert.DeserializeObject<Tarea>(json_response);
                return tarea2;
            }
            return new Tarea();
        }

       
    }

}
}
