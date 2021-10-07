using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaxiApp.Command;
using TaxiApp.Views;

namespace TaxiApp.ViewModels
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        public RelayCommandMain ExitCommand { get; set; }
        public RelayCommandMain SignUpPagePassCommand { get; set; }
        public RelayCommandMain SignInCommand { get; set; }

        public SignInPage SignInPage { get; set; }

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
                    MainView mainView = new MainView();
                    Window window = (Window)SignInPage.Parent;
                    window.Close();
                    mainView.ShowDialog();
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
