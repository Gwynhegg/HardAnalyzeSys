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
