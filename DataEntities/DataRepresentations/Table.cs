using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.DataRepresentations
{
    public class Table : DataRepresentation
    {
        private DataTable table;
        public Table(DataTable table)       //задать таблицу для презентации
        {
            this.table = table;
        }
        public void setDataTable(DataTable table)       //вспомогательный способ задания (может пригодиться)
        {
            this.table = table;
        }

        public DataTable GetDataTable()     //геттер для таблицы
        {
            return table;
        }
    }
}
