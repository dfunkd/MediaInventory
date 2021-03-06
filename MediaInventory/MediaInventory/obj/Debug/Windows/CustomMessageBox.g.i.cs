﻿#pragma checksum "..\..\..\Windows\CustomMessageBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "916EAD0416C89C287D2EE1CB9DE52C4E"
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


namespace MediaInventory.Windows {
    
    
    /// <summary>
    /// CustomMessageBox
    /// </summary>
    public partial class CustomMessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MediaInventory.Windows.CustomMessageBox messageWindow;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bdrMessage;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border bdrHeader;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbHeader;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image messageBoxImage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbMessage;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button messageYesButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button messageNoButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button messageOKButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Windows\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button messageCancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/MediaInventory;component/windows/custommessagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\CustomMessageBox.xaml"
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
            this.messageWindow = ((MediaInventory.Windows.CustomMessageBox)(target));
            return;
            case 2:
            this.bdrMessage = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.bdrHeader = ((System.Windows.Controls.Border)(target));
            
            #line 19 "..\..\..\Windows\CustomMessageBox.xaml"
            this.bdrHeader.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DragWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.messageBoxImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.tbMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.messageYesButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Windows\CustomMessageBox.xaml"
            this.messageYesButton.Click += new System.Windows.RoutedEventHandler(this.messageYesButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.messageNoButton = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Windows\CustomMessageBox.xaml"
            this.messageNoButton.Click += new System.Windows.RoutedEventHandler(this.messageNoButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.messageOKButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Windows\CustomMessageBox.xaml"
            this.messageOKButton.Click += new System.Windows.RoutedEventHandler(this.messageOKButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.messageCancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Windows\CustomMessageBox.xaml"
            this.messageCancelButton.Click += new System.Windows.RoutedEventHandler(this.messageCancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

