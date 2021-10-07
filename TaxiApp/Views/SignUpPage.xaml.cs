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

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {
        public SignUpViewModel SignUpViewModel { get; set; }
        public SignUpPage()
        {
            InitializeComponent();
            ShowsNavigationUI = false;
            SignUpViewModel = new SignUpViewModel(this);
            DataContext = SignUpViewModel;
        }

    }
}
