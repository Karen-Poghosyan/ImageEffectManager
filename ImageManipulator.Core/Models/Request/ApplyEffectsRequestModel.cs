using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Models.Request
{
    public class ApplyEffectsRequestModel
    {
        public string ImagePath { get; set; }
        public string OutputPath { get; set; }
        public Dictionary<string, object> ResizeParameters { get; set; }
        public Dictionary<string, object> BlurParameters { get; set; }
    }
}
