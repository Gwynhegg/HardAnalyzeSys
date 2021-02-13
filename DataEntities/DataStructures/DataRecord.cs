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
            data_storage = new List<object>();      //инициализация списка объектов
            foreach (object arg in args) data_storage.Add(arg);
        }

        public int sizeOfSet()      //геттер размера набора с элементами
        {
            return data_storage.Count;
        }
        public object getElement(int index)     //поулчить элемент по индексу в коллекции
        {
            try
            {
                return data_storage[index];
            }
            catch
            {
                return -1;
            }
        }

        public List<object> getStorage()
        {
            return data_storage;
        }

        public bool compareTo(DataRecord record)
        {
            List<object> temporal_storage = record.getStorage();
            for (int i = 0; i < data_storage.Count; i++)
                if (!temporal_storage[i].Equals(data_storage[i])) return false;
            return true;
        }

        public object this[int index]       //получить элемент по индексу в коллекции
        {
            get
            {
                try
                {
                    return data_storage[index];
                }
                catch
                {
                    return -1;
                }
            }
        }
        
    }
}
