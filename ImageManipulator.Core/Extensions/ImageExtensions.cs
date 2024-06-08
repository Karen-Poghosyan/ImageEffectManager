using ImageManipulator.Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulator.Core.Extensions
{
    public static class ImageExtensions
    {
        public static async Task LoadAsync(this ImageModel image)
        {
            await Task.Run(() =>
            {
                var path = image?.Path;
                var bitmap = image?.Bitmap;

                if (File.Exists(path))
                {
                    bitmap = new Bitmap(path);
                }
                else
                {
                    throw new FileNotFoundException("Image file not found.", path);
                }
            });
        }

        public static async Task SaveAsync(this ImageModel image, string outputPath)
        {
            await Task.Run(() =>
            {
                var path = image?.Path;
                var bitmap = image?.Bitmap; 

                if (bitmap != null)
                {
                    bitmap.Save(outputPath);
                }
                else
                {
                    throw new InvalidOperationException("No image loaded to save.");
                }
            });
        }
    }
}
