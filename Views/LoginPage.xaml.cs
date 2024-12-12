namespace ProjectMaui.Views;

using ProjectMaui.Models;
using SQLite;
public partial class LoginPage : ContentPage
{
    private SQLiteConnection dbconnection;
    public LoginPage()
	{
		InitializeComponent(); 
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users_local_db.db3");
        dbconnection = new SQLiteConnection(dbPath);
        dbconnection.CreateTable<User>();
	}

    // Login show next page, else show fail
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text?.Trim();
        var password = PasswordEntry.Text?.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ErrorMessageLabel.Text = "Please enter a username and password.";
            ErrorMessageLabel.IsVisible = true;
            return;
        }
        var user = dbconnection.Table<User>().FirstOrDefault(u => u.Username == username);
        if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            
            ErrorMessageLabel.IsVisible = false;
            //Application.Current.MainPage = new MainPage();
            await Shell.Current.GoToAsync("///MainPage");
        }
        else
        {
            ErrorMessageLabel.Text = "Invalid username or password.";
            ErrorMessageLabel.IsVisible = true;
        }
    }

    private async void OnBtnRegisterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///RegistrationPage");
    }

}