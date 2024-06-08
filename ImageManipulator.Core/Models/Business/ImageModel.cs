using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Models.Business
{
    public class ImageModel
    {
        public string Path { get; set; }
        public Bitmap Bitmap { get; set; }

        public ImageModel(string path)
        {
            Path = path;
        }
    }
}
