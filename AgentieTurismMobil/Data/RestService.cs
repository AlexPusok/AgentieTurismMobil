using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AgentieTurismMobil.Models;

namespace AgentieTurismMobil.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        string RestUrl = "https://10.133.0.137:45455/swagger"; // DE MODIFICAT

        public List<User> Users { get; private set; }
        public List<Vacation> Vacations { get; private set; }
        public List<Booking> Bookings { get; private set; }
        public List<Notification> Notifications { get; private set; }
        public List<Review> Reviews { get; private set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }

        // User methods
        public async Task<List<User>> RefreshUsersAsync()
        {
            return await RefreshDataAsync<User>("/users");
        }

        public async Task SaveUserAsync(User user, bool isNewItem)
        {
            await SaveDataAsync("/users", user, isNewItem);
        }

        public async Task DeleteUserAsync(int id)
        {
            await DeleteDataAsync($"/users/{id}");
        }

        // Vacation methods
        public async Task<List<Vacation>> RefreshVacationsAsync()
        {
            return await RefreshDataAsync<Vacation>("/vacations");
        }

        public async Task SaveVacationAsync(Vacation vacation, bool isNewItem)
        {
            await SaveDataAsync("/vacations", vacation, isNewItem);
        }

        public async Task DeleteVacationAsync(int id)
        {
            await DeleteDataAsync($"/vacations/{id}");
        }

        // Booking methods
        public async Task<List<Booking>> RefreshBookingsAsync()
        {
            return await RefreshDataAsync<Booking>("/bookings");
        }

        public async Task SaveBookingAsync(Booking booking, bool isNewItem)
        {
            await SaveDataAsync("/bookings", booking, isNewItem);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await DeleteDataAsync($"/bookings/{id}");
        }

        // Notification methods
        public async Task<List<Notification>> RefreshNotificationsAsync()
        {
            return await RefreshDataAsync<Notification>("/notifications");
        }

        public async Task SaveNotificationAsync(Notification notification, bool isNewItem)
        {
            await SaveDataAsync("/notifications", notification, isNewItem);
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await DeleteDataAsync($"/notifications/{id}");
        }

        // Review methods
        public async Task<List<Review>> RefreshReviewsAsync()
        {
            return await RefreshDataAsync<Review>("/reviews");
        }

        public async Task SaveReviewAsync(Review review, bool isNewItem)
        {
            await SaveDataAsync("/reviews", review, isNewItem);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await DeleteDataAsync($"/reviews/{id}");
        }

        // Helper methods
        private async Task<List<T>> RefreshDataAsync<T>(string endpoint)
        {
            List<T> items = new List<T>();
            Uri uri = new Uri(string.Format(RestUrl + endpoint, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return items;
        }

        private async Task SaveDataAsync<T>(string endpoint, T item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(RestUrl + endpoint, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tData successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        private async Task DeleteDataAsync(string endpoint)
        {
            Uri uri = new Uri(string.Format(RestUrl + endpoint, string.Empty));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tData successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
