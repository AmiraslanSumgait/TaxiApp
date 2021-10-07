using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaxiApp.Command;
using TaxiApp.Views;

namespace TaxiApp.ViewModels
{
    public class SignUpViewModel
    {
        public RelayCommandMain BackCommand { get; set; }
        public RelayCommandMain SignInPagePassCommand { get; set; }

        public SignUpPage SignUpPage { get; set; }

        public SignUpViewModel(SignUpPage signUpPage)
        {
            SignUpPage = signUpPage;

            BackCommand = new RelayCommandMain(
                action =>
                {
                    SignInPage signInPage = new SignInPage();
                    SignUpPage.NavigationService.Navigate(signInPage);

                },
                pre => true);

            SignInPagePassCommand = BackCommand;
        }
    }
}
