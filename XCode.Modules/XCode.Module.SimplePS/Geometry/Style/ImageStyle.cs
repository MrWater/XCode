using XCode.Module.SimplePS.Common.Style;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry.Style
{
    internal class ImageStyle : GeometryStyleBase, IImageStyle
    {
        private Uri _imageUri;
        /// <summary>
        /// 图片uri
        /// </summary>
        [Style(DisplayName = "图片")]
        public Uri ImageUri
        {
            get { return _imageUri; }
            set
            {
                if (_imageUri == value)
                    return;

                _imageUri = value;
                RaisePropertyChanged("ImageUri");
            }
        }

        public ImageStyle()
            : base()
        {
            ImageUri = null;
        }
    }
}
