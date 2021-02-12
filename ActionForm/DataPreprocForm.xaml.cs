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
    /// Логика взаимодействия для DataPreprocForm.xaml
    /// </summary>
    public partial class DataPreprocForm : Window
    {

        private ElementForm.Element parent;
        private DataEntities.Interfaces.AbstractDataEntity data;
        public DataPreprocForm(ElementForm.Element parent, DataEntities.Interfaces.AbstractDataEntity data)
        {
            this.parent = parent;
            this.data = data;
            InitializeComponent();

            showTitles();
        }

        private void showTitles()
        {
            List<string> headers = data.extractDataStructure().getHeaders();
            List<string> types = data.extractDataStructure().getDataTypes();

            for (int i = 0; i < headers.Count; i++) lb_titles.Items.Add(headers[i] + " : " + types[i]);
        }

        private void choose_all_Checked(object sender, RoutedEventArgs e)
        {
            lb_titles.SelectAll();
        }

        private void choose_all_Unchecked(object sender, RoutedEventArgs e)
        {
            lb_titles.UnselectAll();

        }
    }
}
