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

namespace HardAnalyzeSys.ActionForm
{
    /// <summary>
    /// Логика взаимодействия для StatQuantForm.xaml
    /// </summary>
    public partial class StatQuantForm : Window
    {

        Window parent_form;
        DataEntities.Interfaces.AbstractDataEntity data;
        bool is_numeric=false;
        string selected_quantity;
        public StatQuantForm(Window parent_form, DataEntities.Interfaces.AbstractDataEntity data)
        {
            this.parent_form = parent_form;
            this.data = data;
            InitializeComponent();
        }


        private void getNumericValues(object sender, EventArgs e)
        {
            setQuantity(sender);
            if (param_names.Items.Count == 0)
            {
                DataEntities.DataStructure temp = data.extractDataStructure();
                List<string> fields = temp.getHeaders();
                List<string> types = temp.getDataTypes();
                for (int i = 0; i < fields.Count; i++)
                    if (types[i].Equals("int") || types[i].Equals("double")) param_names.Items.Add(fields[i]);
                is_numeric = true;
            } else if (!is_numeric)
            {
                param_names.Items.Clear();
                getNumericValues(sender, e);
            }
        }

        private void getAllValues(object sender, EventArgs e)
        {
            setQuantity(sender);
            if (param_names.Items.Count == 0)
            {
                DataEntities.DataStructure temp = data.extractDataStructure();
                List<string> fields = temp.getHeaders();
                foreach (string field in fields) param_names.Items.Add(field);
                is_numeric = false;
            } else if (is_numeric)
            {
                param_names.Items.Clear();
                getAllValues(sender, e);
            }
        }

        private void btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            data.calculateStatValue(selected_quantity, param_names.SelectedItem.ToString(), is_numeric);
            if (parent_form is ElementForm.Element) ((ElementForm.Element)parent_form).addDataQuantity(selected_quantity, param_names.SelectedItem.ToString());
        }

        private void setQuantity(object sender)
        {
            switch (((ListBoxItem)sender).Content)
            {
                case "Минимум": selected_quantity = "minimal";  break;
                case "Максимум": selected_quantity = "maximal"; break;
                case "Среднее арифметическое": selected_quantity = "arithmetical mean"; break;
                case "Среднее геометрическое": selected_quantity = "geometrical mean"; break;
                case "Среднее гармоническое": selected_quantity = "harmonic mean"; break;
                case "Среднее квадратическое": selected_quantity = "square mean"; break;
                case "Мода": selected_quantity = "mode"; break;
                case "Медиана": selected_quantity = "median"; break;
                case "Математическое ожидание": selected_quantity = "math expectation"; break;
                case "Дисперсия":selected_quantity = "dispersion"; break;
                case "Среднеквадратичное отклонение": selected_quantity = "standart deviation"; break;
            }
        }

    }
}
