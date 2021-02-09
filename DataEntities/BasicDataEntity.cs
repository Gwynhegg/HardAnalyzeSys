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
        private string entity_name;
        private List<DataRepresentation> data_representations;      //тут хранятся представления данных
        private DataStructure data_structure;       //тут хранится структура данных
        private DataDisplay displayed_type;     //вспомогательное поле для отображения
        private Dictionary<(string,string), object> data_quantities;        //тут хранится словарь с вычисляемыми величинами. Для удобства и скорости будем хранить в виде ЗАПРОС (название величины) - ЗНАЧЕНИЕ

        public BasicDataEntity()
        {
            data_representations = new List<DataRepresentation>();      //инициализация списка представлений
            data_quantities = new Dictionary<(string,string), object>();       //инициализация списка статистических величин
        }

        public void transferDataTypes(string[] data_types)
        {
            foreach (string type in data_types) data_structure.setDataTypes(type);
        }

        public void addDataRepresentation(DataRepresentation data_representation)       //метод для добавления представления в список
        {
            this.data_representations.Add(data_representation);
        }

        public void createDataStructure(DataTable data)     //Создание базовой структуры данных
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
            return displayed_type;
        }

        //ОПРЕДЕЛИТЬ
        public void setDataDisplay(DataDisplay display)     //сеттер для отображения на случай смены иконки и т.д.
        {
            displayed_type = display;
        }

        public DataDisplays.CustomControl displayIcon(int left, int top)        //возвращаем кастомный элемент отображения на форму
        {
            return displayed_type.getDisplayedImage(left, top);
        }

        public void calculateStatValue(string name_of_value, string parameter, bool is_numeric)
        {
            if (!data_quantities.ContainsKey((name_of_value, parameter)))
            {
                int field_id = data_structure.getHeaders().IndexOf(parameter);
                object[] temporal_array = new object[data_structure.sizeOfStructure()];
                for (int i = 0; i < temporal_array.Length; i++) temporal_array[i] = data_structure[i][field_id];
                data_quantities.Add((name_of_value, parameter), StatLibrary.Calculate(name_of_value, temporal_array, is_numeric));
            }
        }

        public Dictionary<(string, string), object> getAllStatistic()       //получение вссех статистических величин
        {
            return data_quantities;
        }

        public object getStatValue(string name_of_value, string parameter)      //получение определенной стат. величины по имени и параметру
        {
            if (data_quantities.ContainsKey((name_of_value, parameter))) return data_quantities[(name_of_value, parameter)]; else return -1;
        }

        public void setEntityName(string name)      //сеттер имени элемента данных
        {
            this.entity_name = name;
        }

        public string getEntityName()       //геттер имени элемента данных
        {
            return entity_name;
        }
    }
}
