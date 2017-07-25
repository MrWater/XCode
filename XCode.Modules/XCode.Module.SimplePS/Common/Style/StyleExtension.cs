using XCode.Module.SimplePS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace XCode.Module.SimplePS.Common.Style
{
    /// <summary>
    /// 工具扩展类
    /// </summary>
    internal static class StyleExtension
    {
        /// <summary>
        /// 得到属性编辑面板
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public static Panel GetEditorPanel(this IStyle tool, Orientation orientation = Orientation.Vertical)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = orientation;
            panel.DataContext = tool;

            var propertInfo = tool.GetType().GetProperties();
            foreach (var item in propertInfo)
            {
                var control = GetEditorControl(tool, item);

                if (control != null)
                {
                    panel.Children.Add(control);
                }
            }

            return panel;
        }

        /// <summary>
        /// 根据不同类型的属性得到不同控件
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static UIElement GetEditorControl(IStyle tool, PropertyInfo info)
        {
            StackPanel panel = new StackPanel();
            panel.Margin = new Thickness(5);
            panel.Orientation = Orientation.Horizontal;

            var styleAttr = info.GetCustomAttributes(typeof(StyleAttribute), true).FirstOrDefault();

            if (styleAttr != null)
            {
                StyleAttribute style = styleAttr as StyleAttribute;

                if (style.DisplayName != "")
                {
                    TextBlock textblock = new TextBlock();
                    textblock.Text = style.DisplayName + "：";
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    panel.Children.Add(textblock);
                }

                if (info.PropertyType == typeof(double))
                {
                    TextBox textbox = new TextBox();
                    textbox.VerticalAlignment = VerticalAlignment.Center;
                    textbox.Width = 40;
                    panel.Children.Add(textbox);

                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(info.Name);
                    bind.Mode = style.Editable ? BindingMode.TwoWay : BindingMode.OneWay;

                    textbox.SetBinding(TextBox.TextProperty, bind);

                    if(!style.Editable)
                    {
                        textbox.IsReadOnly = true;
                    }
                }
                else if (info.PropertyType == typeof(Point))
                {
                    TextBlock textX = new TextBlock() { Text = "X" };
                    textX.VerticalAlignment = VerticalAlignment.Center;
                    TextBox tbX = new TextBox();
                    tbX.VerticalAlignment = VerticalAlignment.Center;
                    tbX.Width = 40;

                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(info.Name + ".X");
                    bind.Mode = style.Editable ? BindingMode.TwoWay : BindingMode.OneWay;
                    bind.StringFormat = "0";
                    tbX.SetBinding(TextBox.TextProperty, bind);

                    TextBlock textY = new TextBlock() { Text = "Y" };
                    textY.Margin = new Thickness(5, 0, 0, 0);
                    textY.VerticalAlignment = VerticalAlignment.Center;

                    TextBox tbY = new TextBox();
                    tbY.VerticalAlignment = VerticalAlignment.Center;
                    tbY.Width = 40;

                    bind = new Binding();
                    bind.Path = new PropertyPath(info.Name + ".Y");
                    bind.Mode = style.Editable ? BindingMode.TwoWay : BindingMode.OneWay;
                    bind.StringFormat = "0";
                    tbY.SetBinding(TextBox.TextProperty, bind);

                    panel.Children.Add(textX);
                    panel.Children.Add(tbX);
                    panel.Children.Add(textY);
                    panel.Children.Add(tbY);
                }
                else if (info.PropertyType == typeof(DashStyle))
                {
                    ComboBox cbBox = new ComboBox();

                    panel.Children.Add(cbBox);
                }
                else if (info.PropertyType == typeof(Brush))
                {
                    ToggleButton btn = new ToggleButton();
                    btn.Width = 40;

                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(info.Name);
                    bind.Mode = style.Editable ? BindingMode.TwoWay : BindingMode.OneWay;
                    btn.SetBinding(ToggleButton.BackgroundProperty, bind);

                    if (!style.Editable)
                    {
                        btn.IsEnabled = false;
                    }

                    panel.Children.Add(btn);
                }
                else if(info.PropertyType == typeof(System.Drawing.Font))
                {
                    TextBlock font = new TextBlock();
                    font.VerticalAlignment = VerticalAlignment.Center;
                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(info.Name + ".Name");
                    font.SetBinding(TextBlock.TextProperty, bind);
                    panel.Children.Add(font);

                    panel.Children.Add(new TextBlock() { Text = " " });

                    TextBlock size = new TextBlock();
                    size.VerticalAlignment = VerticalAlignment.Center;
                    bind = new Binding();
                    bind.Path = new PropertyPath(info.Name + ".Size");
                    bind.StringFormat = "0.00";
                    size.SetBinding(TextBlock.TextProperty, bind);
                    panel.Children.Add(size);

                    Button btn = new Button();
                    btn.Margin = new Thickness(5, 0, 0, 0);
                    btn.Content = "设置";
                    btn.Click += delegate
                    {
                        System.Windows.Forms.FontDialog dlg = new System.Windows.Forms.FontDialog();
                        dlg.Font = info.GetValue(tool) as System.Drawing.Font;
                        
                        if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                        {
                            info.SetValue(tool, dlg.Font);
                        }
                    };

                    panel.Children.Add(btn);
                }
                else if(info.PropertyType == typeof(string))
                {
                    TextBox tb = new TextBox();
                    tb.Width = 100;
                    tb.AcceptsReturn = true;
                    tb.MaxHeight = 50;
                    tb.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;

                    Binding bind = new Binding();
                    bind.Path = new PropertyPath(info.Name);
                    tb.SetBinding(TextBox.TextProperty, bind);

                    panel.Children.Add(tb);
                }

                if (!string.IsNullOrEmpty(style.Measure))
                {
                    TextBlock textblock = new TextBlock();
                    textblock.Text = style.Measure;
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    panel.Children.Add(textblock);
                }

                if(!string.IsNullOrEmpty(style.ToolTip))
                {
                    Button btn = new Button();
                    btn.Content = "?";
                    btn.Height = 20;
                    btn.Width = 20;
                    btn.VerticalAlignment = VerticalAlignment.Center;
                    btn.ToolTip = style.ToolTip;
                    btn.Margin = new Thickness(10, 0, 0, 0);

                    panel.Children.Add(btn);
                }
            }
            else
            {
                return null;
            }

            return panel;
        }
    }
}
