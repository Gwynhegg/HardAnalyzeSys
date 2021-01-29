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

namespace HardAnalyzeSys
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<DataEntities.DataEntity> data_objects;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInputData(object sender, RoutedEventArgs e)
        {
            DataInputForm new_dif = new DataInputForm();
            new_dif.ShowDialog();
        }

        private void btnCreateProject(object sender, RoutedEventArgs e)
        {
            data_objects = new List<DataEntities.DataEntity>();
        }

        public void enterBasicData(DataEntities.BasicDataEntity data)
        {
            data_objects.Add(data);
            //Также здесь следует отобразить значок данных
        }
    }
}
