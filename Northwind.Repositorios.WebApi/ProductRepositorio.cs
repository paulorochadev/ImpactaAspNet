using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Net.Http;


namespace Northwind.Repositorios.WebApi
{
    public class ProductRepositorio
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string url = "http://localhost:50054/api/products";


        public async Task<ProductViewModel>Post(ProductViewModel product)
        {
            using (var resposta = await httpClient.PostAsJsonAsync(url, product))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Put(ProductViewModel product)
        {
            using (var resposta = await httpClient.PutAsJsonAsync($"{url}/{product.ProductID}", product))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<ProductViewModel>> Get()
        {
            using (var resposta = await httpClient.GetAsync(url))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            using (var resposta = await httpClient.GetAsync($"{url}/{id}"))
            {
                resposta.EnsureSuccessStatusCode();
                return await resposta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Delete(int id)
        {
            using (var resposta = await httpClient.DeleteAsync($"{url}/{id}"))
            {
                resposta.EnsureSuccessStatusCode();
            }
        }
    }
}
