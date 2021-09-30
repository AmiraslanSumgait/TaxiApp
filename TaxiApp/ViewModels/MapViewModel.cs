//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using Esri.ArcGISRuntime.Geometry;
//using Esri.ArcGISRuntime.Mapping;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using Esri.ArcGISRuntime.UI;
//using Esri.ArcGISRuntime.Symbology;
//using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
//using System.Windows;

//namespace TaxiApp.ViewModels
//{
//    public class MapViewModel
//    {
//        enum RouteBuilderStatus
//        {
//            NotStarted, // No locations have been defined.
//            SelectedStart, // Origin point exists.
//            SelectedStartAndEnd // Origin and destination exist.
//        }
//        private RouteBuilderStatus _currentState = RouteBuilderStatus.NotStarted;

//        private Graphic _startGraphic;
//        private Graphic _endGraphic;
//        private Graphic _routeGraphic;
//        public MapViewModel()
//        {
//            SetupMap();
//        }

//        public event PropertyChangedEventHandler PropertyChanged;
//        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        private Map _map;
//        public Map Map
//        {
//            get { return _map; }
//            set
//            {
//                _map = value;
//                OnPropertyChanged();
//            }
//        }

//        private GraphicsOverlayCollection _graphicsOverlayCollection;
//        public GraphicsOverlayCollection GraphicsOverlays
//        {
//            get { return _graphicsOverlayCollection; }
//            set
//            {
//                _graphicsOverlayCollection = value;
//                OnPropertyChanged();
//            }
//        }

//        //private List<string> _directions;
//        //public List<string> Directions
//        //{
//        //    get { return _directions; }
//        //    set
//        //    {
//        //        _directions = value;
//        //        OnPropertyChanged();
//        //    }
//        //}

//        private void SetupMap()
//        {

//            Map = new Map(BasemapStyle.ArcGISStreets);

//            GraphicsOverlay routeAndStopsOverlay = new GraphicsOverlay();
//            this.GraphicsOverlays = new GraphicsOverlayCollection
//            {
//                routeAndStopsOverlay
//            };


//            var startOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.White, width: 5);
//            _startGraphic = new Graphic(null, new SimpleMarkerSymbol
//            {
//                Style = SimpleMarkerSymbolStyle.Circle,
//                Color = System.Drawing.Color.LightGreen,
//                Size = 28,
//                Outline = startOutlineSymbol
//            }
//            );

//            var endOutlineSymbol = new SimpleLineSymbol(style: SimpleLineSymbolStyle.Solid, color: System.Drawing.Color.White, width: 5);
//            _endGraphic = new Graphic(null, new SimpleMarkerSymbol
//            {
//                Style = SimpleMarkerSymbolStyle.Circle,
//                Color = System.Drawing.Color.BlueViolet,
//                Size = 28,
//                Outline = endOutlineSymbol
//            }
//            );

//            _routeGraphic = new Graphic(null, new SimpleLineSymbol(
//                style: SimpleLineSymbolStyle.Solid,
//                color: System.Drawing.Color.Blue,
//                width: 4
//            ));

//            routeAndStopsOverlay.Graphics.AddRange(new[] { _startGraphic, _endGraphic, _routeGraphic });

//        }

//        private void ResetState()
//        {
//            _startGraphic.Geometry = null;
//            _endGraphic.Geometry = null;
//            _routeGraphic.Geometry = null;
//            //Directions = null;
//            _currentState = RouteBuilderStatus.NotStarted;
//        }

//        public async Task FindRoute()
//        {
//            var stops = new[] { _startGraphic, _endGraphic }.Select(graphic => new Stop(graphic.Geometry as MapPoint));

//            var routeTask = await RouteTask.CreateAsync(new Uri("https://route-api.arcgis.com/arcgis/rest/services/World/Route/NAServer/Route_World"));
//            RouteParameters parameters = await routeTask.CreateDefaultParametersAsync();
//            parameters.SetStops(stops);
//            parameters.ReturnDirections = true;
//            parameters.ReturnRoutes = true;

//            var result = await routeTask.SolveRouteAsync(parameters);

//            if (result?.Routes?.FirstOrDefault() is Route routeResult)
//            {
//                _routeGraphic.Geometry = routeResult.RouteGeometry;
//                //Directions = routeResult.DirectionManeuvers.Select(maneuver => maneuver.DirectionText).ToList();
//                _currentState = RouteBuilderStatus.NotStarted;
//            }
//            else
//            {
//                ResetState();
//                throw new Exception("Route not found");
//            }
//        }

//        public async Task HandleTap(MapPoint tappedPoint)
//        {
//            switch (_currentState)
//            {
//                case RouteBuilderStatus.NotStarted:
//                    ResetState();
//                    _startGraphic.Geometry = tappedPoint;
//                    _currentState = RouteBuilderStatus.SelectedStart;
//                    break;
//                case RouteBuilderStatus.SelectedStart:
//                    _endGraphic.Geometry = tappedPoint;
//                    _currentState = RouteBuilderStatus.SelectedStartAndEnd;
//                    await FindRoute();
//                    break;
//                case RouteBuilderStatus.SelectedStartAndEnd:
//                    // Ignore map clicks while routing is in progress
//                    break;
//            }
//        }

        
//    }
//}
