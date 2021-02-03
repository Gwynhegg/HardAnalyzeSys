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
        DataEntities.DataEntity data;
        public StatQuantForm(Window parent_form, DataEntities.DataEntity data)
        {
            this.parent_form = parent_form;
            this.data = data;
            InitializeComponent();
            List<string> headers = data.extractDataStructure().getHeaders();
            foreach (string header in headers) param_names.Items.Add(header);
        }


        //КНОПОЧКИ ИСКЛЛЮЧИТЕЛЬНО ПРОБНЫЕ
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculateAndTransfer("arithmetical mean");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            calculateAndTransfer("geometrical mean");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            calculateAndTransfer("maximal");
        }

        private void calculateAndTransfer(string name_of_value)
        {
            data.calculateStatValue(name_of_value, param_names.SelectedItem.ToString());
            if (parent_form is ElementForm.Element) ((ElementForm.Element)parent_form).addDataQuantity(name_of_value, param_names.SelectedItem.ToString());
        }
    }
}
