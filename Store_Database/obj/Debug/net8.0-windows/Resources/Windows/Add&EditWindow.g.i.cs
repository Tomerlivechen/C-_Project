﻿#pragma checksum "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63E6F65A6536A03FE0A397020C58CCF7D752874F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Store_Database.Resources.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Store_Database.Resources.Windows {
    
    
    /// <summary>
    /// Add_EditWindow
    /// </summary>
    public partial class Add_EditWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemName_text;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Amount_text;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinAmount_text;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Updater_text;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Catagories1;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Catagories1_text;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Catagories2;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Catagories2_text;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Store_Database;V1.0.0.0;component/resources/windows/add&editwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.ItemName_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Amount_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MinAmount_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Updater_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 44 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Catagories1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
            this.Catagories1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Catagories1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Catagories1_text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.Catagories2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\..\..\Resources\Windows\Add&EditWindow.xaml"
            this.Catagories2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Catagories2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Catagories2_text = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

