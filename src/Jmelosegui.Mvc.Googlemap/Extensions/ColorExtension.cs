using System;
using System.Drawing;
using System.Globalization;

namespace Jmelosegui.Mvc.Googlemap
{
    static class ColorExtension
    {
        public static string ToHtml(this Color c)
        {
            return ("#" + c.R.ToString("X2", null) + c.G.ToString("X2", null) + c.B.ToString("X2", null));
        }

        public static Color FromHtml(this string htmlValue)
        {
            string strColor = htmlValue.Replace("0x", "").TrimStart('#');

            if (strColor.Length == 6)
            {
                strColor = "FF" + strColor;
            }

            int argb;

            if (Int32.TryParse(strColor, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out argb))
            {
                return Color.FromArgb(argb);
            }

            throw new ArgumentException("Invalid Hex value. Hex must be either an ARGB (8 digits) or RGB (6 digits)");

        }
    }
}