using StitchBookApp.Services;

namespace StitchBookApp;

public partial class SummaryPage : ContentPage
{
    DatabaseService db;
    public SummaryPage(DatabaseService databaseService)
	{
		InitializeComponent();
        db = databaseService;
    }
    protected override async void OnAppearing()
    {
        try
        {
            base.OnAppearing();

            var orders = await db.GetOrders();

            if (!orders.Any())
                return;

            // Date range
            var startDate = orders.Min(x => x.CreatedDate);
            DateRangeLabel.Text = $"Data from: {startDate:dd MMM yyyy}";

            decimal income = orders.Sum(x => x.TotalAmount);
            decimal pending = orders.Where(x => !x.IsPaid).Sum(x => x.Balance);
            decimal received = income - pending;

            TotalIncome.Text = "Total Income : " + income.ToString("N0");
            PendingAmount.Text = "Pending : " + pending.ToString("N0");
            ReceivedAmount.Text = "Received : " + received.ToString("N0");

            // MONTHLY PROFIT

            var currentMonth = DateTime.Today.Month;
            var currentYear = DateTime.Today.Year;

            var monthlyOrders = orders.Where(o =>
       o.CreatedDate.Month == currentMonth &&
       o.CreatedDate.Year == currentYear);

            decimal monthlyIncome = monthlyOrders.Sum(o => o.TotalAmount);

            // Expenses
            var monthlyExpense = await db.GetMonthlyExpenses();

            // Profit
            decimal profit = monthlyIncome - monthlyExpense;

            MonthlyIncomeLabel.Text = "Monthly Income : " + monthlyIncome.ToString("N0");
            MonthlyExpenseLabel.Text = "Monthly Expense : " + monthlyExpense.ToString("N0");

            ProfitLabel.Text = "Profit : " + profit.ToString("N0");

            // Orders count
            TotalOrdersLabel.Text = "Total Orders : " + orders.Count;
            ///////
            

            //decimal monthlyProfit = orders
            //    .Where(o => o.CreatedDate.Month == currentMonth
            //             && o.CreatedDate.Year == currentYear)
            //    .Sum(o => o.TotalAmount);

            //MonthlyProfit.Text = "Monthly Income : " + monthlyProfit;

           

            //if (orders.Any())
            //{
            //    var startDate = orders.Min(x => x.CreatedDate);
            //    var endDate = orders.Max(x => x.CreatedDate);

            //    DateRangeLabel.Text = $"From {startDate:dd MMM yyyy} to {endDate:dd MMM yyyy}";
            //}
        }
        catch (Exception ex)
        {

            
        }
    }

}