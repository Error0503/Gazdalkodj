using System.Globalization;

namespace Client
{
    public class Globals
    {
        public static NumberFormatInfo nfi = new CultureInfo("hu-HU", false).NumberFormat;
    }
}
