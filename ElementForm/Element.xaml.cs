using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace HardAnalyzeSys.ElementForm
{
    /// <summary>
    /// Логика взаимодействия для Element.xaml
    /// </summary>
    public partial class Element : Window
    {
        DataEntities.DataEntity entity;
        public Element(DataEntities.DataEntity entity) //ПОКА ЧТО В ОГРАНИЧЕННОМ ФОРМАТЕ
        {
            InitializeComponent();
            this.entity = entity;
            entity_name.Content = entity.getEntityName();
            entity_data.ItemsSource = entity.GetDataRepresentations()[0].getDataTable().AsDataView();
        }

        public void addDataQuantity(string name_of_value, string parameter)
        {
            if (entity is DataEntities.BasicDataEntity) 
            {
                string quantity_string = name_of_value + " " + parameter + " " + ((DataEntities.BasicDataEntity)entity).getStatValue(name_of_value, parameter);
                if (!quantities_table.Items.Contains(quantity_string)) quantities_table.Items.Add(quantity_string);
            }
        }

        private void btn_add_quantity(object sender, RoutedEventArgs e)
        {
            ActionForm.StatQuantForm new_statform = new ActionForm.StatQuantForm(this, entity);
            new_statform.ShowDialog();
        }
    }
}
