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

namespace HardAnalyzeSys.AuxiliaryForms
{
    /// <summary>
    /// Логика взаимодействия для FillerForm.xaml
    /// </summary>
    public partial class FillerForm : Window
    {
        byte dialog_result=0;
        public FillerForm()     //Вспомогательная форма для проверки корректности таблицы
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dialog_result = 1;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dialog_result = 2;
            this.Close();
        }

        public byte getDialogResult()
        {
            return dialog_result;
        }
    }
}
