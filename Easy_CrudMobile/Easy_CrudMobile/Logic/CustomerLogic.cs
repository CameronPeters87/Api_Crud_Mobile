using Easy_CrudMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Easy_CrudMobile.Logic
{
    public class CustomerLogic
    {
        private const string Base_URL = "https://192.168.8.47:45455/api/";

        public static async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            using (HttpClient client = new HttpClient(httpClientHandler))
            {
                var response = await client.GetAsync(new Uri("https://192.168.8.47:45455/api/customers"));
                var json = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<List<Customer>>(json);

                customers = model;
            }

            return customers;
        }

        public static async Task AddCustomer(Customer customer)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            var json = JsonConvert.SerializeObject(customer);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient(httpClientHandler))
            {
                client.BaseAddress = new Uri(Base_URL);

                try
                {
                    HttpResponseMessage responseMessage = await client.PostAsync("Customers", content);

                }
                catch (Exception e)
                {

                    throw e;
                }
            }
        }
        public static async Task DeleteCustomer(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            using (var client = new HttpClient(httpClientHandler))
            {
                try
                {
                    HttpResponseMessage responseMessage = await client.DeleteAsync(new Uri(string.Format("{0}/Customers/{1}", Base_URL, id)));

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    }
}
