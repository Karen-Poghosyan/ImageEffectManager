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
    public class ResizePlugin : IImagePlugin
    {
        public string Name => "Resize";

        public async Task ApplyEffectAsync(ImageModel image, Dictionary<string, object> parameters)
        {
            await Task.Run(() =>
            {
                if (parameters.TryGetValue("Width", out var width) && parameters.TryGetValue("Height", out var height))
                {
                    int newWidth = Convert.ToInt32(width);
                    int newHeight = Convert.ToInt32(height);

                    var resizedBitmap = new Bitmap(image.Bitmap, newWidth, newHeight);
                    image.Bitmap = resizedBitmap;
                }
            });
        }
    }
}
