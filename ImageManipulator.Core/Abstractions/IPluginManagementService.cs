using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Abstractions
{
    public interface IPluginManagementService 
    { 
        public List<IImagePlugin> Plugins { get; set; }
        public void AddPlugin(IImagePlugin plugin);
        public void RemovePlugin(IImagePlugin plugin);
    }
}