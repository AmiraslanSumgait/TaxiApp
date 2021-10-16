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
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for InputScreen.xaml
    /// </summary>
    public partial class InputScreen : Window
    {
        public InputScreen()
        {
            InitializeComponent();

            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(188) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                if (pbInput.Value >= 100)
                {
                    timer.Stop();
                    NavigationWindow window = new NavigationWindow();
                    SignInPage signInPage = new SignInPage();
                    //window.NavigationService.Navigate(signInPage);
                    this.Content = signInPage;
                    //this.Close();
                    //window.ShowDialog();
                }
                else if (pbInput.Value < 30)
                    pbInput.Value += 1;
                else
                    pbInput.Value += 10;
            };
        }


    }
}