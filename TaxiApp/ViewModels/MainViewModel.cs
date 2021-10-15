using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Navigation;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaxiApp.Command;
using TaxiApp.Data;
using TaxiApp.Services;
using TaxiApp.Views;
namespace TaxiApp.ViewModels
{
    public class MainViewModel
    {
        public int count = 0;
        public int countCliclMaximize;
        public ICommand gvtapped { get; set; }
        private Graphic _startGraphic;
        private Graphic _endGraphic;
        private Graphic _graphicTaxi1;
        private Graphic _graphicTaxi2;
        public RelayCommandMain StartNavigationCommand { get; set; }
        public RelayCommandMain RecenterCommand { get; set; }
        public RelayCommandMain SearchAdressCommand { get; set; }
        public RelayCommandMain MenuOpenCommand { get; set; }
        public RelayCommandMain MenuCloseCommand { get; set; }
        public RelayCommandMain ExitAppCommand { get; set; }
        public RelayCommandMain MinimizeAppCommand { get; set; }
        public RelayCommandMain MaximizeAppCommand { get; set; }
        public RelayCommandMain InfoDestinationCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private GraphicsOverlayCollection _graphicsOverlayCollection;
        public GraphicsOverlayCollection GraphicsOverlays
        {
            get { return _graphicsOverlayCollection; }
            set
            {
                _graphicsOverlayCollection = value;
                OnPropertyChanged();
            }
        }
        private Map _myMap;
        public Map MyMap
        {
            get { return _myMap; }
            set
            {
                _myMap = value;
                OnPropertyChanged();
            }
        }
        enum RouteBuilderStatus
        {
            NotStarted, // No locations have been defined.
            SelectedStart, // Origin point exists.
            SelectedStartAndEnd // Origin and destination exist.
        }

        private RouteBuilderStatus _currentState = RouteBuilderStatus.NotStarted;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Variables for tracking the navigation route.
        private RouteTracker _tracker;
        private RouteResult _routeResult;
        private Route _route;

        // List of driving directions for the route.
        private IReadOnlyList<DirectionManeuver> _directionsList;

        // Graphics to show progress along the route.
        private Graphic _routeAheadGraphic;
        private static Uri _locationUri = new Uri("https://nbkgu89qyqdofvzw.maps.arcgis.com/sharing/rest/content/items/361a937b56c542549083460f47a5caf3/data");
        private static Uri _currentLocationUri = new Uri("https://nbkgu89qyqdofvzw.maps.arcgis.com/sharing/rest/content/items/22198fcdc2f5443b8303e97b0044aebe/data");
        private static Uri _taxiUri = new Uri("https://nbkgu89qyqdofvzw.maps.arcgis.com/sharing/rest/content/items/fabb958336e7475e844dda83b54dec47/data");
        private Uri _personUri = new Uri("https://nbkgu89qyqdofvzw.maps.arcgis.com/sharing/rest/content/items/4bb29cac50bd46b3b8f63edb949a0db6/data");

        private readonly Uri _routingUri = new Uri("https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World");
        private readonly MapPoint _taxi1 = new MapPoint( 49.846275, 40.414404, SpatialReferences.Wgs84);
        private readonly MapPoint _taxi2 = new MapPoint(49.726979, 40.478204,   SpatialReferences.Wgs84);
        //------------------------------------------------------------------
        private readonly MapPoint _conventionCenter = new MapPoint(49.651630, 40.609029, SpatialReferences.Wgs84);
        //----------------------------------------------------------------------
        
