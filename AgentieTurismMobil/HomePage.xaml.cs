using Microsoft.Maui.Controls;

namespace AgentieTurismMobil;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void OnUsersButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UsersPage());
    }

    private async void OnVacationsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VacationsPage());
    }

    private async void OnBookingsButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingsPage());
    }
}