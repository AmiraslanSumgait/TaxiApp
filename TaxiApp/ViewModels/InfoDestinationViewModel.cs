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
    public class InfoDestinationViewModel
    {
        public InfoDestinationUC InfoUC { get; set; }
        public RelayCommandMain ExitCommand { get; set; }
       
        public InfoDestinationViewModel(InfoDestinationUC infoUC)
        {
            InfoUC = infoUC;
            ExitCommand = new RelayCommandMain(
               action => { ExitButtonClick(); },
               pRE => true
              );
        }
        public void ExitButtonClick()
        {
            InfoUC.UserControl.Visibility = Visibility.Collapsed;
            InfoUC.UserControl.IsEnabled = true;
        }
    }
}
