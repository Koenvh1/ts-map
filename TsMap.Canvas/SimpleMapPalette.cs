using System.Drawing;

namespace TsMap.Canvas
{
    public class SimpleMapPalette : MapPalette
    {
        public SimpleMapPalette()
        {
            Background = new SolidBrush(Color.FromArgb(38, 38, 38));
            Road = Brushes.White;
            PrefabRoad = Brushes.White;
            PrefabLight = new SolidBrush(Color.FromArgb(222, 222, 222));
            PrefabDark = new SolidBrush(Color.FromArgb(207, 207, 207));
            PrefabGreen = new SolidBrush(Color.FromArgb(247, 247, 247)); // TODO: Check if green has a specific z-index

            CityName = Brushes.LightCoral;

            FerryLines = new SolidBrush(Color.FromArgb(80, 255, 255, 255));

            Error = Brushes.LightCoral;
        }
    }
}
