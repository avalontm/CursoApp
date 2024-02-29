using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CursoApp
{
    public static class Extentions
    {
        public static int ToConsoleColor(Color color)
        {
            var c = color.ToPixel<Rgba32>();

            int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0;
            index |= (c.R > 64) ? 4 : 0;
            index |= (c.G > 64) ? 2 : 0;
            index |= (c.B > 64) ? 1 : 0;
            return index;
        }

        public static void ToConsoleImage(this Image<Rgba32> src, int min = 24)
        {
            decimal pct = Math.Min(decimal.Divide(min, src.Width), decimal.Divide(min, src.Height));

            src.Mutate(x => x.Resize((int)(src.Width * pct), (int)(src.Height * pct)));

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Console.ForegroundColor = (ConsoleColor)ToConsoleColor(src[x, y]);
                    Console.Write("██");
                }
                Console.WriteLine();
            }
        }

    }
}
