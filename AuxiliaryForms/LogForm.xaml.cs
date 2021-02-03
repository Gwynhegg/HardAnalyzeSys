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
    /// Логика взаимодействия для LogForm.xaml
    /// </summary>
    public partial class LogForm : Window
    {
        public LogForm()
        {
            InitializeComponent();
        }

        public void addLogs(string log)
        {
            logs.Items.Add(log);
        }
    }
}
