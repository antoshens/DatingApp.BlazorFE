namespace DatingApp.FrontEnd.Gateway.Utils
{
    public interface IImageFileProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="maxHeight"></param>
        /// <param name="maxWidth"></param>
        /// <param name="isMaxRadius"></param>
        /// <param name="format"></param>
        /// <returns>Transformed image url</returns>
        string BuildTransformedImage(string url, int maxHeight, int maxWidth, bool isMaxRadius = false, ImageFormat? format = null);
    }
}
