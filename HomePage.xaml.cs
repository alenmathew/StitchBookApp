using StitchBookApp.Services;

namespace StitchBookApp
{
    
    public partial class HomePage : ContentPage
    {
        int count = 0;
        DatabaseService db;
        IServiceProvider services;

        public HomePage(DatabaseService databaseService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            db = databaseService;
            services = serviceProvider;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await db.Init();
        }
        private async void NewOrder_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<NewOrderPage>();
            await Navigation.PushAsync(page);
        }

        private void Payment_Clicked(object sender, EventArgs e)
        {

        }

        private async void Pending_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<PendingPage>();
            await Navigation.PushAsync(page);
        }

        private async void Summary_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<SummaryPage>();
            await Navigation.PushAsync(page);
        }

        private async void Deliveries_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<TodayDeliveriesPage>();
            await Navigation.PushAsync(page);
        }

        private async void SearchCustomer_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<SearchPage>();
            await Navigation.PushAsync(page);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<BackupPage>();
            await Navigation.PushAsync(page);
        }

        private async void AddExpense_Clicked(object sender, EventArgs e)
        {
            var page = services.GetService<AddExpensePage>();
            await Navigation.PushAsync(page);
        }
    }
}
