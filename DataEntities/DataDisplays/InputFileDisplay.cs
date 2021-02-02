using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HardAnalyzeSys.DataEntities.DataDisplays
{
    public class InputFileDisplay : DataDisplay //Сюда планируется также добавлять обработчик событий
    {
        private CustomControl cust_control;
        DataEntity reference_entity;

        public InputFileDisplay(DataEntity entity)
        {
            cust_control = new CustomControl();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("inputfile.png", UriKind.Relative);
            bitmap.EndInit();
            cust_control.image.Source = bitmap;
            cust_control.image.MouseDown += toDataElementForm;

            cust_control.name.Content = entity.getEntityName();
            reference_entity = entity;
        }

        private void toDataElementForm(object sender, EventArgs e)
        {
            ElementForm.Element new_dataform = new ElementForm.Element(reference_entity);
            new_dataform.Show();
        } 
        public CustomControl getDisplayedImage(int left, int top)
        {
            cust_control.Margin = new System.Windows.Thickness(left, top, 0, 0);
            return cust_control;
        }
    }
}
