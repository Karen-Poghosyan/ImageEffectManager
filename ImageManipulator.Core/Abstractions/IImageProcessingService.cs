using ImageManipulator.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Abstractions
{
    public interface IImageProcessingService
    {
        public Task ApplyEffectsAsync(ImageModel image, List<(IImagePlugin plugin, Dictionary<string, object> parameters)> effects);
    }
}
