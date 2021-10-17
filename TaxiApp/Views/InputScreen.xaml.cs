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
            try
            {
                InitializeComponent();

                var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(188) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    if (pbInput.Value >= 100)
                    {
                        timer.Stop();
                        SignInPage signInPage = new SignInPage();
                        this.Content = signInPage;
                    }
                    else if (pbInput.Value < 30)
                        pbInput.Value += 100;
                    else
                        pbInput.Value += 10;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();
    }
}