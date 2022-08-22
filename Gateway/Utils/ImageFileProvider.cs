using System.Text;
using System.Text.RegularExpressions;

namespace DatingApp.FrontEnd.Gateway.Utils
{
    public enum ImageFormat
    {
        Jpg = 0,
        Png,
        Gif,
        WebP,
        Tiff,
        Ico,
        Svg,
        Ply,
        Jp2,
        Avif,
        Bmp
    }

    public class ImageFileProvider : IImageFileProvider
    {
        public string BuildTransformedImage(string url, int maxHeight, int maxWidth, bool isMaxRadius = false, ImageFormat? format = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                return url;
            }

            StringBuilder transformedUrl = new StringBuilder(url);

            if (maxHeight > 0 || maxWidth > 0)
            {
                transformedUrl = transformedUrl.Replace("upload/", $"upload/{maxHeight},{maxWidth},c_fill/");
            }

            if (isMaxRadius)
            {
                transformedUrl = transformedUrl.ToString().Contains("c_fill")
                    ? transformedUrl.Replace("c_fill/", $"c_fill/r_max")
                    : transformedUrl.Replace("upload/", $"c_fill/r_max");
            }

            if (format.HasValue)
            {
                var formatRegex = new Regex(@".\w{3,4}$");
                var match = formatRegex.Match(transformedUrl.ToString());

                transformedUrl = transformedUrl.Replace(match.Value, format.Value.ToString().ToLower());
            }

            return transformedUrl.ToString();
        }
    }
}
