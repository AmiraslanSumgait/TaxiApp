using AdminPanel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdminPanel.ViewModels
{
    public class MainViewModel
    {
        public MainView MainView { get; set; }

        public MainViewModel(MainView mainView)
        {
            MainView = mainView;
            MainView.DataContext = this;

            MainView.Frame.Content = new DriversListPage();

            MainView.MouseLeftButtonDown += Window_MouseLeftButtonDown;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => MainView.DragMove();
    }
}
