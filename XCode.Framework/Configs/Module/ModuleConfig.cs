using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using XCode.Common.Controls.TabControls;
using XCode.Framework.Module;

namespace XCode.Framework.Configs.Module
{
    /// <summary>
    /// 模块配置类
    /// </summary>
    internal class ModuleConfig
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private const string _configFilePath = "./Configs/Module.config";

        private static string _directory = "";

        public static IEnumerable<XImgTabItem> GetCustomTabItems()
        {
            if (!File.Exists(_configFilePath))
                yield break;

            XDocument doc = XDocument.Load(_configFilePath);
            var nodes = doc.Root.Nodes();
            XImgTabItem item = null;
            //Type type = null;
            string temp = "";

            foreach (var node in nodes)
            {
                XElement ele = node as XElement;

                try
                {
                    _directory = ele.Attribute(XName.Get("Directory")).Value;

                    item = new XImgTabItem()
                    {
                        Header = ele.Attribute(XName.Get("Name")).Value,
                        ImgSource = new BitmapImage(new Uri(ele.Attribute(XName.Get("Icon")).Value))
                    };

                    temp = ele.Attribute(XName.Get("Module")).Value;
                    Assembly asb = Assembly.LoadFrom(_directory + "/" + ele.Attribute(XName.Get("Assembly")).Value + ".dll");
                    //type = asb.GetType(temp);
                    IModule module = asb.CreateInstance(temp) as IModule;
                    //module.Owner = App.Current.MainWindow;
                    
                    item.Content = module.Entry;
                }
                catch (NullReferenceException)
                {
                    //XLog.Normal.Write(XLogInfoType.Error, "自定义模块配置文件已损坏");
                    continue;
                }
                catch (FileNotFoundException)
                {
                    //XLog.Normal.Write(XLogInfoType.Error, "未找到" + item.Header + "模块dll文件");
                    continue;
                }
                catch (BadImageFormatException)
                {
                    //XLog.Normal.Write(XLogInfoType.Error, item.Header + "模块文件已损坏");
                    continue;
                }

                yield return item;
            }
        }
    }
}
