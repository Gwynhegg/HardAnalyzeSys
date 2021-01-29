using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public class BasicDataEntity : DataEntity
    {
        private List<DataRepresentation> data_representations;
        private DataStructure data_structure;
        private DataDisplay displayed_type;
    }
}
