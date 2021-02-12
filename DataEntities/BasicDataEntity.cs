using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HardAnalyzeSys.DataEntities
{
    public class BasicDataEntity : Interfaces.AbstractDataEntity
    {

        public override void createDataStructure(DataTable data)     //Создание базовой структуры данных
        {
            data_structure = new DataStructures.TableStructure();       //Создается структура
            this.addDataRepresentation(new DataRepresentations.Table(data));        //Задается базовое табличное представление
            displayed_type = new DataDisplays.InputFileDisplay(this);

            foreach (DataColumn column in data.Columns) data_structure.setHeaders(column.ColumnName);       //переносим имена столбцов
            foreach (DataRow row in data.Rows)      //переносим данные с таблицы в созданную структуру
            { 
                DataStructures.DataRecord new_record = new DataStructures.DataRecord(row.ItemArray);
                data_structure.addRecords(new_record);
            }
        }

    }
}
