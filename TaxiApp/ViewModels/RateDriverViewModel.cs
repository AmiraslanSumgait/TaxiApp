
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TaxiApp.Command;
using TaxiApp.Views;

namespace TaxiApp.ViewModels
{
    public class RateDriverViewModel
    {
        public int RatingValue { get; set; }
        public RelayCommandMain CloseCommand { get; set; }
        public RateDriverView  RateDriverView { get; set; }
        public RateDriverViewModel(RateDriverView rateDriverView)
        {
            
            RateDriverView = rateDriverView;
            CloseCommand = new RelayCommandMain(
                action => { rateDriverView.Close();},
                pre => true
             );
            rateDriverView.gridHead.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => RateDriverView.DragMove();
    }
}
