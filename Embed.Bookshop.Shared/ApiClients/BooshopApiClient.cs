using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Embed.Bookshop.Shared.ApiClients
{
    public class BooshopApiClient
    {
        const string API_ENDPOINT = "https://embed-bookshop.azurewebsites.net/";
        HttpClient Http { get; }

        public BooshopApiClient()
        {
            Http = new();
            Http.BaseAddress = new Uri(API_ENDPOINT);
        }


        public async Task<int> PlaceOrderAsync(string isbn, Guid bookstoreId, string email)
        {
            //1. Arrange
            var endpoint = $"api/orders?isbn={isbn}&bookstoreId={bookstoreId}&email={email}";

            //2. Act
            var response = await Http.PostAsync(endpoint, null);


            //3. Assert
            if (!response.IsSuccessStatusCode)
            {
                return (int)response.StatusCode;
            }

            return StatusCodes.Status201Created;        
        }
    }
}
