using ImageManipulator.Core.Abstractions;
using ImageManipulator.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ImageManipulator.BLL.Services
{
    public class ImageProcessingService : IImageProcessingService
    {
        public async Task ApplyEffectsAsync(ImageModel image, List<(IImagePlugin plugin, Dictionary<string, object> parameters)> effects)
        {
            foreach (var (plugin, parameters) in effects)
            {
                await plugin.ApplyEffectAsync(image, parameters);
            }
        }
    }
}
