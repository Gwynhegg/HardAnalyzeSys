using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.DataStructures
{
    public class TableStructure : DataStructure
    {
        private List<string> headers;
        private List<string> data_types;
        private List<DataRecord> records;

        public TableStructure()
        {
            records = new List<DataRecord>();       //инициализация списка записей
            headers = new List<string>();       //инициализация списка заголовков
            data_types = new List<string>();        ///инициализация списка типов данных
        }
        public void addRecords(DataRecord record)       //добавить запись в список
        {
            this.records.Add(record);
        }

        public int sizeOfStructure()        //геттер дял размера списка с записями
        {
            return records.Count;
        }

        public void setHeaders(string header)
        {
            this.headers.Add(header);
        }

        public void setDataTypes(string type)
        {
            data_types.Add(type);
        }

        public List<string> getHeaders()
        {
            return headers;
        }

        public List<string> getDataTypes()
        {
            return data_types;
        }

        public DataRecord getRecord(int index)      //геттер для записи по индексу
        {
            try
            {
                return records[index];
            }
            catch
            {
                return null;
            }
        }

        //Переопределение индексатора, для удобства
        public DataRecord this[int index]
        {
            get
            {
                try
                {
                    return records[index];
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
