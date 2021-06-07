using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Note2Self.ValueConverters
{
    class ByteArrayToBitmapConverter : BaseValueConverter<ByteArrayToBitmapConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not byte[] imageData || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                //image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                image.CacheOption = BitmapCacheOption.OnLoad;

                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }
            byte[] buffer;
            var stream = (value as BitmapImage).StreamSource;
            using (var br = new BinaryReader(stream))
            {
                buffer = br.ReadBytes((int)stream.Length);
            }
            return buffer;
        }
    }
}
