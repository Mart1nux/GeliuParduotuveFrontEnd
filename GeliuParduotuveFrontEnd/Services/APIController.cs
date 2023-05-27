using GeliuParduotuveFrontEnd.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GeliuParduotuveFrontEnd.Services
{
    public class APIController
    {
        private readonly string m_baseUrl = "http://localhost:8080/GeliuParduotuve/api/";

        public async void PutToCart(int customerId, int itemId, int amount)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {customerId}, \"customerId\": {customerId}, \"itemId\": {itemId}, \"amount\": {amount}}}", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"cart", content).ConfigureAwait(false);

            client.Dispose();
        }

        public async Task<List<CartItem>> GetCartByUser(int id)
        {
            List<CartItem> cartItems = new List<CartItem>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {id}}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"cart/customer/{id}", content).Result;

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(empResponse);
            }

            client.Dispose();

            return cartItems;
        }

        public async void MakeCartIntoOrder(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {id}}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync($"cart/customer/{id}/toOrder", content);

            client.Dispose();
        }

        public async Task<Customer> GetUserWithLogin(int userId, string username, string password)
        {
            Customer customer = new Customer();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}, \"username\": \"{username}\", \"password\": \"{password}\"}}", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"login", content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                customer = JsonConvert.DeserializeObject<Customer>(empResponse);
            }

            client.Dispose();

            return customer;
        }

        public async Task<List<Item>> GetAllItems(int userId)
        {
            List<Item> items = new List<Item>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"items", content).Result;

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                items = JsonConvert.DeserializeObject<List<Item>>(empResponse);
            }

            client.Dispose(); 

            return items;
        }

        public async Task<Item> GetItemById(int userId, int id)
        {
            Item item = new Item();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"items/get/{id}", content).Result;

            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                item = JsonConvert.DeserializeObject<Item>(empResponse);
            }

            client.Dispose();

            return item;
        }

        public int UpdateItemById(int userId, int id, Item item)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}, \"sellerId\": {item.SellerId}, \"name\": \"{item.Name}\", \"amount\": {item.Amount}, \"price\": {item.Price}, \"description\": \"{item.Description}\", \"image\": \"{item.Image}\"}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"items/{id}", content).Result;

            client.Dispose();

            if ((int)response.StatusCode == 409)
            {
                return 1;
            }

            return 0;
        }

        public async Task<List<Customer>> GetAllCustomers(int userId)
        {
            List<Customer> customers = new List<Customer>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}}}", System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync($"customers", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                customers = JsonConvert.DeserializeObject<List<Customer>>(empResponse);
            }

            client.Dispose();

            return customers;
        }

        public async Task<List<Order>> GetAllOrders(int userId)
        {
            List<Order> orders = new List<Order>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}}}", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync($"orders", content).Result;
            if (response.IsSuccessStatusCode)
            {
                string empResponse = await response.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<Order>>(empResponse);
            }

            client.Dispose();

            return orders;
        }

        public async Task<List<Seller>> GetAllSellers(int userId)
        {
            List<Seller> sellers = new List<Seller>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(m_baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            System.Net.Http.HttpContent content = new StringContent($"{{\"callerId\": {userId}}}", System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync($"sellers", content).Result;
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
