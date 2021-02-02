﻿using System;
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
using System.Data;

namespace HardAnalyzeSys.ElementForm
{
    /// <summary>
    /// Логика взаимодействия для Element.xaml
    /// </summary>
    public partial class Element : Window
    {
        public Element(DataEntities.DataEntity entity) //ПОКА ЧТО В ОГРАНИЧЕННОМ ФОРМАТЕ
        {
            InitializeComponent();
            entity_name.Content = entity.getEntityName();
            entity_data.ItemsSource = entity.GetDataRepresentations()[0].getDataTable().AsDataView();
        }
    }
}
