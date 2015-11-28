// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;
    using System.Globalization;

    internal static class ColorExtension
    {
        public static string ToHtml(this Color c)
        {
            return "#" + c.R.ToString("X2", null) + c.G.ToString("X2", null) + c.B.ToString("X2", null);
        }

        public static Color FromHtml(this string htmlValue)
        {
            string strColor = htmlValue.Replace("0x", string.Empty).TrimStart('#');

            if (strColor.Length == 6)
            {
                strColor = "FF" + strColor;
            }

            int argb;

            if (int.TryParse(strColor, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out argb))
            {
                return Color.FromArgb(argb);
            }

            throw new ArgumentException("Invalid Hex value. Hex must be either an ARGB (8 digits) or RGB (6 digits)");
        }
    }
}