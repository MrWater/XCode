﻿#pragma checksum "..\..\..\View\TemplateEditView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AE9AA583DCBEB54FF15248A72BA014EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using XCode.Module.SimplePS.Common;
using XCode.Module.SimplePS.Layer;
using XCode.Module.SimplePS.View;
using XCode.Module.SimplePS.ViewModel;


namespace XCode.Module.SimplePS.View {
    
    
    /// <summary>
    /// TemplateEditView
    /// </summary>
    public partial class TemplateEditView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 105 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PaintTool;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ToolPanel;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBDrag;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBRectangle;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBTriangle;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBCircle;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBLine;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBImage;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBText;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RBQRCode;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Container;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal XCode.Module.SimplePS.Common.DrawingCanvas CvsRoot;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StateInfo;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CoordX;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CoordY;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer TabItemGeometryProperty;
        
        #line default
        #line hidden
        
        
        #line 223 "..\..\..\View\TemplateEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LayerGroup;
        
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
            System.Uri resourceLocater = new System.Uri("/XCode.Module.SimplePS;component/view/templateeditview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\TemplateEditView.xaml"
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
            case 2:
            this.PaintTool = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.ToolPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.RBDrag = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.RBRectangle = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.RBTriangle = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.RBCircle = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.RBLine = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.RBImage = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.RBText = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.RBQRCode = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.Container = ((System.Windows.Controls.Grid)(target));
            return;
            case 13:
            this.CvsRoot = ((XCode.Module.SimplePS.Common.DrawingCanvas)(target));
            return;
            case 14:
            this.StateInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.CoordX = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.CoordY = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            this.TabItemGeometryProperty = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 18:
            this.LayerGroup = ((System.Windows.Controls.ListBox)(target));
            
            #line 225 "..\..\..\View\TemplateEditView.xaml"
            this.LayerGroup.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LayerGroup_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 255 "..\..\..\View\TemplateEditView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveLayer_Click);
            
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
            case 1:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ToggleButton.CheckedEvent;
            
            #line 17 "..\..\..\View\TemplateEditView.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.ToolSeletedChanged);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

