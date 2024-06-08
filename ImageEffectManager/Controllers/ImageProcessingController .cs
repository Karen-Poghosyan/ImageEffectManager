using ImageManipulator.BLL.Services;
using ImageManipulator.Core.Abstractions;
using ImageManipulator.Core.Extensions;
using ImageManipulator.Core.Models.Business;
using ImageManipulator.Core.Models.Request;
using ImageManipulator.Core.Plugins;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageEffectManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageProcessingController : ControllerBase
    {
        private readonly IImageProcessingService _imageProcessingService;
        private readonly IPluginManagementService _pluginManagementService;
        public ImageProcessingController(IImageProcessingService imageProcessingService, IPluginManagementService pluginManagementService)
        {
            _imageProcessingService = imageProcessingService;
            _pluginManagementService = pluginManagementService;
        }

        [HttpPost("apply-effects")]
        public async Task<IActionResult> ApplyEffects([FromBody] ApplyEffectsRequestModel request)
        {
            var image = new ImageModel(request.ImagePath);
            await image.LoadAsync();

            var plugins = _pluginManagementService.Plugins; 
            
            var effects = new List<(IImagePlugin plugin, Dictionary<string, object> parameters)>
            {
                
                (plugins.Find(p => p.Name == "Resize"), request.ResizeParameters),
                (plugins.Find(p => p.Name == "Blur"), request.BlurParameters)
            };

            await _imageProcessingService.ApplyEffectsAsync(image, effects);
            await image.SaveAsync(request.OutputPath);

            return Ok(image);
        }
    }

   
}
