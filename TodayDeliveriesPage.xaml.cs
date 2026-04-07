using StitchBookApp.Services;

namespace StitchBookApp;

public partial class TodayDeliveriesPage : ContentPage
{
	public TodayDeliveriesPage()
	{
		InitializeComponent();
	}
    DatabaseService db;

    public TodayDeliveriesPage(DatabaseService databaseService)
    {
        InitializeComponent();
        db = databaseService;
    }

    protected override async void OnAppearing()
    {
		try
		{
			base.OnAppearing();

			DeliveryList.ItemsSource = await db.GetTodayDeliveries();
		}
		catch (Exception ex)
		{

			
		}
    }
}