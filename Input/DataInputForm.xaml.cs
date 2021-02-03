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

        private MainWindow parent_window;       //окно-родитель для последующей передачи дата-объекта
        private DataTable source_table;     //таблица для хранения значений
        public DataInputForm(MainWindow parent)     //конструктор запоминает окно-родителя
        {
            parent_window = parent;
            InitializeComponent();
        }

        private void btnFileInputClick(object sender, RoutedEventArgs e)        //метод, обрабатывающий разные варианты ввода данных
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //Открываем диалоговое окно
            dialog.Filter = "Excel files (.xls*)|*.xls*|.CSV files (.csv)|*.csv|.JSON Files (.json)|*.json|.XML Files (.xml)|*.xml|" +
                "Access Datafiles (.mdb)|*.mdb|Access Datafiles (.accdb)|*.accdb|Other Files|*.*"; //задает формат файлов маской
            Nullable<bool> result = dialog.ShowDialog();
            string filename = "";
            if (result == true) filename = dialog.FileName;
            if (filename == "") return;

            source_table = null;
            switch (Path.GetExtension(filename)) {
                case ".xls":
                case ".xlsm":
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

            if (source_table != null) try
            {
                data_table.ItemsSource = null;
                data_table.ItemsSource = source_table.AsDataView();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выводе данных на форму");
            }
        }

        private DataTable xmlInput(string filename)     //Ввод данных через .XML
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

        private DataTable customInput(string filename, char[] separators)       //Ввод данных ручками
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

        private DataTable jsonInput(string filename)        //Ввод данных через .JSON
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

        private DataTable excelInput(string filename)       //Ввод данных через Excel
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

        //ПОКА ЧТО НЕ РАБОТАЕТ
        private DataTable accessInput(string filename)
        {
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename;
            OleDbConnection my_connection;
            try
            {
                my_connection = new OleDbConnection(connectString);             // создаем экземпляр класса OleDbConnection
                my_connection.Open();            // открываем соединение с БД
            }
            catch
            {
                MessageBox.Show("Не удалось установить соединение с базой Access");
                return null;
            }
            string tableName = Microsoft.VisualBasic.Interaction.InputBox("Введите название таблицы", "Название таблицы");            //решил не подключать целую библиотеку. Считываем название табилцы
            string query = "SELECT * FROM " + tableName;            // текст запроса
            OleDbCommand command = new OleDbCommand(query, my_connection);            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbDataReader reader = command.ExecuteReader();
            DataSet dataset = new DataSet();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            oleDbDataAdapter.Fill(dataset);
            my_connection.Close();
            try
            {
                return dataset.Tables[0];
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при считывании данных из Access. Убедитесь в корректности входных данных");
                return null;
            }  
        }

        private void btnСreateClick(object sender, RoutedEventArgs e)       //вызов формы для создания новой таблицы
        {
            Input.CreationParams new_table_form = new Input.CreationParams(this);
            new_table_form.ShowDialog();
        }

        public void getParamsAndCreate(int num_of_params, int num_of_elements)      //получение параметров таблицы и ее создание
        {
            source_table = new DataTable();
            for (int i = 0; i < num_of_params; i++) source_table.Columns.Add("param" + (i + 1));
            for (int j = 0; j < num_of_elements; j++) source_table.Rows.Add(source_table.NewRow());
            try
            {
                data_table.ItemsSource = null;
                data_table.ItemsSource = source_table.AsDataView();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при выводе данных на форму");
            }
        }

        private void btnAddParameter(object sender, RoutedEventArgs e)      //метод для добавления параметра в таблицу
        {
            data_table.Columns.Add(new DataGridTextColumn() { Header = "param" + data_table.Columns.Count });
        }

        private void btnCreateObject(object sender, RoutedEventArgs e)      //Создание экземпляра дата-объекта и установка всех необходимых параметров
        {
            DataEntities.BasicDataEntity basic_data = new DataEntities.BasicDataEntity();
            basic_data.createDataStructure(source_table);
            basic_data.setEntityName(element_name.Text);

            //Тут происходит создание элемента BasicDataEntity, проверка на корректность и передача его на главную форму
            //Преобразовать данные из таблицы в массивы и передать
            parent_window.enterBasicData(basic_data);
            this.Close();
        }
    }
}
