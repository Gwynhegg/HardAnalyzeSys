using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HardAnalyzeSys.DataEntities
{
    public class BasicDataEntity : DataEntity
    {
        private List<DataRepresentation> data_representations;      //тут хранятся представления данных
        private DataStructure data_structure;       //тут хранится структура данных
        private DataDisplay displayed_type;     //вспомогательное поле для отображения
        private List<Interfaces.DataQuantities> data_quantities;        //тут хранится лист с вычисленными статистическими величинами.

        public BasicDataEntity()
        {
            data_representations = new List<DataRepresentation>();      //инициализация списка представлений
            data_quantities = new List<Interfaces.DataQuantities>();        //инициализация списка статистических величин
        }

        public void addDataRepresentation(DataRepresentation data_representation)       //метод для добавления представления в список
        {
            this.data_representations.Add(data_representation);
        }

        public void createDataStructure(DataTable data)     //Создание базовой структуры данных
        {
            data_structure = new DataStructures.TableStructure();       //Создается структура
            this.addDataRepresentation(new DataRepresentations.Table(data));        //Задается базовое табличное представление
            displayed_type = new DataDisplays.InputFileDisplay();
            //ДОБАВИТЬ ПРОВЕРКУ КОРРЕКТНОСТИ ДАННЫХ
            foreach (DataRow row in data.Rows)      //переносим данные с таблицы в созданную структуру
            { 
                DataStructures.DataRecord new_record = new DataStructures.DataRecord(row.ItemArray);
                data_structure.addRecords(new_record);
            }
        }

        public DataStructure extractDataStructure()     //геттер для структуры данных
        {
            return data_structure;
        }

        public List<DataRepresentation> GetDataRepresentations()        //геттер для списка представления данных
        {
            return data_representations;
        }

        //ОПРЕДЕЛИТЬ
        public DataDisplay GetDataDisplay()
        {
            return null;
        }

        //ОПРЕДЕЛИТЬ
        public void setDataDisplay(DataDisplay display)
        {
            return;
        }

        public Image displayIcon(int left, int top)
        {
            return displayed_type.getDisplayedImage(left, top);
        }
    }
}
