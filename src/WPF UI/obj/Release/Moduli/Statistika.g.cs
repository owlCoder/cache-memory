﻿#pragma checksum "..\..\..\Moduli\Statistika.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "95B05C95C1A05185C9B10C5410AB5F5DDFE1C8D35AA839E8E93ED986FF3CEF68"
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
using WPF_UI.Moduli;


namespace WPF_UI.Moduli {
    
    
    /// <summary>
    /// Statistika
    /// </summary>
    public partial class Statistika : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox kriterijumPretrage;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock labela;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox unosId;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel meniMesec;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox mesecPotrosnje;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button prikazPodataka;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Moduli\Statistika.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dataViewDb;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF UI;component/moduli/statistika.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Moduli\Statistika.xaml"
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
            this.kriterijumPretrage = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\Moduli\Statistika.xaml"
            this.kriterijumPretrage.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.kriterijumPretrage_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.labela = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.unosId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.meniMesec = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.mesecPotrosnje = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.prikazPodataka = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Moduli\Statistika.xaml"
            this.prikazPodataka.Click += new System.Windows.RoutedEventHandler(this.prikazPodataka_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataViewDb = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
