using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Shapes;
using System.Drawing;
namespace GK_Projekt2.AET_entry.factories
{
    class AET_factory_imageTexture : AET_factory
    {
        public AET_factory_imageTexture(Bitmap texture)
        {
            this.texture = new Color[texture.Width, texture.Height];
            for (int i = 0; i < texture.Width; i++)
                for (int j = 0; j < texture.Height; j++)
                    this.texture[i, j] = texture.GetPixel(i, j);
        }
        public override AET_entry_base getEntry(int id, bool reverse, Polygon p)
        {
            return new AET_entry_imageTexture(id, reverse, p, texture);
        }
        Color[,] texture;
    }
}

