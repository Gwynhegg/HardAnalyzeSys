using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.DataStructures
{
    public class DataRecord
    {
        private List<object> data_storage;

        public DataRecord(object[] args)
        {
            data_storage = new List<object>();
            foreach (object argument in args) data_storage.Add(argument);
        }
        
    }
}
