using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MapTypeController
    {
        public ActionResult ImageMapType()
        {
            return View();
        }
        
        public ActionResult GetLabeledTile(int x, int y, int zoom, int tileWith, int tileHeigth)
        {
            var image = GetTile(x, y, zoom, tileWith, tileHeigth, "speculative_map.jpg");
            return File(image, "image/jpeg");
        }
        
        public ActionResult GetNaturalTile(int x, int y, int zoom, int tileWith, int tileHeigth)
        {
            var image = GetTile(x, y, zoom, tileWith, tileHeigth, "map_natural.jpg");
            return File(image, "image/jpeg");
        }
        
        private byte[] GetTile(int x, int y, int zoom, int tileWith, int tileHeigth, string imageName)
        {
            string imagePath = "~/Content/MapType/" + imageName;

            string tileKey = String.Format("{5}_{0}_{1}-{2}_{3}x{4}", zoom, x, y, tileWith, tileHeigth, imageName);

            var image = (byte[])HttpRuntime.Cache[tileKey];

            if (image == null)
            {
                image = TileGenerator.GenerateTile(x, y, zoom, tileWith, tileHeigth, imagePath);
                HttpRuntime.Cache[tileKey] = image;
            }

            return image;
        }
    }

    /*
     * Just an example of how to generate an image tile. 
     * TODO: Improve preformance, add cache.     
     */
    internal class TileGenerator
    {
        public static byte[] GenerateTile(int x, int y, int zoom, int tileWith, int tileHeigth, string imagePath)
        {
            var serverPath = HostingEnvironment.MapPath(imagePath);

            using (Stream stream = File.OpenRead(serverPath))
            {
                using (var original = Image.FromStream(stream))
                {
                    int mapWidth = tileWith * (int)Math.Pow(2, zoom);
                    int mapHeigth = tileHeigth * (int)Math.Pow(2, zoom);

                    using (Image resized = ResizeImage(original, new Size(mapWidth, mapHeigth)))
                    {
                        return GetTileBytes(resized, x, y, tileWith, tileHeigth);
                    }

                }
            }
        }

        private static byte[] GetTileBytes(Image image, int x, int y, int tileWith, int tileHeigth)
        {
            var tileRectangle = new Rectangle(x * tileWith, y * tileHeigth, tileWith, tileHeigth);

            using (var bitmap= new Bitmap(image))
            {
                using (Bitmap tileBitmap = bitmap.Clone(tileRectangle, bitmap.PixelFormat))
                {
                    using (var ms = new MemoryStream())
                    {
                        tileBitmap.Save(ms, ImageFormat.Png);   
                        return ms.ToArray();
                    }
                }
            }
        }

        private static Image ResizeImage(Image original, Size size)
        {
            var bitmap = new Bitmap(size.Width, size.Height);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(original, 0, 0, size.Width, size.Height);

                return bitmap;
            }
        }
    }
}