﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.IO;
using ExcelDataReader;
using Newtonsoft.Json;

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
            dialog.Filter = "Excel files (*.xls*)|*.xls*|.CSV files (*.csv*)|*.csv|.JSON Files (*.json)|*.json|Other Files|*.*"; //задает формат файлов маской
            Nullable<bool> result = dialog.ShowDialog();
            string filename = "";
            if (result == true) filename = dialog.FileName;
            if (filename == "") return;

            DataTable source_table = null;
            switch (Path.GetExtension(filename)) {
                case ".xls": source_table = excelInput(filename);  break;
                case ".xlsm": source_table = excelInput(filename); break;
                case ".xlsx": source_table = excelInput(filename); break;
                case ".csv": source_table = csvInput(filename); break;
                case ".json": source_table = jsonInput(filename); break;
                default: try {
                        source_table = customInput(filename);
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

        private DataTable customInput(string filename)
        {
            DataTable data_table = new DataTable();
            StreamReader stream_reader = new StreamReader(filename);
            char[] separators = new char[] { ',', ';', '\t' };
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

        private DataTable csvInput(string filename)
        {
            DataTable data_table = new DataTable();
            StreamReader stream_reader = new StreamReader(filename);
            string[] headers = stream_reader.ReadLine().Split(',');
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
                MessageBox.Show("Возникла ошибка при считывании .CSV файла. Убедитесь в корректности входных данных");
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
    }
}
