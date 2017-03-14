using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.ChickenSoup.Models
{
    /// <summary>
    /// 适用于豆瓣网
    /// </summary>
    internal class DoubanImage
    {
        public Board board { get; set; }
    }

    internal class Board
    {
        public List<Pin> pins { get; set; }
    }

    internal class Pin
    {
        public PinFile file { get; set; }
        public string raw_text { get; set; }
        public int file_id { get; set; }
    }

    public class PinFile
    {
        public string key { get; set; }
        public string bucket { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
