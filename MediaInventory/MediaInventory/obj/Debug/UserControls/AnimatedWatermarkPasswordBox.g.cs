﻿#pragma checksum "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0A0534AB99FF539D29FFD6E8D41333BD"
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
    /// AnimatedWatermarkPasswordBox
    /// </summary>
    public partial class AnimatedWatermarkPasswordBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MediaInventory.UserControls.AnimatedWatermarkPasswordBox animatedWatermarkPasswordBox;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbHeader;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox pwbContent;
        
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
            System.Uri resourceLocater = new System.Uri("/MediaInventory;component/usercontrols/animatedwatermarkpasswordbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
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
            this.animatedWatermarkPasswordBox = ((MediaInventory.UserControls.AnimatedWatermarkPasswordBox)(target));
            return;
            case 2:
            this.tbHeader = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.pwbContent = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 14 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
            this.pwbContent.GotFocus += new System.Windows.RoutedEventHandler(this.OnPasswordBoxGofFocus);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\UserControls\AnimatedWatermarkPasswordBox.xaml"
            this.pwbContent.LostFocus += new System.Windows.RoutedEventHandler(this.OnPasswordBoxLostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

