using Microsoft.UI.Xaml.Media.Imaging;

using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;

namespace QuAnalyzer.Core.Helpers
{
    public sealed class ImageSourceConverter : IValueConverter
    {
        private static readonly Regex srcReg = new Regex("/(?<assembly>.*?);(?<path>.*)", RegexOptions.ExplicitCapture | RegexOptions.Compiled);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var match = srcReg.Match((string)value);
            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException("input format must follow the /{assembly};{path_to_resource} scheme");
            }

            if (!targetType.IsAssignableFrom(typeof(ImageSource)))
            {
                throw new ArgumentOutOfRangeException("target type must expect an imagesource object");
            }

            var image = new BitmapImage();// new Uri($"ms-appx://{value}")).;
            image.SetSource(Assembly.Load(match.Groups["assembly"].Value).GetManifestResourceStream(match.Groups["path"].Value).AsRandomAccessStream());
            return image;
            //.Create(Assembly.Load(match.Groups["assembly"].Value).GetManifestResourceStream(match.Groups["path"].Value), BitmapCreateOptions.None, BitmapCacheOption.Default).Frames[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, string.Empty);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(value, targetType, parameter, string.Empty);
        }
    }
}
