using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlazorApp1.Models;

public class ProductsService
{
    private readonly HttpClient _httpClient;

    // Constructor to inject HttpClient
    public ProductsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Public method to get products
    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            // Log the request to check if it reaches the API
            Console.WriteLine("Making request to /rest/Products...");

            // Ensure the base URL is correct
            var apiUrl = "/rest/Products"; // The relative path based on the configured base URL
            Console.WriteLine($"Request URL: {apiUrl}");

            // Request data from the API and directly deserialize the entire response
            var response = await _httpClient.GetFromJsonAsync<ApiResponse>(apiUrl);

            // Check if the response is null or the value is empty
            if (response?.Value == null || response.Value.Count == 0)
            {
                Console.WriteLine("No products found.");
                return new List<Product>();
            }

            // Log the number of products received
            Console.WriteLine($"Received {response.Value.Count} products.");

            // Return the products list directly
            return response.Value;
        }
        catch (Exception ex)
        {
            // Log the error if any occurs
            Console.Error.WriteLine($"Error fetching products: {ex.Message}");

            // Return an empty list in case of an error
            return new List<Product>();
        }
    }

    // Helper class for deserializing the response
    public class ApiResponse
    {
        public List<Product> Value { get; set; }
    }
}
