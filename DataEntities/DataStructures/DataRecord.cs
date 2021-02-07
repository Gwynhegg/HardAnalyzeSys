using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.DataStructures
{
    public class DataRecord
    {
        private ArrayList data_storage;

        public DataRecord(object[] args, string[] types)
        {
            data_storage = new ArrayList();      //инициализация списка объектов
            for (int i=0; i<args.Length; i++)
            {
               switch (types[i])
                {
                    case "bool": data_storage.Add(Convert.ToBoolean(args[i]));break;
                    case "int": data_storage.Add(Convert.ToInt32(args[i]));break;
                    case "double": data_storage.Add(Convert.ToDouble(args[i]));break;
                    case "string": data_storage.Add(Convert.ToString(args[i]));break;
                }
            }
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
