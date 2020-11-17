using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GK_Projekt2.Shapes;

namespace GK_Projekt2.AET_entry.factories
{
    class AET_factory_heigthMap : AET_factory
    {
        public AET_factory_heigthMap(Bitmap texture)
        {
            this.texture = new int[texture.Width, texture.Height];
            for (int i = 0; i < texture.Width; i++)
                for (int j = 0; j < texture.Height; j++)
                    this.texture[i, j] = texture.GetPixel(i, j).R;
        }
        public override AET_entry_base getEntry(int id, bool reverse, Polygon p)
        {
            return new AET_entry_heigthMap(id, reverse, p, texture);
        }
        int[,] texture;
    }
}
