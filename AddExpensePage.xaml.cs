
using StitchBookApp.Models;
using StitchBookApp.Services;

namespace StitchBookApp;

public partial class AddExpensePage : ContentPage
{
    DatabaseService db;
    public AddExpensePage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;

    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        var exp = new Expense
        {
            Title = Title.Text,
            Amount = Convert.ToDecimal(Amount.Text),
            Category = Category.SelectedItem?.ToString(),
            Date = ExpenseDate.Date
        };

        await db.AddExpense(exp);

        await DisplayAlert("Saved", "Expense added", "OK");

        await Navigation.PopAsync();
    }
}