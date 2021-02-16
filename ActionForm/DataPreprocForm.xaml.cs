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
        private DataEntities.DataStructure data;
        public DataPreprocForm(ElementForm.Element parent, DataEntities.DataStructure data)
        {
            this.parent = parent;
            this.data = data;
            InitializeComponent();

            showTitles();
        }

        private void showTitles()
        {
            List<string> headers = data.getHeaders();
            List<string> types = data.getDataTypes();

            for (int i = 0; i < headers.Count; i++)
            {
                lb_titles.Items.Add(headers[i]);
                lb_types.Items.Add(types[i]);
            }
        }

        private void choose_all_Checked(object sender, RoutedEventArgs e)
        {
            lb_titles.SelectAll();
        }

        private void choose_all_Unchecked(object sender, RoutedEventArgs e)
        {
            lb_titles.UnselectAll();

        }

        private void change_current_Click(object sender, RoutedEventArgs e)
        {
            AuxiliaryForms.WarningForm warning = new AuxiliaryForms.WarningForm();
            if (warning.ShowDialog() == true)
            {
                if (lb_titles.SelectedItems.Count != data.sizeOfHeaders())
                    data = createSample();
            } else return;

            if (clear_tuples.IsChecked==true) data = clearTuples(data);
            clearBlowouts(data);
            Console.WriteLine();

        }

        private void create_new_Click(object sender, RoutedEventArgs e)
        {
            DataEntities.DataStructure preprocessed_data = data;
            if (lb_titles.SelectedItems.Count != data.sizeOfHeaders())
                preprocessed_data = createSample();

            if (clear_tuples.IsChecked == true) preprocessed_data = clearTuples(preprocessed_data);
            clearBlowouts(preprocessed_data);
            Console.WriteLine();
        }

        private void clearBlowouts(DataEntities.DataStructure data)
        {
            switch (blowouts.Text.ToString())
            {
                case "Нет": break;
                case "Межквартильное расстояние": data = DataEntities.BlowoutsLibrary.clearBlowouts(data, "interquartile distance"); break;
                case "Критерий Шовене": data = DataEntities.BlowoutsLibrary.clearBlowouts(data,"criterion Chauvenet");  break;
                case "Критерий Грабса":data = DataEntities.BlowoutsLibrary.clearBlowouts(data,"criterion Grabs"); break;
                case "Критерий Пирса": break;
                case "Критерий Диксона": break;
            }
        }

        private DataEntities.DataStructure clearTuples(DataEntities.DataStructure data)
        {
            int itera;
            for (int i = 0; i < data.sizeOfStructure(); i++)
            {
                itera = i + 1;
                while (itera < data.sizeOfStructure())
                    if (data[i].compareTo(data[itera])) data.deleteRecord(itera); else itera++; 
            }

            return data;
        }

        private DataEntities.DataStructure createSample()
        {

            if (data is DataEntities.DataStructures.TableStructure)
            {
                DataEntities.DataStructures.TableStructure temporary_data = new DataEntities.DataStructures.TableStructure();
                List<string> data_headers = data.getHeaders();
                List<string> data_types = data.getDataTypes();
                for (int i = 0; i < data.sizeOfHeaders(); i++)
                    if (lb_titles.SelectedItems.Contains(data_headers[i]))
                    {
                        temporary_data.setHeaders(data_headers[i]);
                        temporary_data.setDataTypes(data_types[i]);
                    }

                object[][] matrix = new object[data.sizeOfStructure()][];
                for (int i = 0; i < data.sizeOfStructure(); i++) matrix[i] = new object[temporary_data.sizeOfHeaders()];

                for (int i = 0; i < data.sizeOfStructure(); i++)
                    for (int j = 0; j < temporary_data.sizeOfHeaders(); j++)
                        matrix[i][j] = data[i][data_headers.IndexOf(temporary_data.getHeaders()[j])];

                for (int i = 0; i < data.sizeOfStructure(); i++)
                    temporary_data.addRecords(new DataEntities.DataStructures.DataRecord(matrix[i]));

                return temporary_data;
            }
            else return null;
        }
    }
}
