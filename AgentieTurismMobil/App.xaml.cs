using AgentieTurismMobil.Data;

namespace AgentieTurismMobil

{
    public partial class App : Application
    {

        public static UserDatabase Database { get; private set; }
        public App()
        {
            Database = new UserDatabase(new RestService());
            MainPage = new NavigationPage(new HomePage());
        }
    }
}
