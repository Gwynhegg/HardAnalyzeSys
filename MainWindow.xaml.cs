using System;
using System.Collections.Generic;
using System.Data;
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

        private int coord_X = 10, coord_Y = 10;
        private List<DataEntities.DataEntity> data_objects;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInputData(object sender, RoutedEventArgs e)
        {
            DataInputForm new_dif = new DataInputForm(this);        //создание и вызов формы ввода данных
            new_dif.ShowDialog();
        }

        private void btnCreateProject(object sender, RoutedEventArgs e)
        {
            data_objects = new List<DataEntities.DataEntity>();     //инициализация списка дата-объектов
        }

        private void btnCloseProgram(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void enterData(DataEntities.Interfaces.AbstractDataEntity data)
        {
            data_objects.Add(data);     //дата-объект из окна ввода добавляется на главную форму
            data.setParentWindow(this);
            grid_window.Children.Add(data.displayIcon(coord_X, coord_Y));       //отображение контроллера
            coord_X += 400;
        }

    }
}
