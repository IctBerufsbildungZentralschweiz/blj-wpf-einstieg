using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeetasse
{
    public class ImageModel
    {   
        public string ImagePath { get; set; }
        public string Type { get; set; }

        public ImageModel(string imagePath, string type)
        {
            ImagePath = imagePath;
            Type = type;
        }
    }
}
