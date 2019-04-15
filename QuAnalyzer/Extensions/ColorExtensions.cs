namespace QuAnalyzer.Extensions
{
    public static class ColorExtensions
    {

        public static byte[] AsByteArray(this System.Windows.Media.Color src)
        {
            return new byte[] { src.R, src.G, src.B };
        }

        public static System.Drawing.Color AsDrawingColor(this System.Windows.Media.Color src)
        {
            return System.Drawing.Color.FromArgb(src.R, src.G, src.B);
        }


    }
}
