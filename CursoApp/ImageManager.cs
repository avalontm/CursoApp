using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CursoApp
{
    public static class ImageManager
    {
        public static Image<Rgba32> Generate(string text)
        {
            var image = new Image<Rgba32>(24, 24);
            var font = SystemFonts.CreateFont("Segoe UI", 16, FontStyle.Bold);
            text = text.ToUpper();

            PathBuilder pathBuilder = new PathBuilder();
            pathBuilder.SetOrigin(new PointF((image.Width / 2), (image.Height / 2)));
            pathBuilder.AddCubicBezier(new PointF(0, 0), new PointF(0, 0), new PointF(0, 0), new PointF(1, 0));

            IPath path = pathBuilder.Build();

            var textOptions = new TextOptions(font)
            {
                WrappingLength = path.ComputeLength(),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            var glyphs = TextBuilder.GenerateGlyphs(text, path, textOptions);

            image.Mutate(ctx => ctx
                    .Fill(Color.White)
                    .Draw(Color.Gray, 1, path)
                    .Fill(Color.Red, glyphs));

            return image;
        }

        public static Image<Rgba32> GenerateHeart()
        {
            var image = new Image<Rgba32>(24, 24);

            const double tau = Math.PI * 2;
            var points = new List<PointF>();

            for (double t = 0; t <= tau; t += 0.1)
            {
                var x = 10 * Math.Pow(Math.Sin(t), 3);
                var y = -(7 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t));
                points.Add(new PointF((float)(x + image.Width / 2), (float)(y + image.Height / 2)));
            }

            var linePen = new SolidPen(Color.Red, 1);
            SolidBrush solidBrush = new SolidBrush(Color.Red);

            image.Mutate(ctx => ctx
              .Fill(Color.White) // Fill background with white
              .DrawPolygon(linePen, points.ToArray()) // Draw red heart outline
              .FillPolygon(solidBrush, points.ToArray()) // Fill red heart shape
            );

            return image;
        }
    }
}
