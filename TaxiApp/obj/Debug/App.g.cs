<<<<<<< HEAD
﻿#pragma checksum "..\..\App.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9CC7C190715E227FCB65A6EDF2A03236FA738A6D00C123FB481F0334720F1F52"
=======
﻿#pragma checksum "..\..\App.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "285E550F62554163263BB74514EB466AF09AB0BCE913EA6F9D740960A835EBAC"
>>>>>>> a7fc0c65240d445a3821ec1c6987798b1db0a80e
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TaxiApp;


namespace TaxiApp {
    
    
    /// <summary>
    /// App
    /// </summary>
    public partial class App : System.Windows.Application {
        
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
            
<<<<<<< HEAD
            #line 8 "..\..\App.xaml"
            this.StartupUri = new System.Uri("Views/SignInPage.xaml", System.UriKind.Relative);
=======
            #line 5 "..\..\App.xaml"
            this.StartupUri = new System.Uri("Views/MainView.xaml", System.UriKind.Relative);
>>>>>>> a7fc0c65240d445a3821ec1c6987798b1db0a80e
            
            #line default
            #line hidden
            System.Uri resourceLocater = new System.Uri("/TaxiApp;component/app.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\App.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main() {
            TaxiApp.App app = new TaxiApp.App();
            app.InitializeComponent();
            app.Run();
        }
    }
}

