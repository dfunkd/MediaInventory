﻿#pragma checksum "..\..\..\UserControls\SearchMovies.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0782F41C5E45A03F8FC8D238E82ED573"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MediaInventory.UserControls;
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


namespace MediaInventory.UserControls {
    
    
    /// <summary>
    /// SearchMovies
    /// </summary>
    public partial class SearchMovies : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 9 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MediaInventory.UserControls.SearchMovies searchMovies;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MediaInventory.UserControls.AnimatedWatermarkTextBox txtSearchCriteria;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoFormat;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoStatus;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoOwned;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdoWanted;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UserControls\SearchMovies.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMovies;
        
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
            System.Uri resourceLocater = new System.Uri("/MediaInventory;component/usercontrols/searchmovies.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\SearchMovies.xaml"
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
            this.searchMovies = ((MediaInventory.UserControls.SearchMovies)(target));
            
            #line 8 "..\..\..\UserControls\SearchMovies.xaml"
            this.searchMovies.Loaded += new System.Windows.RoutedEventHandler(this.searchMovies_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtSearchCriteria = ((MediaInventory.UserControls.AnimatedWatermarkTextBox)(target));
            return;
            case 3:
            this.rdoFormat = ((System.Windows.Controls.RadioButton)(target));
            
            #line 32 "..\..\..\UserControls\SearchMovies.xaml"
            this.rdoFormat.Click += new System.Windows.RoutedEventHandler(this.OnGroupByChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rdoStatus = ((System.Windows.Controls.RadioButton)(target));
            
            #line 33 "..\..\..\UserControls\SearchMovies.xaml"
            this.rdoStatus.Click += new System.Windows.RoutedEventHandler(this.OnGroupByChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.rdoOwned = ((System.Windows.Controls.RadioButton)(target));
            
            #line 34 "..\..\..\UserControls\SearchMovies.xaml"
            this.rdoOwned.Click += new System.Windows.RoutedEventHandler(this.OnGroupByChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.rdoWanted = ((System.Windows.Controls.RadioButton)(target));
            
            #line 35 "..\..\..\UserControls\SearchMovies.xaml"
            this.rdoWanted.Click += new System.Windows.RoutedEventHandler(this.OnGroupByChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgMovies = ((System.Windows.Controls.DataGrid)(target));
            
            #line 39 "..\..\..\UserControls\SearchMovies.xaml"
            this.dgMovies.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgMovies_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\UserControls\SearchMovies.xaml"
            this.dgMovies.GotFocus += new System.Windows.RoutedEventHandler(this.dgMovies_GotFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 8:
            
            #line 52 "..\..\..\UserControls\SearchMovies.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.OnExpandClick);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 90 "..\..\..\UserControls\SearchMovies.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 96 "..\..\..\UserControls\SearchMovies.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Click += new System.Windows.RoutedEventHandler(this.rdoIsCheckedOut_Click);
            
            #line default
            #line hidden
            break;
            case 11:
            
            #line 125 "..\..\..\UserControls\SearchMovies.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanOwnedWantedClick);
            
            #line default
            #line hidden
            
            #line 125 "..\..\..\UserControls\SearchMovies.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OwnedWantedClickExecuted);
            
            #line default
            #line hidden
            break;
            case 12:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseLeftButtonDownEvent;
            
            #line 175 "..\..\..\UserControls\SearchMovies.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.OnSelectRowDetails);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

