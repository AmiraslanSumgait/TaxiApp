using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Device.Location;
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
using System.Windows.Shapes;

namespace TaxiApp.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {

        public MainView()
        {
            InitializeComponent();

            //Esri.ArcGISRuntime.ArcGISRuntimeEnvironment.ApiKey = "AAPK1ed067b1087947c5a219c1af529228336-P4cbZb45ioS_6m9tpWvfT6LhFjAnkM8Xthkvhvm_gwLI6gYuVxBTyXCSpbwwa0";

            //MyMap.Map = new Map(BasemapStyle.ArcGISNavigation);

            //MyMap.SetViewpoint(new Viewpoint(
            //    latitude: 34.027,
            //    longitude: -118.805,
            //    scale: 72223.819286));


            MapPoint mapCenterPoint = new MapPoint(-118.805, 34.027, SpatialReferences.Wgs84);
            MainMapView.SetViewpoint(new Viewpoint(mapCenterPoint, 100000));
        }


      

    }
}
