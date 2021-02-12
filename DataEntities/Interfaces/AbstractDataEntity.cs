using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities.Interfaces
{
    public abstract class AbstractDataEntity : DataEntity
    {

        protected MainWindow main_form;

        protected string entity_name;
        protected List<DataRepresentation> data_representations;      //тут хранятся представления данных
        protected DataStructure data_structure;       //тут хранится структура данных
        protected DataDisplay displayed_type;     //вспомогательное поле для отображения
        protected Dictionary<(string, string), object> data_quantities;       //тут хранится словарь с вычисляемыми величинами. Для удобства и скорости будем хранить в виде ЗАПРОС (название величины) - ЗНАЧЕНИЕ

        public void addDataRepresentation(DataRepresentation data_representation)
        {
            data_representations.Add(data_representation);
        }

        public AbstractDataEntity()
        {
            data_representations = new List<DataRepresentation>();      //инициализация списка представлений
            data_quantities = new Dictionary<(string, string), object>();       //инициализация списка статистических величин
        }

        public void setParentWindow(MainWindow window)
        {
            main_form = window;
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


        public void transferDataTypes(string[] data_types)
        {
            foreach (string type in data_types) data_structure.setDataTypes(type);
        }

        public abstract void createDataStructure(DataTable data);


        public DataStructure extractDataStructure()
        {
            return data_structure;
        }

        public Dictionary<(string, string), object> getAllStatistic()       //получение всех статистических величин
        {
            return data_quantities;
        }


        public DataDisplay GetDataDisplay()
        {
            return displayed_type;
        }

        public List<DataRepresentation> GetDataRepresentations()
        {
            return data_representations;
        }

        public string getEntityName()       //геттер имени элемента данных
        {
            return entity_name;
        }

        public object getStatValue(string name_of_value, string parameter)      //получение определенной стат. величины по имени и параметру
        {
            if (data_quantities.ContainsKey((name_of_value, parameter))) return data_quantities[(name_of_value, parameter)]; else return -1;
        }


        public void setDataDisplay(DataDisplay display)
        {
            displayed_type = display;
        }

        public void setEntityName(string name)      //сеттер имени элемента данных
        {
            entity_name = name;
        }

        public DataDisplays.CustomControl displayIcon(int left, int top)        //возвращаем кастомный элемент отображения на форму
        {
            return displayed_type.getDisplayedImage(left, top);
        }
    }
}
