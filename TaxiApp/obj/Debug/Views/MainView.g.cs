﻿#pragma checksum "..\..\..\Views\MainView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99D9FDD3CEBF9F00AC0E206FD9BFEAE044AD50934071729BFAFE8E46373F64C6"
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
using TaxiApp.Views;


namespace TaxiApp.Views {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 77 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_close;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_max;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_min;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Esri.ArcGISRuntime.UI.Controls.MapView MyMapView;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid_menu;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition girc_column0;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasMenu;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonOpenMenu;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCloseMenu;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_payment;
        
        #line default
        #line hidden
        
        
        #line 256 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_rideHistory;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_support;
        
        #line default
        #line hidden
        
        
        #line 310 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_about;
        
        #line default
        #line hidden
        
        
        #line 314 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitAppButton;
        
        #line default
        #line hidden
        
        
        #line 338 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_exit;
        
        #line default
        #line hidden
        
        
        #line 361 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_info;
        
        #line default
        #line hidden
        
        
        #line 366 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon mater;
        
        #line default
        #line hidden
        
        
        #line 388 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RecenterButton;
        
        #line default
        #line hidden
        
        
        #line 423 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 443 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchAddressButton;
        
        #line default
        #line hidden
        
        
        #line 456 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessagesTextBlock;
        
        #line default
        #line hidden
        
        
        #line 474 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TaxiApp.Views.InfoUC InfoUcPanel;
        
        #line default
        #line hidden
        
        
        #line 481 "..\..\..\Views\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartNavigationButton;
        
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
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.btn_close = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.btn_max = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btn_min = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.MyMapView = ((Esri.ArcGISRuntime.UI.Controls.MapView)(target));
            return;
            case 5:
            this.grid_menu = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.girc_column0 = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 7:
            this.CanvasMenu = ((System.Windows.Controls.Canvas)(target));
            return;
            case 8:
            this.buttonOpenMenu = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.buttonCloseMenu = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.lbl_payment = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lbl_rideHistory = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.lbl_support = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.lbl_about = ((System.Windows.Controls.Label)(target));
            return;
            case 14:
            this.ExitAppButton = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.lbl_exit = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.btn_info = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.mater = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 18:
            this.RecenterButton = ((System.Windows.Controls.Button)(target));
            return;
            case 19:
            this.AddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 20:
            this.SearchAddressButton = ((System.Windows.Controls.Button)(target));
            return;
            case 21:
            this.MessagesTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 22:
            this.InfoUcPanel = ((TaxiApp.Views.InfoUC)(target));
            return;
            case 23:
            this.StartNavigationButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

