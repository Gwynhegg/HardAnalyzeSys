using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    interface DataEntity
    {
        void createDataStructure();
        void setDataDisplay();
        void addDataRepresentation();
    }
}
