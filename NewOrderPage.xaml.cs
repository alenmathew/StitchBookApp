using StitchBookApp.Models;
using StitchBookApp.Services;

namespace StitchBookApp;

public partial class NewOrderPage : ContentPage
{
    DatabaseService db;
    public NewOrderPage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;
        WorkType.SelectedIndex = 0;
    }

    private async void SaveOrder_Clicked(object sender, EventArgs e)
    {
        //decimal total = Convert.ToDecimal(TotalAmount.Text);
        

        // Customer Name
        if (string.IsNullOrWhiteSpace(CustomerName.Text))
        {
            await DisplayAlert("Error", "Please enter Customer Name", "OK");
            return;
        }

        // Work Type
        if (WorkType.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please select Work Type", "OK");
            return;
        }

        // Total Amount
        if (string.IsNullOrWhiteSpace(TotalAmount.Text) ||
            !decimal.TryParse(TotalAmount.Text, out decimal total) ||
            total <= 0)
        {
            await DisplayAlert("Error", "Please enter valid Total Amount", "OK");
            return;
        }

        // Advance (optional but validate if entered)
        decimal advance = 0;
        //if (!string.IsNullOrEmpty(Advance.Text))
        //{
        //     advance = Convert.ToDecimal(Advance.Text); 
        //}

        if (!string.IsNullOrWhiteSpace(Advance.Text))
        {
            if (!decimal.TryParse(Advance.Text, out advance))
            {
                await DisplayAlert("Error", "Invalid Advance Amount", "OK");
                return;
            }
        }
        if (advance > total)
        {
            await DisplayAlert("Error", "Advance cannot be greater than Total Amount", "OK");
            return;
        }

        // Delivery Date (optional check: not past date)
        //if (DeliveryDate.Date < DateTime.Today)
        //{
        //    await DisplayAlert("Error", "Delivery date cannot be in the past", "OK");
        //    return;
        //}

        var order = new Order
        {
            CustomerName = CustomerName.Text,
            WorkType = WorkType.SelectedItem?.ToString(),
            TotalAmount = total,
            Advance = advance,
            PageNumber = PageNumber.Text,
            PhoneNumber = PhoneNumber.Text,
            Balance = total - advance,
            DeliveryDate = DeliveryDate.Date,
            CreatedDate = DateTime.Now,
            IsPaid = (total - advance) == 0
        };

        await db.SaveOrder(order);

        await DisplayAlert("Saved", "Order saved", "OK");

        await Navigation.PopAsync();
    }
}