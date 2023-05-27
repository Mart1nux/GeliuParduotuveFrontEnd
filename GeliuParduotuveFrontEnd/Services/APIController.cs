using GeliuParduotuveFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GeliuParduotuveFrontEnd.Services
{
    public class APIController
    {
        private readonly string m_baseUrl = "http://localhost:8080/GeliuParduotuve/api/";

        public async Task<int> GetUserWithLogin(string username, string password)
        {
            Customer customer = new Customer();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent($"{{\"username\": \"{username}\", \"password\": \"{password}\"}}", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"login", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<Customer>(empResponse);
            }

            client.Dispose();

            return customer.Id;
        }

        public async Task<List<Item>> GetAllItems()
        {
            List<Item> items = new List<Item>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"items").Result;

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<Item>>(empResponse);
            }

            client.Dispose();

            return items;
        }

        public async Task<Item> GetItemById(int id)
        {
            Item item = new Item();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"items/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<Item>(empResponse);
            }

            client.Dispose();

            return item;
        }

        public void UpdateItemById(int id, Item item)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"sellerId\": {item.SellerId}, \"name\": \"{item.Name}\", \"amount\": {item.Amount}, \"price\": {item.Price}, \"description\": \"{item.Description}\", \"image\": \"{item.Image}\"}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"items/{id}", content).Result;

            client.Dispose();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"customers").Result;
            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(empResponse);
            }

            client.Dispose();

            return customers;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"orders").Result;
            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<Order>>(empResponse);
            }

            client.Dispose();

            return orders;
        }

        public async Task<List<Seller>> GetAllSellers()
        {
            List<Seller> sellers = new List<Seller>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"sellers").Result;
            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                sellers = JsonConvert.DeserializeObject<List<Seller>>(empResponse);
            }

            client.Dispose();

            return sellers;
        }
    }
}
