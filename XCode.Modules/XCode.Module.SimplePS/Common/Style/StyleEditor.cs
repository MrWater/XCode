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
    internal static class ToolEditor
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
                var control = GetEditorControl(item);

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
        private static UIElement GetEditorControl(PropertyInfo info)
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
                    bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    textbox.SetBinding(TextBox.TextProperty, bind);
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
                    bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    tbX.SetBinding(TextBox.TextProperty, bind);

                    TextBlock textY = new TextBlock() { Text = "Y" };
                    textY.Margin = new Thickness(5, 0, 0, 0);
                    textY.VerticalAlignment = VerticalAlignment.Center;
                    TextBox tbY = new TextBox();
                    tbY.VerticalAlignment = VerticalAlignment.Center;
                    tbY.Width = 40;

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
                    bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    btn.SetBinding(ToggleButton.BackgroundProperty, bind);
                    panel.Children.Add(btn);
                }

                if (style.Measure != "")
                {
                    TextBlock textblock = new TextBlock();
                    textblock.Text = style.Measure;
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    panel.Children.Add(textblock);
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
