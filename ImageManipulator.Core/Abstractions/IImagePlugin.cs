using ImageManipulator.Core.Models;
using ImageManipulator.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Abstractions
{
    public interface IImagePlugin
    {
        string Name { get; }
        Task ApplyEffectAsync(ImageModel image, Dictionary<string, object> parameters);
    }
}
