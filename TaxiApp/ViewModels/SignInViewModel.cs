using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaxiApp.Command;
using TaxiApp.Data;
using TaxiApp.Models;
using TaxiApp.Views;

namespace TaxiApp.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public RelayCommandMain ExitCommand { get; set; }
        public RelayCommandMain SignUpPagePassCommand { get; set; }
        public RelayCommandMain SignInCommand { get; set; }

        public SignInPage SignInPage { get; set; }

        public UserContext UserContext { get; set; }
        public User CurrentUser { get; set; }

        public SignInViewModel(SignInPage signInPage)
        {
            SignInPage = signInPage;
            ExitCommand = new RelayCommandMain(
               action =>
               {
                   Window window = (Window)SignInPage.Parent;
                   window.Close();
               },
               pre => true
               );

            SignUpPagePassCommand = new RelayCommandMain(
                action =>
                {
                    SignUpPage signUpPage = new SignUpPage();
                    SignInPage.NavigationService.Navigate(signUpPage);
                },
                pre => true);
            SignInCommand = new RelayCommandMain(
                action =>
                {
                    UserContext = new UserContext();
                    if (UserContext.Users.Any(u => u.Email == SignInPage.tbEmail.Text && u.Password == SignInPage.pbPassword.Password))
                    {
                        MainView mainView = new MainView();
                        Window window = (Window)SignInPage.Parent;
                        window.Close();
                        mainView.ShowDialog();
                    }
                    else if (UserContext.Users.Any(u => u.Email == SignInPage.tbEmail.Text && u.Password != SignInPage.pbPassword.Password))
                        MessageBox.Show("That's not the right password. Please try again.");
                    else
                        MessageBox.Show("Couldn’t find a Taxi app account associated with this email. Please try again.");
                },
                pre => true);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
