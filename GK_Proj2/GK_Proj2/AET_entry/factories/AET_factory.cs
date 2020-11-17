using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Projekt2.Shapes;

namespace GK_Projekt2.AET_entry.factories
{
    abstract class AET_factory
    {
        public abstract AET_entry_base getEntry(int id, bool reverse, Polygon p);
    }
}
