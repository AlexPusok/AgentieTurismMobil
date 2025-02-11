﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AgentieTurismMobil.Models;

namespace AgentieTurismMobil.Data
{
    public interface IRestService
    {
        // User-related methods
        Task<List<User>> RefreshUsersAsync();
        Task SaveUserAsync(User user, bool isNewItem);
        Task DeleteUserAsync(int id);

        // Vacation-related methods
        Task<List<Vacation>> RefreshVacationsAsync();
        Task SaveVacationAsync(Vacation vacation, bool isNewItem);
        Task DeleteVacationAsync(int id);

        // Booking-related methods
        Task<List<Booking>> RefreshBookingsAsync();
        Task SaveBookingAsync(Booking booking, bool isNewItem);
        Task DeleteBookingAsync(int id);

        // Notification-related methods
        Task<List<Notification>> RefreshNotificationsAsync();
        Task SaveNotificationAsync(Notification notification, bool isNewItem);
        Task DeleteNotificationAsync(int id);

        // Review-related methods
        Task<List<Review>> RefreshReviewsAsync();
        Task SaveReviewAsync(Review review, bool isNewItem);
        Task DeleteReviewAsync(int id);
    }
}
