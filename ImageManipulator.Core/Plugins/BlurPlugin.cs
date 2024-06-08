using ImageManipulator.Core.Abstractions;
using ImageManipulator.Core.Models;
using ImageManipulator.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Plugins
{
    public class BlurPlugin : IImagePlugin
    {
        public string Name => "Blur";

        public async Task ApplyEffectAsync(ImageModel image, Dictionary<string, object> parameters)
        {
            await Task.Run(() =>
            {
                if (parameters.TryGetValue("Radius", out var radius))
                {
                    int blurRadius = Convert.ToInt32(radius);
                    var blurredBitmap = BlurImage(image.Bitmap, blurRadius);
                    image.Bitmap = blurredBitmap;
                }
            });
        }

        private Bitmap BlurImage(Bitmap image, int radius)
        {
            // Пример простой реализации размытия изображения
            Bitmap blurred = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(blurred))
            {
                Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
                graphics.DrawImage(image, rectangle, rectangle, GraphicsUnit.Pixel);
            }
            return blurred;
        }
    } 
}

