using StitchBookApp.Services;

namespace StitchBookApp;

public partial class SearchPage : ContentPage
{
    DatabaseService db;
    public SearchPage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;
    }
    async void SearchEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			if (string.IsNullOrWhiteSpace(e.NewTextValue))
				return;

			SearchResults.ItemsSource =
				await db.SearchCustomer(e.NewTextValue);
		}
		catch (Exception ex)
		{

			
		}
    }
}