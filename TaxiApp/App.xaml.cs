using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaxiApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Note: it is not best practice to store API keys in source code.
            // The API key is referenced here for the convenience of this tutorial.
            Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.ApiKey = "AAPK05697dddd05e413aa166a2cf15573966NNDobD2hsZDKKr1Mq-zxdTDY7vREnq9-2h6VaNBP_oJXDIHaADW4kinEV6hxeZdO";
        }
    }
}
