﻿#pragma checksum "..\..\..\Forms\FormPerson.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "539F58C9C597ED3D8DB9151E8B3EEA2BFF215103"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
using UniversityWPF.Forms;


namespace UniversityWPF.Forms {
    
    
    /// <summary>
    /// FormPerson
    /// </summary>
    public partial class FormPerson : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CrearBtn;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editarBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox id_txt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox doc_txt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name1_txt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastname1_txt;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_txt;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name2_txt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lastname2_txt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LImpiarBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Forms\FormPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isActivo_Check;
        
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
            System.Uri resourceLocater = new System.Uri("/UniversityWPF;component/forms/formperson.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\FormPerson.xaml"
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
            this.CrearBtn = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Forms\FormPerson.xaml"
            this.CrearBtn.Click += new System.Windows.RoutedEventHandler(this.CrearBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.editarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Forms\FormPerson.xaml"
            this.editarBtn.Click += new System.Windows.RoutedEventHandler(this.EditarBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.id_txt = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.doc_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.name1_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.lastname1_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.date_txt = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.name2_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.lastname2_txt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.LImpiarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Forms\FormPerson.xaml"
            this.LImpiarBtn.Click += new System.Windows.RoutedEventHandler(this.LImpiarBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.isActivo_Check = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

