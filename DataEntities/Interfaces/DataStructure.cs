using HardAnalyzeSys.DataEntities.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public interface DataStructure
    {
        void addRecords(DataStructures.DataRecord record);      //добавление записи в список
        int sizeOfStructure();      //геттер размера структуры для перебора
        DataRecord getRecord(int index);        //получение элемента по индексу
        DataRecord this[int index] { get;  }
    }
}
