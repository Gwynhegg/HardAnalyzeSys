﻿#pragma checksum "..\..\..\Input\CreationParams.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87FC4484208EA8548E2E4C3F66CE0E4905539FD2B55547D40D829CB0B908A1A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HardAnalyzeSys.Input;
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


namespace HardAnalyzeSys.Input {
    
    
    /// <summary>
    /// CreationParams
    /// </summary>
    public partial class CreationParams : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Input\CreationParams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edit_params;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Input\CreationParams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox edit_elements;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Input\CreationParams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_create;
        
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
            System.Uri resourceLocater = new System.Uri("/HardAnalyzeSys;component/input/creationparams.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Input\CreationParams.xaml"
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
            this.edit_params = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Input\CreationParams.xaml"
            this.edit_params.GotFocus += new System.Windows.RoutedEventHandler(this.edit_params_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.edit_elements = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Input\CreationParams.xaml"
            this.edit_elements.GotFocus += new System.Windows.RoutedEventHandler(this.edit_elements_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_create = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Input\CreationParams.xaml"
            this.btn_create.Click += new System.Windows.RoutedEventHandler(this.btnCreateTable);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
