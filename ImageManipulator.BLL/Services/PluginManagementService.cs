using ImageManipulator.Core.Abstractions;
using ImageManipulator.Core.Plugins;
using System.Collections.Generic;

namespace ImageManipulator.BLL.Services
{
    public class PluginManagementService : IPluginManagementService
    {
        public List<IImagePlugin> Plugins { get; set; }
        public PluginManagementService()
        {
            Plugins = new List<IImagePlugin>() // init plugins 
            {
                new ResizePlugin(),
                new BlurPlugin()
            };
        }
        public void AddPlugin(IImagePlugin plugin)
        {
            Plugins.Add(plugin);
        }

        public void RemovePlugin(IImagePlugin plugin)
        {
            Plugins.Remove(plugin);
        }

    }
}
