using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Navigation;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Device.Location;
using System.Linq;
using System.Runtime.CompilerServices;
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
    // <summary>
    //Interaction logic for MainView.xaml
    //</summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public partial class MainWindow : Window
    //{
    //    enum RouteBuilderStatus
    //    {
    //        NotStarted, // No locations have been defined.
    //        SelectedStart, // Origin point exists.
    //        SelectedStartAndEnd // Origin and destination exist.
    //    }
    //    private RouteBuilderStatus _currentState = RouteBuilderStatus.NotStarted;

    //    public Map MyMap { get; set; }

    //    private Graphic _startGraphic;
    //    private Graphic _endGraphic;
    //    private Graphic _routeGraphic;

    //    public GraphicsOverlayCollection GraphicsOverlays { get; set; }
    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //        SetupMap();
    //    }
    //    private void SetupMap()
    //    {
    //        Map myMap = new Map(BasemapStyle.OSMStreets);
    //        MyMap.Map = myMap;
    //        MyMap.SetViewpoint(new Viewpoint(40.4092, 49.8670, 144_447.638572));

    //        GraphicsOverlay routeAndStopsOverlay = new GraphicsOverlay();
    //        this.GraphicsOverlays = new GraphicsOverlayCollection
    //        {
    //            routeAndStopsOverlay
    //        };

    //        var startOutlineSymbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, System.Drawing.Color.Blue, 2);
    //        _startGraphic = new Graphic(null, new SimpleMarkerSymbol
    //        {
    //            Style = SimpleMarkerSymbolStyle.Diamond,
    //            Color = System.Drawing.Color.Orange,
    //            Size = 8,
    //            Outline = startOutlineSymbol
    //        }
    //        );

    //        var endOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.Red, width: 2);
    //        _endGraphic = new Graphic(null, new SimpleMarkerSymbol
    //        {
    //            Style = SimpleMarkerSymbolStyle.Square,
    //            Color = System.Drawing.Color.Green,
    //            Size = 8,
    //            Outline = endOutlineSymbol
    //        }
    //        );

    //        _routeGraphic = new Graphic(null, new SimpleLineSymbol(
    //            style: SimpleLineSymbolStyle.Solid,
    //            color: System.Drawing.Color.Blue,
    //            width: 4
    //        ));

    //        routeAndStopsOverlay.Graphics.AddRange(new[] { _startGraphic, _endGraphic, _routeGraphic });

    //    }

    //    public async void MainMapView_GeoViewTapped(object sender, GeoViewInputEventArgs e)
    //    {
    //        try
    //        {
    //            await HandleTap(e.Location);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Error", ex.Message);
    //        }
    //    }

    //    public async Task HandleTap(MapPoint tappedPoint)
    //    {
    //        switch (_currentState)
    //        {
    //            case RouteBuilderStatus.NotStarted:
    //                _startGraphic.Geometry = tappedPoint;
    //                _currentState = RouteBuilderStatus.SelectedStart;
    //                break;
    //            case RouteBuilderStatus.SelectedStart:
    //                _endGraphic.Geometry = tappedPoint;
    //                _currentState = RouteBuilderStatus.SelectedStartAndEnd;
    //                await FindRoute();
    //                break;
    //            case RouteBuilderStatus.SelectedStartAndEnd:
    //                // Ignore map clicks while routing is in progress
    //                break;
    //        }
    //    }

    //    public async Task FindRoute()
    //    {

    //        var stops = new[] { _startGraphic, _endGraphic }.Select(graphic => new Stop(graphic.Geometry as MapPoint));

    //        var routeTask = await RouteTask.CreateAsync(new Uri("https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World"));
    //        RouteParameters parameters = await routeTask.CreateDefaultParametersAsync();
    //        parameters.SetStops(stops);
    //        parameters.ReturnDirections = true;
    //        parameters.ReturnRoutes = true;

    //        var result = await routeTask.SolveRouteAsync(parameters);

    //        if (result?.Routes?.FirstOrDefault() is Route routeResult)
    //        {
    //            _routeGraphic.Geometry = routeResult.RouteGeometry;
    //            _currentState = RouteBuilderStatus.NotStarted;
    //        }
    //        else
    //        {
    //            //ResetState();
    //            throw new Exception("Route not found");
    //        }

    //    }


    //}

    public partial class MainView : Window, INotifyPropertyChanged
    {
        private Graphic _startGraphic;
        private Graphic _endGraphic;
        private Graphic _routeGraphic;

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
        private Graphic _routeTraveledGraphic;

        // San Diego Convention Center.
        //private readonly MapPoint _conventionCenter = new MapPoint(-117.160386727, 32.706608, SpatialReferences.Wgs84);

        // USS San Diego Memorial.
        //private readonly MapPoint _memorial = new MapPoint(49.940541, 40.447328, SpatialReferences.Wgs84);

        // RH Fleet Aerospace Museum.
        // private readonly MapPoint _aerospaceMuseum = new MapPoint(49.883464, 40.435831, SpatialReferences.Wgs84);

        // Feature service for routing in San Diego.
        private readonly Uri _routingUri = new Uri("https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World");
        public MainView()
        {
            InitializeComponent();
            DataContext = this;
            Initialize();
            MyMap = new Map(BasemapStyle.ArcGISNavigation);
            
            GraphicsOverlay routeAndStopsOverlay = new GraphicsOverlay();
            this.GraphicsOverlays = new GraphicsOverlayCollection
                {
                routeAndStopsOverlay
                };


            var startOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.White, width: 2);
            _startGraphic = new Graphic(null, new SimpleMarkerSymbol
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = System.Drawing.Color.Red,
                Size = 18,
                Outline = startOutlineSymbol
            }
            );

            var endOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.White, width: 2);
            _endGraphic = new Graphic(null, new SimpleMarkerSymbol
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = System.Drawing.Color.Green,
                Size = 18,
                Outline = endOutlineSymbol
            }
            );

            _routeGraphic = new Graphic(null, new SimpleLineSymbol(
                style: SimpleLineSymbolStyle.Solid,
                color: System.Drawing.Color.Blue,
                width: 4
            ));

            routeAndStopsOverlay.Graphics.AddRange(new[] { _startGraphic, _endGraphic, _routeGraphic });
        }
        private void Initialize()
        {
            try
            {

                // Add event handler for when this sample is unloaded.
                Unloaded += SampleUnloaded;

                // Create the map view.
                //MyMapView.Map = new Map(BasemapStyle.ArcGISNavigation);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //GraphicsOverlay routeAndStopsOverlay = new GraphicsOverlay();
                //this.GraphicsOverlays = new GraphicsOverlayCollection
                //{
                //routeAndStopsOverlay
                //};


                //var startOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.White, width: 2);
                //_startGraphic = new Graphic(null, new SimpleMarkerSymbol
                //{
                //    Style = SimpleMarkerSymbolStyle.Circle,
                //    Color = System.Drawing.Color.LightGreen,
                //    Size = 8,
                //    Outline = startOutlineSymbol
                //}
                //);

                //var endOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.BlueViolet, width: 2);
                //_endGraphic = new Graphic(null, new SimpleMarkerSymbol
                //{
                //    Style = SimpleMarkerSymbolStyle.Square,
                //    Color = System.Drawing.Color.Green,
                //    Size = 8,
                //    Outline = endOutlineSymbol
                //}
                //);

                //_routeGraphic = new Graphic(null, new SimpleLineSymbol(
                //    style: SimpleLineSymbolStyle.Solid,
                //    color: System.Drawing.Color.Blue,
                //    width: 4
                //));

                //routeAndStopsOverlay.Graphics.AddRange(new[] { _startGraphic, _endGraphic, _routeGraphic });

                //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // Create the route task, using the online routing service.
                //RouteTask routeTask = await RouteTask.CreateAsync(_routingUri);

                // Get the default route parameters.
                //RouteParameters routeParams = await routeTask.CreateDefaultParametersAsync();

                // Explicitly set values for parameters.
                //routeParams.ReturnDirections = true;
                //routeParams.ReturnStops = true;
                //routeParams.ReturnRoutes = true;
                //routeParams.OutputSpatialReference = SpatialReferences.Wgs84;

                // Create stops for each location.
                //Stop stop1 = new Stop(_conventionCenter) { Name = "San Diego Convention Center" };
                //Stop stop2 = new Stop(_startGraphic.Geometry as MapPoint);
                //Stop stop3 = new Stop(_endGraphic.Geometry as MapPoint);

                //// Assign the stops to the route parameters.
                //List<Stop> stopPoints = new List<Stop> { stop2, stop3 };
                //routeParams.SetStops(stopPoints);

                //// Get the route results.
                //_routeResult = await routeTask.SolveRouteAsync(routeParams);
                //_route = _routeResult.Routes[0];

                // Add a graphics overlay for the route graphics.
                //MyMapView.GraphicsOverlays.Add(new GraphicsOverlay());


                //// Add graphics for the stops.
                //SimpleMarkerSymbol stopSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, System.Drawing.Color.LightGreen, 20);
                //SimpleMarkerSymbol endSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Cross, System.Drawing.Color.Green, 20);
                //// MyMapView.GraphicsOverlays[0].Graphics.Add(new Graphic(_conventionCenter, stopSymbol));
                //MyMapView.GraphicsOverlays[0].Graphics.Add(new Graphic(_startGraphic.Geometry, stopSymbol));
                //MyMapView.GraphicsOverlays[0].Graphics.Add(new Graphic(_endGraphic.Geometry, endSymbol));

                //// Create a graphic (with a dashed line symbol) to represent the route.
                //_routeAheadGraphic = new Graphic(_route.RouteGeometry) { Symbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, System.Drawing.Color.LightBlue, 5) };

                //// Create a graphic (solid) to represent the route that's been traveled (initially empty).
                //_routeTraveledGraphic = new Graphic { Symbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Null, System.Drawing.Color.LightBlue, 3) };

                //// Add the route graphics to the map view.
                //MyMapView.GraphicsOverlays[0].Graphics.Add(_routeAheadGraphic);
                //MyMapView.GraphicsOverlays[0].Graphics.Add(_routeTraveledGraphic);

                //// Set the map viewpoint to show the entire route.
                //await MyMapView.SetViewpointGeometryAsync(_route.RouteGeometry, 100);

                //// Enable the navigation button.
                //StartNavigationButton.IsEnabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void ResetState()
        {
            _startGraphic.Geometry = null;
            _endGraphic.Geometry = null;
            _routeGraphic.Geometry = null;

            _currentState = RouteBuilderStatus.NotStarted;
        }
        public async Task FindRoute()
        {

            var stops = new[] { _startGraphic, _endGraphic }.Select(graphic => new Stop(graphic.Geometry as MapPoint));

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
                _routeGraphic.Geometry = routeResult.RouteGeometry;
                _currentState = RouteBuilderStatus.NotStarted;
            }
            else
            {
                ResetState();
                throw new Exception("Route not found");
            }

            _routeAheadGraphic = new Graphic(_route.RouteGeometry) { Symbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, System.Drawing.Color.LightBlue, 5) };

            // Create a graphic (solid) to represent the route that's been traveled (initially empty).
            _routeTraveledGraphic = new Graphic { Symbol = new SimpleLineSymbol(SimpleLineSymbolStyle.Null, System.Drawing.Color.LightBlue, 3) };

            // Add the route graphics to the map view.
            MyMapView.GraphicsOverlays[0].Graphics.Add(_routeAheadGraphic);
            MyMapView.GraphicsOverlays[0].Graphics.Add(_routeTraveledGraphic);

            // Set the map viewpoint to show the entire route.
            await MyMapView.SetViewpointGeometryAsync(_route.RouteGeometry, 100);

            // Enable the navigation button.
            StartNavigationButton.IsEnabled = true;

        }

        public async void MainMapView_GeoViewTapped(object sender, GeoViewInputEventArgs e)
        {
            try
            {

                await HandleTap(e.Location);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }
        }


        public async Task HandleTap(MapPoint tappedPoint)
        {
            switch (_currentState)
            {
                case RouteBuilderStatus.NotStarted:
                    ResetState();
                    _startGraphic.Geometry = tappedPoint;
                    _currentState = RouteBuilderStatus.SelectedStart;
                    break;
                case RouteBuilderStatus.SelectedStart:
                    _endGraphic.Geometry = tappedPoint;
                    _currentState = RouteBuilderStatus.SelectedStartAndEnd;
                    await FindRoute();
                    break;
                case RouteBuilderStatus.SelectedStartAndEnd:
                    // Ignore map clicks while routing is in progress
                    break;
            }
        }

        private void StartNavigation(object sender, RoutedEventArgs e)
        {

            // Disable the start navigation button.
            StartNavigationButton.IsEnabled = false;

            // Get the directions for the route.
            _directionsList = _route.DirectionManeuvers;

            // Create a route tracker.
            _tracker = new RouteTracker(_routeResult, 0, true);


            // Handle route tracking status changes.
            _tracker.TrackingStatusChanged += TrackingStatusUpdated;

            // Turn on navigation mode for the map view.
            MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;
            MyMapView.LocationDisplay.AutoPanModeChanged += AutoPanModeChanged;

            // Add a data source for the location display.
            var simulationParameters = new SimulationParameters(DateTimeOffset.Now, 40.0);
            var simulatedDataSource = new SimulatedLocationDataSource();
            simulatedDataSource.SetLocationsWithPolyline(_route.RouteGeometry, simulationParameters);
            MyMapView.LocationDisplay.DataSource = new RouteTrackerDisplayLocationDataSource(simulatedDataSource, _tracker);

            // Use this instead if you want real location:
            // MyMapView.LocationDisplay.DataSource = new RouteTrackerLocationDataSource(new SystemLocationDataSource(), _tracker);

            // Enable the location display (this wil start the location data source).
            MyMapView.LocationDisplay.IsEnabled = true;
        }

        private void TrackingStatusUpdated(object sender, RouteTrackerTrackingStatusChangedEventArgs e)
        {
            TrackingStatus status = e.TrackingStatus;

            // Start building a status message for the UI.
            System.Text.StringBuilder statusMessageBuilder = new System.Text.StringBuilder("Route Status:\n");

            // Check the destination status.
            if (status.DestinationStatus == DestinationStatus.NotReached || status.DestinationStatus == DestinationStatus.Approaching)
            {
                statusMessageBuilder.AppendLine("Distance remaining: " +
                                            status.RouteProgress.RemainingDistance.DisplayText + " " +
                                            status.RouteProgress.RemainingDistance.DisplayTextUnits.PluralDisplayName);

                statusMessageBuilder.AppendLine("Time remaining: " +
                                                status.RouteProgress.RemainingTime.ToString(@"hh\:mm\:ss"));

                if (status.CurrentManeuverIndex + 1 < _directionsList.Count)
                {
                    statusMessageBuilder.AppendLine("Next direction: " + _directionsList[status.CurrentManeuverIndex + 1].DirectionText);
                }

                // Set geometries for progress and the remaining route.
                _routeAheadGraphic.Geometry = status.RouteProgress.RemainingGeometry;
                _routeTraveledGraphic.Geometry = status.RouteProgress.TraversedGeometry;
            }
            else if (status.DestinationStatus == DestinationStatus.Reached)
            {
                statusMessageBuilder.AppendLine("Destination reached.");

                // Set the route geometries to reflect the completed route.
                _routeAheadGraphic.Geometry = null;
                _routeTraveledGraphic.Geometry = status.RouteResult.Routes[0].RouteGeometry;

                // Navigate to the next stop (if there are stops remaining).
                if (status.RemainingDestinationCount > 1)
                {
                    _tracker.SwitchToNextDestinationAsync();
                }
                else
                {
                    Dispatcher.BeginInvoke((Action)delegate ()
                    {
                        // Stop the simulated location data source.
                        MyMapView.LocationDisplay.DataSource.StopAsync();
                    });
                }
            }

            Dispatcher.BeginInvoke((Action)delegate ()
            {
                // Show the status information in the UI.
                MessagesTextBlock.Text = statusMessageBuilder.ToString();
            });
        }


        private void AutoPanModeChanged(object sender, LocationDisplayAutoPanMode e)
        {
            // Turn the recenter button on or off when the location display changes to or from navigation mode.
            RecenterButton.IsEnabled = e != LocationDisplayAutoPanMode.Navigation;
        }

        private void RecenterButton_Click(object sender, RoutedEventArgs e)
        {
            // Change the mapview to use navigation mode.
            MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;
        }

        private void SampleUnloaded(object sender, RoutedEventArgs e)
        {

            // Stop the tracker.
            if (_tracker != null)
            {
                _tracker.TrackingStatusChanged -= TrackingStatusUpdated;
                // _tracker.NewVoiceGuidance -= SpeakDirection;
                _tracker = null;
            }

            // Stop the location data source.
            MyMapView.LocationDisplay?.DataSource?.StopAsync();
        }
    }

    // This location data source uses an input data source and a route tracker.
    // The location source that it updates is based on the snapped-to-route location from the route tracker.
    public class RouteTrackerDisplayLocationDataSource : LocationDataSource
    {
        private LocationDataSource _inputDataSource;
        private RouteTracker _routeTracker;

        public RouteTrackerDisplayLocationDataSource(LocationDataSource dataSource, RouteTracker routeTracker)
        {
            // Set the data source
            _inputDataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));

            // Set the route tracker.
            _routeTracker = routeTracker ?? throw new ArgumentNullException(nameof(routeTracker));

            // Change the tracker location when the source location changes.
            _inputDataSource.LocationChanged += InputLocationChanged;

            // Update the location output when the tracker location updates.
            _routeTracker.TrackingStatusChanged += TrackingStatusChanged;
        }

        private void InputLocationChanged(object sender, Location e)
        {
            // Update the tracker location with the new location from the source (simulation or GPS).
            _routeTracker.TrackLocationAsync(e);
        }

        private void TrackingStatusChanged(object sender, RouteTrackerTrackingStatusChangedEventArgs e)
        {
            // Check if the tracking status has a location.
            if (e.TrackingStatus.DisplayLocation != null)
            {
                // Call the base method for LocationDataSource to update the location with the tracked (snapped to route) location.
                UpdateLocation(e.TrackingStatus.DisplayLocation);
            }
        }





        protected override Task OnStartAsync() => _inputDataSource.StartAsync();

        protected override Task OnStopAsync() => _inputDataSource.StartAsync();
    }



}
