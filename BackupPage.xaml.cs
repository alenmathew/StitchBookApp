using StitchBookApp.Services;

namespace StitchBookApp;

public partial class BackupPage : ContentPage
{
    DatabaseService db;
    public BackupPage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;
    }

    private async void Backup_Clicked(object sender, EventArgs e)
    {
        await db.BackupAndShare();
    }

    private async void Restore_Clicked(object sender, EventArgs e)
    {
        await db.RestoreDatabase();
    }
}