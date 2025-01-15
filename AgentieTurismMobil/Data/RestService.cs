using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AgentieTurismMobil.Models;

namespace AgentieTurismMobil.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        string RestUrl = "https://10.133.0.137:45455/swagger";//DE MODIFICAT

        public List<User> Users { get; private set; }
        public List<Vacation> Vacations { get; private set; }
        public List<Booking> Bookings { get; private set; }

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }

        // For User
        public async Task<List<User>> RefreshUsersAsync()
        {
            Users = new List<User>();
            Uri uri = new Uri(string.Format(RestUrl + "/users", string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Users;
        }

        public async Task SaveUserAsync(User user, bool isNewItem = true)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/users", string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(user);
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
                    Console.WriteLine(@"\tUser successfully saved.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(@"\tERROR {0}", e.Message);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/users/{0}", id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tUser successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        // For Vacation
        public async Task<List<Vacation>> RefreshVacationsAsync()
        {
            Vacations = new List<Vacation>();
            Uri uri = new Uri(string.Format(RestUrl + "/vacations", string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Vacations = JsonConvert.DeserializeObject<List<Vacation>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Vacations;
        }

        public async Task SaveVacationAsync(Vacation vacation, bool isNewItem = true)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/vacations", string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(vacation);
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
                    Console.WriteLine(@"\tVacation successfully saved.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(@"\tERROR {0}", e.Message);
            }
        }

        public async Task DeleteVacationAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/vacations/{0}", id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tVacation successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        // For Booking
        public async Task<List<Booking>> RefreshBookingsAsync()
        {
            Bookings = new List<Booking>();
            Uri uri = new Uri(string.Format(RestUrl + "/bookings", string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Bookings = JsonConvert.DeserializeObject<List<Booking>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Bookings;
        }

        public async Task SaveBookingAsync(Booking booking, bool isNewItem = true)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/bookings", string.Empty));

            try
            {
                string json = JsonConvert.SerializeObject(booking);
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
                    Console.WriteLine(@"\tBooking successfully saved.");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(@"\tERROR {0}", e.Message);
            }
        }

        public async Task DeleteBookingAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrl + "/bookings/{0}", id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"\tBooking successfully deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
