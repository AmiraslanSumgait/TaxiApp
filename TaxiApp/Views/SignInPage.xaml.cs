using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaxiApp.ViewModels;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Position;
using ToastNotifications.Messages;

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        //public MainView MainView { get; set; } = new MainView();
        public SignInViewModel SignInViewModel { get; set; }

        public SignInPage()
        {
            InitializeComponent();
            SignInViewModel = new SignInViewModel(this);
            DataContext = SignInViewModel;
            //SignInViewModel.MainView = MainView;
            //SignInViewModel.MainViewModel = MainView.MainViewModel;
            //SignInViewModel.SignInPage = this;

        }

       




        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (cbPassword.IsChecked == true)
        //    {
        //        tbPassword.Visibility = Visibility.Visible;
        //        pbPassword.Visibility = Visibility.Hidden;


        //    }
        //    else
        //    {
        //        tbPassword.Visibility = Visibility.Hidden;
        //        pbPassword.Visibility = Visibility.Visible;
        //    }
        //}
    }
}
