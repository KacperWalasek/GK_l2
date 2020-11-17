using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.Shapes
{
    interface IShape
    {
        bool Contains(Point point);  
    }
}
