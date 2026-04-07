using StitchBookApp.Models;
using StitchBookApp.Services;

namespace StitchBookApp;

public partial class PendingPage : ContentPage
{
    DatabaseService db;
    public PendingPage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;
    }
    protected override async void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            OrdersList.ItemsSource = await db.GetPendingOrders();
        }
        catch (Exception ex)
        {

            
        }
    }
    private async void Pay_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        var order = button.BindingContext as Order;

        order.IsPaid = true;
        order.Balance = 0;

        await db.UpdateOrder(order);

        OrdersList.ItemsSource = await db.GetPendingOrders();
    }
}