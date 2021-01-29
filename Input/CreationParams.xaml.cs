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

namespace HardAnalyzeSys.Input
{
    /// <summary>
    /// Логика взаимодействия для CreationParams.xaml
    /// </summary>
    public partial class CreationParams : Window
    {

        private DataInputForm parent_form;
        public CreationParams(DataInputForm parent_form)
        {
            InitializeComponent();
            this.parent_form = parent_form;
        }

        private void btnCreateTable(object sender, RoutedEventArgs e)
        {
            try
            {
                int num_of_params = Int32.Parse(edit_params.Text), num_of_elements = Int32.Parse(edit_elements.Text);
                if (num_of_params > 0) parent_form.getParamsAndCreate(num_of_params, num_of_elements); else throw new Exception();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось создать таблицу с указанными параметрами");
                edit_params.Text = "...";
                edit_elements.Text = "...";
            }
        }

        private void edit_params_GotFocus(object sender, RoutedEventArgs e)
        {
            if (edit_params.Text == "...") edit_params.Text = "";
        }

        private void edit_elements_GotFocus(object sender, RoutedEventArgs e)
        {
            if (edit_elements.Text == "...") edit_elements.Text = "";
        }
    }
}
