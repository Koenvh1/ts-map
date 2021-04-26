using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;
using TsMap.Canvas;

namespace TsMap.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var mods = new System.Collections.Generic.List<Mod> {
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-me-assets-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-me-defmap-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-def-st-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-assets-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-map-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-media-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-model1-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-model2-v250.scs"),
                new Mod(@"D:\Documents\Euro Truck Simulator 2\mod\promods-model3-v250.scs"),
            };
            mods.ForEach(x => x.Load = true);
            TsMapper mapper = new TsMapper("D:/Apps/Steam/steamapps/common/Euro Truck Simulator 2/", mods);
            mapper.IsEts2 = true;
            mapper.Parse();

            var renderer = new TsMapRenderer(mapper);
            var palette = new SimpleMapPalette();

            var path = @"F:/Screenshots";

            int width, height;
            width = height = 256;
            float scale = 0.1f;

            int upperX = 3840;// 160_000;
            int lowerX = -3840;// -120_000;

            int upperY = 3840;// 130_000;
            int lowerY = -3840;// -210_000;

            for (int y = lowerY; y < upperY; y += height * 2)
            {
                for (int x = lowerX; x < upperX; x += width * 2)
                {
                    var bitmap = new Bitmap(width, height);

                    PointF pos = new PointF(x, y);

                    renderer.Render(Graphics.FromImage(bitmap), new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        scale, pos, palette, RenderFlags.All);

                    using (FileStream fileStream = File.Open($"{path}/{x};{y}.png", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        bitmap.Save(fileStream, ImageFormat.Png);
                    }
                    bitmap.Dispose();
                    GC.Collect();
                }
            }
        }
    }
}
