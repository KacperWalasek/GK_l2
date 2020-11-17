using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2.AET_entry.factories
{
    class AET_factory_interpol : AET_factory
    {
        public override AET_entry_base getEntry(int id, bool reverse, Polygon p)
        {
            return new AET_entry_Interpol(id, reverse, p);
        }
    }
}
