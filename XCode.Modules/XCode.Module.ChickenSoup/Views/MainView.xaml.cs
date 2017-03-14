using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XCode.Common.TextParsers;
using XCode.Module.ChickenSoup.Models;

namespace XCode.Module.ChickenSoup.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        private const string _requestData = "&limit=20&wfl=1";
        private const string _indexUrl = "http://huaban.com/boards/10750/";
        private const string _imgHost = "http://hbimg.b0.upaiyun.com/";

        private int _count;
        private Random _ran;
        private bool _isFirst;

        public Window Owner { get; set; }

        public MainView()
        {
            InitializeComponent();
            _isFirst = true;
            _count = 0;
            _ran = new Random();
        }

        private void RequestNewSoup(string uri)
        {
            Task.Factory.StartNew(new Action(() =>
            {
                Dictionary<string, Tuple<int, string>> dic = new Dictionary<string, Tuple<int, string>>();

                try
                {
                    WebRequest request = WebRequest.Create(uri);
                    //得到json
                    request.Headers.Add("X-Requested-With: XMLHttpRequest");
                    WebResponse response = request.GetResponse();
                    DoubanImage douban = null;
                    using (Stream resStream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(resStream))
                        {
                            string s = sr.ReadToEnd();

                            var json = JsonParser.SerializeObject(s);
                            JsonParser.CorrectJson(ref json);
                            douban = JsonParser.DeserializeJsonToObject<DoubanImage>(json);
                        }
                    }

                    if (douban == null)
                        return;

                    foreach (var pin in douban.board.pins)
                    {
                        if (pin.file.bucket == "hbimg")
                        {
                            dic.Add(_imgHost + pin.file.key + "_fw236", Tuple.Create<int, string>(pin.file_id, pin.raw_text.Replace("\\n", "\n").Trim()));
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    ShowNewSoup(dic);
                }));
            }));
        }

        private void ShowNewSoup(Dictionary<string, Tuple<int, string>> dic)
        {
            bool isContinue = false;
            int cnt = 0;

            //BitmapImage waitImg = new BitmapImage(new Uri("pack://application:,,,/Images/error.png"));
            //BitmapImage waitImg2 = new BitmapImage(new Uri("pack://application:,,,/Images/news.png"));
            foreach (var key in dic.Keys)
            {
                isContinue = false;

                foreach (FrameworkElement child in Container.Children)
                {
                    if (child.Uid == dic[key].Item1.ToString())
                    {
                        isContinue = true;
                        break;
                    }
                }

                if (isContinue)
                    continue;
                cnt++;

                Border border = new Border();
                border.Background = Brushes.LightGray;
                border.BorderBrush = Brushes.LightGray;
                border.BorderThickness = new Thickness(0.5);

                StackPanel panel = new StackPanel();
                Image img = new Image();
                img.SnapsToDevicePixels = true;
                //img.Height = _dic[key].Item2 * (container.ChildWidth / _dic[key].Item1);
                img.Source = new BitmapImage(new Uri(key));

                //BitmapImage image = new BitmapImage(new Uri(key));
                //img.Source = image;
                //image.DownloadProgress += delegate
                //{
                //    img.Source = waitImg;
                //    img.UpdateLayout();
                //};
                //image.DownloadFailed += delegate
                //{
                //    img.Source = waitImg2;
                //    img.UpdateLayout();
                //};
                //image.DownloadCompleted += delegate
                //{
                //    img.Source = image;
                //    img.UpdateLayout();
                //};

                TextBlock text = new TextBlock();
                text.TextWrapping = TextWrapping.Wrap;
                text.Text = dic[key].Item2;
                text.Margin = new Thickness(10);

                panel.Children.Add(img);
                panel.Children.Add(text);
                border.Child = panel;
                border.Uid = dic[key].Item1.ToString();

                Container.AddChild(border);
            }

            if (_isFirst)
                _isFirst = false;

            string s = "";
            if (cnt != 0)
                s = "[鸡汤]新增" + cnt + "碗鸡汤";
            else
                s = "[鸡汤]木有新鸡汤呀";

            Console.WriteLine(s);

            //XStatusBarMessage msg = new XStatusBarMessage()
            //{
            //    StatusType = StatusType.Normal,
            //    Message = s
            //};
            //Messenger.Default.Send(msg);
        }

        private void RequestNewSoup()
        {
            string url = _indexUrl + "?isjva" + _count.ToString("000") + "&max=" + _ran.Next(1000000, 10000000) + _requestData;
            RequestNewSoup(url);
            _count++;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_isFirst)
                RequestNewSoup(_indexUrl);
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (_isFirst)
                return;

            double height = Scroll.ScrollableHeight;
            if (height == 0)
                return;

            //执行请求数据
            if (e.VerticalOffset >= height - 100)
            {
                //XStatusBarMessage msg = new XStatusBarMessage()
                //{
                //    StatusType = StatusType.Normal,
                //    Message = "[鸡汤]正在寻找新的鸡汤..."
                //};

                //Messenger.Default.Send(msg);
                RequestNewSoup();
            }
        }
    }
}
