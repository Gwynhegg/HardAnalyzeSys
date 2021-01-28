using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Data;
using System.IO;
using ExcelDataReader;
using Newtonsoft.Json;
using System.Data.OleDb;


namespace HardAnalyzeSys
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class DataInputForm : Window
    {
        public DataInputForm()
        {
            InitializeComponent();
        }

        private void btnFileInputClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //Открываем диалоговое окно
            dialog.Filter = "Excel files (*.xls*)|*.xls*|.CSV files (*.csv*)|*.csv|.JSON Files (*.json)|*.json|.XML Files (*.xml)|*.xml|Other Files|*.*"; //задает формат файлов маской
            Nullable<bool> result = dialog.ShowDialog();
            string filename = "";
            if (result == true) filename = dialog.FileName;
            if (filename == "") return;

            DataTable source_table = null;
            switch (Path.GetExtension(filename)) {
                case ".xls": source_table = excelInput(filename);  break;
                case ".xlsm": source_table = excelInput(filename); break;
                case ".xlsx": source_table = excelInput(filename); break;
                case ".csv": source_table = customInput(filename, new char[] {','}); break;
                case ".json": source_table = jsonInput(filename); break;
                case ".xml": source_table = xmlInput(filename); break;
                case ".mdb": 
                case ".accdb": source_table = accessInput(filename); break;

                default: try {
                        source_table = customInput(filename, new char[] { ',', ';', '\t' });
                    }
                    catch
                    {
                        MessageBox.Show("Файл имеет неподходящую структуру. Убедитесь в корректности входных данных");
                    }
                    break;
            }

            try
            {
                data_table.ItemsSource = source_table.AsDataView();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выводе данных на форму");
            }
        }

        private DataTable xmlInput(string filename)
        {
           XmlTextReader reader = new XmlTextReader(filename);
            DataSet data_set = new DataSet();
            data_set.ReadXml(reader);
            DataTable data_table = data_set.Tables[0];
            try
            {
                return data_table;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при считывании данных из .XML. Убедитесь в корректности входных данных");
                return null;
            }
        }

        private DataTable customInput(string filename, char[] separators)
        {
            DataTable data_table = new DataTable();
            StreamReader stream_reader = new StreamReader(filename);
            string[] headers = stream_reader.ReadLine().Split(separators);
            foreach (string header in headers) data_table.Columns.Add(header);
            while (!stream_reader.EndOfStream)
            {
                string[] row = stream_reader.ReadLine().Split(',');
                DataRow data_row = data_table.NewRow();
                for (int i = 0; i < headers.Length; i++) data_row[i] = row[i];
                data_table.Rows.Add(data_row);
            }

            try
            {
                return data_table;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при считывании файла. Убедитесь в корректности входных данных");
                return null;
            }
        }

        private DataTable jsonInput(string filename)
        {
            StreamReader stream_reader = new StreamReader(filename);
            string json = stream_reader.ReadToEnd();
            try
            {
                DataTable data_table = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
                return data_table;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при считывании данных из .JSON. Убедитесь в корректности входных данных");
                return null;
            }

        }

        private DataTable excelInput(string filename)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            ExcelDataSetConfiguration conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };

            try
            {
                DataSet dataset = reader.AsDataSet(conf);
                return dataset.Tables[0];
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при считывании данных из Excel. Убедитесь в корректности входных данных");
                return null;
            }  
        }

        private DataTable accessInput(string filename)
        {
           string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename;


            // создаем экземпляр класса OleDbConnection
            var myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();

            //решил не подключать целую библиотеку. Считываем название табилцы
            string tableName = Microsoft.VisualBasic.Interaction.InputBox("Введите название таблицы", "Название таблицы");

            // текст запроса
            string query = "SELECT * FROM " + tableName;

            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            
            OleDbCommand command = new OleDbCommand(query, myConnection);
            try
            {
                OleDbDataReader reader = command.ExecuteReader();

                DataTable dataTable = reader.GetSchemaTable();

                myConnection.Close();

                return dataTable;
            }
            catch (Exception)
            {

                myConnection.Close();

                return null;
            }
            



        }
    }
}
