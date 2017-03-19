using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XCode.Common.Controls.Panels
{
    /// <summary>
    /// 瀑布流布局Panel
    /// </summary>
    public class WaterfallPanel : DrawingCanvas
    {
        /// <summary>
        /// 每一列的当前高度
        /// </summary>
        private List<double> _colHeight = new List<double>();
        /// <summary>
        /// 当前列数
        /// </summary>
        private int _colNum = 0;

        /// <summary>
        /// 子项固定宽度
        /// </summary>
        public double ChildWidth { get; set; }
        /// <summary>
        /// 填充
        /// </summary>
        public Thickness Padding { get; set; }
        /// <summary>
        /// 每个子项间的margin
        /// </summary>
        public Thickness ChildMargin { get; set; }

        public WaterfallPanel()
        {
            Padding = new Thickness(5);
            ChildMargin = new Thickness(5);
            ChildWidth = 100;

            this.SizeChanged += WaterfallPanel_SizeChanged;
        }

        private void WaterfallPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.UpdateLayout();
            Refresh();
        }

        #region 基础部分
        public override void AddChild(Visual ele)
        {
            if (!(ele is FrameworkElement))
                return;

            var e = ele as FrameworkElement;

            //可能有网络延迟等影响size
            e.SizeChanged += Ele_SizeChanged;

            base.AddChild(ele);

            AddNewChild(e);
        }

        public override void RemoveChild(Visual ele)
        {
            if (!(ele is FrameworkElement))
                return;

            var e = ele as FrameworkElement;

            e.SizeChanged -= Ele_SizeChanged;

            base.RemoveChild(ele);

            this.UpdateLayout();
            Refresh();
        }
        #endregion

        #region 各种调整
        private void Ele_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// 负责调整chlid宽度以及位置
        /// </summary>
        /// <param name="ele"></param>
        private void AddNewChild(FrameworkElement ele)
        {
            if (_colHeight.Count == 0)
                return;

            //设置新添加的child的宽度
            ele.Width = ChildWidth;
            //得到应插入的列
            int insertCol = _colHeight.IndexOf(_colHeight.Min());
            //计算位置
            double left = Padding.Left + insertCol * (ChildMargin.Left + ChildMargin.Right + ChildWidth);
            double top = _colHeight.Min() + ChildMargin.Top;
            //设置位置
            WaterfallPanel.SetLeft(ele, left);
            WaterfallPanel.SetTop(ele, top);
            //重新调整该列高度
            _colHeight[insertCol] += ChildMargin.Top + ChildMargin.Bottom + ele.ActualHeight;
            //调整高度
            this.Height = _colHeight.Max();
        }

        /// <summary>
        /// 根据当前容器宽度调整列数目
        /// </summary>
        private void AjustColumnNum()
        {
            double width = ChildMargin.Left + ChildMargin.Right + ChildWidth;
            double panelWidth = this.ActualWidth;

            //计算列数目
            _colNum = (int)((panelWidth - Padding.Left - Padding.Right) / width);
            //重新固定列数，并初始化每列高度
            _colHeight = new List<double>();
            for (int i = 0; i < _colNum; ++i)
            {
                _colHeight.Add(0);
            }
        }

        /// <summary>
        /// 刷新视图，重新排列
        /// </summary>
        public void Refresh()
        {
            //调整列数目
            AjustColumnNum();
            //根据列数目和所有可视化对象重新排列
            foreach (var ele in _eles)
            {
                AddNewChild(ele as FrameworkElement);
            }
        }
        #endregion
    }
}