        public MainView MainView { get; set; }
        PictureMarkerSymbol locationSymbol = new PictureMarkerSymbol(_locationUri)
        {
            Height = 27,
            Width = 24
        };
        PictureMarkerSymbol currentLocationSymbol = new PictureMarkerSymbol(_currentLocationUri)
        {
            Height = 27,
            Width = 24
        };
        PictureMarkerSymbol taxiSymbol = new PictureMarkerSymbol(_taxiUri)
        {
            Height = 47,
            Width = 47
        };
        public MainViewModel(MainView mainView)
        {
            
            MainView = mainView;
            Initialize();
           
            mainView.gridHead.MouseLeftButtonDown += Grid_MouseLeftButtonDown;
            StartNavigationCommand = new RelayCommandMain(
                action => { StartNavigation(); },
                pRE => true
               );
            RecenterCommand = new RelayCommandMain(
                action => { RecenterButton_Click(); },
                pre => true
               );
            SearchAdressCommand = new RelayCommandMain(
                action => { SearchAddressButton_Click(); },
                pre => true
            );

            MenuOpenCommand = new RelayCommandMain(
                action => { OpenMenuButton_Click(); },
                pre => true
              );

            MenuCloseCommand = new RelayCommandMain(
                action => { CloseMenuButton_Click(); },
                pre => true
             );

            ExitAppCommand = new RelayCommandMain(
                action => { ExitAppButton_Click(); },
                pre => true
                );

            MinimizeAppCommand = new RelayCommandMain(
                action => { MinimizeAppButton_Click(); },
                pre => true
                );

            MaximizeAppCommand = new RelayCommandMain(
                action => { MaximizeAppButton_Click(); },
                pre => true
                );
            InfoDestinationCommand = new RelayCommandMain(
               action => {
                   MainView.InfoUcPanel.UserControl.Visibility = Visibility.Visible;
                   MainView.InfoUcPanel.UserControl.IsEnabled = true;  
               },
               pre => true
               );

            MainView.DataContext = this;
            gvtapped = new RelayCommand<Esri.ArcGISRuntime.UI.Controls.GeoViewInputEventArgs>(Ongvtapped);
            MyMap = new Map(BasemapStyle.ArcGISNavigation);
            MainView.MyMapView.LocationDisplay.IsEnabled = true;
            MainView.MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Recenter;
            MainView.MyMapView.LocationDisplay.CourseSymbol = new PictureMarkerSymbol(_taxiUri);
            MainView.MyMapView.LocationDisplay.DefaultSymbol = new PictureMarkerSymbol(_personUri);
            SetupMap();
        }
        
