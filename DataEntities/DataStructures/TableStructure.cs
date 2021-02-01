using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.DataStructures
{
    public class TableStructure : DataStructure
    {
        private List<DataRecord> records;

        public TableStructure()
        {
            records = new List<DataRecord>();       //инициализация списка записей
        }
        public void addRecords(DataRecord record)       //добавить запись в список
        {
            this.records.Add(record);
        }

        public int sizeOfStructure()        //геттер дял размера списка с записями
        {
            return records.Count;
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
