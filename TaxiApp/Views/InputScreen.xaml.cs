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

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                if (pbInput.Value >= 100)
                {
                    timer.Stop();
                    NavigationWindow window = new NavigationWindow();
                    SignInPage signInPage = new SignInPage();
                    window.NavigationService.Navigate(signInPage);
                    this.Close();
                    window.ShowDialog();
                }
                else if (pbInput.Value < 30)
                    pbInput.Value += 8;
                else if (pbInput.Value < 60)
                    pbInput.Value += 14;
                else
                    pbInput.Value += 18;
            };
        }


    }

    public class WindowClosingBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Window window = sender as Window;
            window.Closing -= AssociatedObject_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.5));
            anim.Completed += (s, _) => window.Close();
            window.BeginAnimation(UIElement.OpacityProperty, anim);
        }
        protected override void OnDetaching()
        {
            AssociatedObject.Closing -= AssociatedObject_Closing;
        }
    }
}
