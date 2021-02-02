using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public interface DataRepresentation     //В РАЗРАБОТКЕ
    {
        void setDataTable(DataTable table);
        DataTable getDataTable();
    }
}
