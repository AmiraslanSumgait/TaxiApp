﻿#pragma checksum "..\..\..\Views\MainView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "196E4D1A076A10F9760725B4760D01D7C0481C1C673698F2E7EB0485D5E08949"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TaxiApp.Views {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Esri.ArcGISRuntime.UI.Controls.MapView MyMapView;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_menu;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition girc_column0;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasMenu;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOpenMenu;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCloseMenu;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_payment;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_rideHistory;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_support;
        
        #line default
        #line hidden
        
        
        #line 233 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_about;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitAppButton;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_exit;
        
        #line default
        #line hidden
        
        
        #line 274 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartNavigationButton;
        
        #line default
        #line hidden
        
        
        #line 284 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RecenterButton;
        
        #line default
        #line hidden
        
        
        #line 299 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchAddressButton;
        
        #line default
        #line hidden
        
        
        #line 335 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessagesTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaxiApp;component/views/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MainView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MyMapView = ((Esri.ArcGISRuntime.UI.Controls.MapView)(target));
            return;
            case 2:
            this.grid_menu = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.girc_column0 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 4:
            this.CanvasMenu = ((System.Windows.Controls.Canvas)(target));
            return;
            case 5:
            this.buttonOpenMenu = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.buttonCloseMenu = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.lbl_payment = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbl_rideHistory = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lbl_support = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lbl_about = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ExitAppButton = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.lbl_exit = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.StartNavigationButton = ((System.Windows.Controls.Button)(target));
            return;
            case 14:
            this.RecenterButton = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.SearchAddressButton = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.MessagesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

