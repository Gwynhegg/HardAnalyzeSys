using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardAnalyzeSys.DataEntities
{
    public interface DataEntity
    {
        void createDataStructure(DataTable data);       //создать структуру данных в сущности
        DataStructure extractDataStructure();       //извлечь структуру данных
        void setDataDisplay(DataDisplay display);       //задать отображение на форме
        DataDisplay GetDataDisplay();       //получить отображение для показа на форме
        void addDataRepresentation(DataRepresentation data_representation);     //добавить одно представление в список сущности

        List<DataRepresentation> GetDataRepresentations();      //получить список для отображения на форме (графики и пр.)

        void calculateStatValue(string name_of_value, string parameter, int field_id);
        Dictionary<(string, string), double> getAllStatistic();
        double getStatValue(string name_of_value, string parameter);
        void setEntityName(string name);
        string getEntityName();
    }
}
