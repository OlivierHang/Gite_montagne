﻿#pragma checksum "..\..\Modification.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B7166FBAFCEB52266446C35C8C3900303152E32875FCDFBA9DDFD5A0EFC5C9DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjetWPF;
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


namespace ProjetWPF {
    
    
    /// <summary>
    /// Modification
    /// </summary>
    public partial class Modification : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxIdRes;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerArriver;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxDuree;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxHebergement;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjoutHebergement;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxHebergementChoix;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSupprHebergement;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNomPersonne;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Modification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnuler;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjetWPF;component/modification.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Modification.xaml"
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
            
            #line 8 "..\..\Modification.xaml"
            ((ProjetWPF.Modification)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.comboBoxIdRes = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\Modification.xaml"
            this.comboBoxIdRes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxIdRes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.datePickerArriver = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.textBoxDuree = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Modification.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBoxHebergement = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.btnAjoutHebergement = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Modification.xaml"
            this.btnAjoutHebergement.Click += new System.Windows.RoutedEventHandler(this.btnAjoutHebergement_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.comboBoxHebergementChoix = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.btnSupprHebergement = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Modification.xaml"
            this.btnSupprHebergement.Click += new System.Windows.RoutedEventHandler(this.btnSupprHebergement_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textBoxNomPersonne = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Modification.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnAnnuler = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Modification.xaml"
            this.btnAnnuler.Click += new System.Windows.RoutedEventHandler(this.btnAnnuler_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

