#pragma checksum "..\..\..\Views\ListPerson.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CEF0C06964B19743708449355BE21E65D53FC39"
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
using UniversityWPF.Views;


namespace UniversityWPF.Views {
    
    
    /// <summary>
    /// ListPerson
    /// </summary>
    public partial class ListPerson : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 29 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid datagridPerson;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnAction;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CrearBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BuscarBtn;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel content;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Views\ListPerson.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameSearch_txt;
        
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
            System.Uri resourceLocater = new System.Uri("/UniversityWPF;component/views/listperson.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\ListPerson.xaml"
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
            case 3:
            this.datagridPerson = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.ColumnAction = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 5:
            this.CrearBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Views\ListPerson.xaml"
            this.CrearBtn.Click += new System.Windows.RoutedEventHandler(this.CrearBtn_Click_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BuscarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Views\ListPerson.xaml"
            this.BuscarBtn.Click += new System.Windows.RoutedEventHandler(this.BuscarBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.content = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.nameSearch_txt = ((System.Windows.Controls.TextBox)(target));
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
            switch (connectionId)
            {
            case 1:
            
            #line 15 "..\..\..\Views\ListPerson.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditBtn_Click);
            
            #line default
            #line hidden
            break;
            case 2:
            
            #line 17 "..\..\..\Views\ListPerson.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

