using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgentieTurismMobil.Models;

namespace AgentieTurismMobil.Data
{
    public class UserDatabase
    {
        private readonly IRestService restService;

        public UserDatabase(IRestService service)
        {
            restService = service;
        }

        // User-related methods
        public Task<List<User>> GetUsersAsync()
        {
            return restService.RefreshUsersAsync();
        }

        public Task SaveUserAsync(User user, bool isNewItem = true)
        {
            return restService.SaveUserAsync(user, isNewItem);
        }

        public Task DeleteUserAsync(User user)
        {
            return restService.DeleteUserAsync(user.UserId);
        }

        // Vacation-related methods
        public Task<List<Vacation>> GetVacationsAsync()
        {
            return restService.RefreshVacationsAsync();
        }

        public Task SaveVacationAsync(Vacation vacation, bool isNewItem = true)
        {
            return restService.SaveVacationAsync(vacation, isNewItem);
        }

        public Task DeleteVacationAsync(Vacation vacation)
        {
            return restService.DeleteVacationAsync(vacation.VacationId);
        }

        // Booking-related methods
        public Task<List<Booking>> GetBookingsAsync()
        {
            return restService.RefreshBookingsAsync();
        }

        public Task SaveBookingAsync(Booking booking, bool isNewItem = true)
        {
            return restService.SaveBookingAsync(booking, isNewItem);
        }

        public Task DeleteBookingAsync(Booking booking)
        {
            return restService.DeleteBookingAsync(booking.BookingId);
        }
    }
}
