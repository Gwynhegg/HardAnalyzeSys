using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using ExcelDataReader;

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

        private void btn_excel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog(); //Открываем диалоговое окно
            dialog.Filter = "Excel files (*.xls*)|*.xls*"; //задает формат файлов маской для файлов-книг Excel
            Nullable<bool> result = dialog.ShowDialog();
            string filename = "";
            if (result == true) filename = dialog.FileName;

            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };

                try
                {
                    DataSet dataset = reader.AsDataSet(conf);
                    DataTable source_table = dataset.Tables[0];
                    data_table.ItemsSource = source_table.AsDataView(); //Устанавливаем таблицу в качестве источника данных
                } 
                catch
                {
                    MessageBox.Show("Возникла ошибка при считывании данных. Убедитесь в корректности входных данных");
                }
                
            }  
        }
    }
}
