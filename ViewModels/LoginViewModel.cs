using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Windows.Input;
using ProjectMaui.Models;

namespace ProjectMaui.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly SQLiteConnection dbconnection;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users_local_db.db3");
            dbconnection = new SQLiteConnection(dbPath);
            dbconnection.CreateTable<User>();

            //AddTestUser();
        }

        #region Test User
        //private void AddTestUser()
        //{
        //    var hashedPassword = BCrypt.Net.BCrypt.HashPassword("password");
        //    var testUser = new User
        //    {
        //        Username = "tester",
        //        Password = hashedPassword
        //    };
        //    dbconnection.Insert(testUser);
        //} 
        #endregion

        private async Task OnLoginAsync()
        {
            //var username = UsernameEntry.Text?.Trim();
            //var password = PasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter a username and password.";
                return;
            }

            var user = dbconnection.Table<User>().FirstOrDefault(u => u.Username == Username);
            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {

                ErrorMessage = string.Empty;
                await Shell.Current.GoToAsync("///MainPage");
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }

        private async Task OnRegisterAsync()
        {
            await Shell.Current.GoToAsync("///RegistrationPage");
        }
    }
}