        GraphicsOverlay routeAndStopsOverlay = new GraphicsOverlay();
        public void SetupMap()
        {

            this.GraphicsOverlays = new GraphicsOverlayCollection
            {
               routeAndStopsOverlay
            };
           
            _startGraphic = new Graphic(null, currentLocationSymbol);
            _endGraphic = new Graphic(null, locationSymbol);
            _graphicTaxi1 = new Graphic(_taxi1, taxiSymbol);
            _graphicTaxi2 = new Graphic(_taxi2, taxiSymbol);
            routeAndStopsOverlay.Graphics.AddRange(new[] {_graphicTaxi1, _graphicTaxi2, _startGraphic, _endGraphic });
        }
        private async void Ongvtapped(GeoViewInputEventArgs e)
        {
            ++count;
            try
            {
                if (count != 1)
                {
                    ResetState();
                    _routeAheadGraphic.Geometry = null;
                }

                await HandleTap(e.Location);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }
        private void Initialize()
        {
            try
            {
                // Add event handler for when this sample is unloaded.
                MainView.Unloaded += SampleUnloaded;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        private async void SearchAddressButton_Click()
        {
            if (MainView.AddressTextBox.Text != string.Empty)
            {
                // Get the MapViewModel from the page (defined as a static resource).
                // Call SearchAddress on the view model, pass the address text and the map view's spatial reference.
                try
                {
                    MainView.MyMapView.GraphicsOverlays[0].Graphics.Remove(_routeAheadGraphic);
                    _routeAheadGraphic = null;

                    MapPoint addressPoint = await SearchAddress(MainView.AddressTextBox.Text, MainView.MyMapView.SpatialReference);
                    _endGraphic.Geometry = Marker.Geometry;
                    _startGraphic.Geometry = MainView.MyMapView.LocationDisplay.Location.Position;
                    await FindRoute();
                    // If a result was found, center the display on it.
                    if (addressPoint != null)
                    {
                        await MainView.MyMapView.SetViewpointCenterAsync(addressPoint);
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("Please enter your address destination.");
            }
        }
        public Graphic Marker { get; set; }
        public async Task<MapPoint> SearchAddress(string address, SpatialReference spatialReference)
        {
            MapPoint addressLocation = null;
            try
            {
                //GraphicsOverlay graphicsOverlay = this.GraphicsOverlays.FirstOrDefault();
                //graphicsOverlay.Graphics.Clear();
                LocatorTask locatorTask = new LocatorTask(new Uri("https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer"));
                // Define geocode parameters: limit the results to one and get all attributes.
                GeocodeParameters geocodeParameters = new GeocodeParameters();
                geocodeParameters.ResultAttributeNames.Add("*");
                geocodeParameters.MaxResults = 1;
                geocodeParameters.OutputSpatialReference = spatialReference;
                IReadOnlyList<GeocodeResult> results = await locatorTask.GeocodeAsync(address, geocodeParameters);
                GeocodeResult geocodeResult = results.FirstOrDefault();
                if (geocodeResult == null) { throw new Exception("No matches found."); }
                SimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, System.Drawing.Color.Green, 15);
                Graphic markerGraphic = new Graphic(geocodeResult.DisplayLocation, geocodeResult.Attributes, markerSymbol);
                Marker = markerGraphic;
                // Create a graphic to display the result address label.
                TextSymbol textSymbol = new TextSymbol(geocodeResult.Label, System.Drawing.Color.Red, 18, Esri.ArcGISRuntime.Symbology.HorizontalAlignment.Center, Esri.ArcGISRuntime.Symbology.VerticalAlignment.Bottom);
                Graphic textGraphic = new Graphic(geocodeResult.DisplayLocation, textSymbol);

                // Add the location and label graphics to the graphics overlay.
                routeAndStopsOverlay.Graphics.Add(markerGraphic);
                routeAndStopsOverlay.Graphics.Add(textGraphic);
                addressLocation = geocodeResult.DisplayLocation;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Couldn't find address: " + ex.Message);
                //ResetState();
            }

            // Return the location of the geocode result.
            return addressLocation;
        }


        private void ResetState()
        {
            _startGraphic.Geometry = null;
            _endGraphic.Geometry = null;
            _currentState = RouteBuilderStatus.NotStarted;
        }


        public async Task HandleTap(MapPoint tappedPoint)
        {
            switch (_currentState)
            {
                case RouteBuilderStatus.NotStarted:
                    ResetState();
                    _endGraphic.Geometry = tappedPoint;
                    _startGraphic.Geometry = MainView.MyMapView.LocationDisplay.Location.Position;
                    _currentState = RouteBuilderStatus.SelectedStartAndEnd;
                    await FindRoute();
                    break;
                case RouteBuilderStatus.SelectedStartAndEnd:
                    // Ignore map clicks while routing is in progress
                    break;
            }
        }
        public async Task FindRoute()
        {

            var stops = new[] { _graphicTaxi2,_startGraphic, _endGraphic }.Select(graphic => new Stop(graphic.Geometry as MapPoint));

            var routeTask = await RouteTask.CreateAsync(_routingUri);
            RouteParameters parameters = await routeTask.CreateDefaultParametersAsync();
            parameters.ReturnDirections = true;
            parameters.ReturnRoutes = true;
            parameters.ReturnStops = true;
            parameters.OutputSpatialReference = SpatialReferences.Wgs84;
            parameters.SetStops(stops);

            var result = await routeTask.SolveRouteAsync(parameters);
            _routeResult = await routeTask.SolveRouteAsync(parameters);
            _route = _routeResult.Routes[0];
            if (result?.Routes?.FirstOrDefault() is Route routeResult)
            {
                _currentState = RouteBuilderStatus.NotStarted;
            }
            else
            {
                ResetState();
                throw new Exception("Route not found");
            }

            _routeAheadGraphic = new Graphic(_route.RouteGeometry) { Symbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, System.Drawing.Color.LightBlue, 5) };

            // Create a graphic (solid) to represent the route that's been traveled (initially empty).

            // Add the route graphics to the map view.
            MainView.MyMapView.GraphicsOverlays[0].Graphics.Add(_routeAheadGraphic);


            // Set the map viewpoint to show the entire route.
            await MainView.MyMapView.SetViewpointGeometryAsync(_route.RouteGeometry, 100);

            // Enable the navigation button.
            MainView.StartNavigationButton.IsEnabled = true;

        }
        private void StartNavigation()
        {
            routeAndStopsOverlay.Graphics.Remove(_graphicTaxi2);
            MainView.InfoUcPanel.UserControl.Visibility = Visibility.Collapsed;
            MainView.btn_info.IsEnabled = true;
            // Disable the start navigation button.
            MainView.StartNavigationButton.IsEnabled = false;
            // Get the directions for the route.
            _directionsList = _route.DirectionManeuvers;

            // Create a route tracker.
            _tracker = new RouteTracker(_routeResult, 0, true);

            // Handle route tracking status changes.
            _tracker.TrackingStatusChanged += TrackingStatusUpdated;
            // Turn on navigation mode for the map view.
            MainView.MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;
            MainView.MyMapView.LocationDisplay.AutoPanModeChanged += AutoPanModeChanged;

            // Add a data source for the location display.
            var simulationParameters = new SimulationParameters(DateTimeOffset.Now, 50.0);
            var simulatedDataSource = new SimulatedLocationDataSource();
            simulatedDataSource.SetLocationsWithPolyline(_route.RouteGeometry, simulationParameters);
            MainView.MyMapView.LocationDisplay.DataSource = new RouteTrackerDisplayLocationService(simulatedDataSource, _tracker);
            
            // Use this instead if you want real location:

            //MyMapView.LocationDisplay.DataSource = new RouteTrackerLocationDataSource(_tracker, new SystemLocationDataSource());

            // Enable the location display (this wil start the location data source).
            MainView.MyMapView.LocationDisplay.IsEnabled = true;
           
        }

        private void TrackingStatusUpdated(object sender, RouteTrackerTrackingStatusChangedEventArgs e)
        {
            TrackingStatus status = e.TrackingStatus;

            // Start building a status message for the UI.
            StringBuilder statusMessageBuilder = new System.Text.StringBuilder("Route Status:\n");

            // Check the destination status.
            if (status.DestinationStatus == DestinationStatus.NotReached || status.DestinationStatus == DestinationStatus.Approaching)
            {
                statusMessageBuilder.AppendLine("Distance remaining: " +
                                            status.RouteProgress.RemainingDistance.DisplayText + " "+
                                            status.RouteProgress.RemainingDistance.DisplayTextUnits.PluralDisplayName);

                statusMessageBuilder.AppendLine("Time remaining: " +
                                                status.RouteProgress.RemainingTime.ToString(@"hh\:mm\:ss"));

                if (status.CurrentManeuverIndex + 1 < _directionsList.Count)
                { 
                    statusMessageBuilder.AppendLine("Next direction: " + _directionsList[status.CurrentManeuverIndex + 1].DirectionText);
                }

                // Set geometries for progress and the remaining route.
                _routeAheadGraphic.Geometry = status.RouteProgress.RemainingGeometry;

            }
            else if (status.DestinationStatus == DestinationStatus.Reached)
            {
                statusMessageBuilder.AppendLine("Destination reached.");

                // Set the route geometries to reflect the completed route.
                _routeAheadGraphic.Geometry = null;


                // Navigate to the next stop (if there are stops remaining).
                if (status.RemainingDestinationCount > 1)
                {
                    _tracker.SwitchToNextDestinationAsync();
                }
                else
                {
                    MainView.Dispatcher.BeginInvoke((Action)delegate ()
                    {
                        // Stop the simulated location data source.
                        MainView.MyMapView.LocationDisplay.DataSource.StopAsync();
                    });
                }
            }
            MainView.Dispatcher.BeginInvoke((Action)delegate ()
            {
                // Show the status information in the UI.
                MainView.MessagesTextBlock.Text = statusMessageBuilder.ToString();
            });
        }
        
        private void AutoPanModeChanged(object sender, LocationDisplayAutoPanMode e)
        {
            // Turn the recenter button on or off when the location display changes to or from navigation mode.
            MainView.RecenterButton.IsEnabled = e != LocationDisplayAutoPanMode.Navigation;
        }

        private void RecenterButton_Click()
        {
            // Change the mapview to use navigation mode.
            MainView.MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;
        }

        private void SampleUnloaded(object sender, RoutedEventArgs e)
        {
            // Stop the tracker.
            if (_tracker != null)
            {
                _tracker.TrackingStatusChanged -= TrackingStatusUpdated;
                //_tracker.NewVoiceGuidance -= SpeakDirection;
                _tracker = null;
            }
            // Stop the location data source.
            MainView.MyMapView.LocationDisplay?.DataSource?.StopAsync();
        }
        private void CloseMenuButton_Click()
        {
            MainView.buttonOpenMenu.Visibility = Visibility.Visible;
            MainView.buttonCloseMenu.Visibility = Visibility.Collapsed;

            Canvas.SetLeft(MainView.buttonOpenMenu, 13);

        }

        private void OpenMenuButton_Click()
        {
            MainView.buttonOpenMenu.Visibility = Visibility.Collapsed;
            MainView.buttonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ExitAppButton_Click() => MainView.Close();
        private void MaximizeAppButton_Click()
        {
            Canvas.SetLeft(MainView.buttonOpenMenu, 13);
            ++countCliclMaximize;
            if (countCliclMaximize % 2 == 1) MainView.WindowState = WindowState.Maximized;
            else MainView.WindowState = WindowState.Normal;
        }
        private void MinimizeAppButton_Click() => MainView.WindowState = WindowState.Minimized;
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => MainView.DragMove();

    }
}

