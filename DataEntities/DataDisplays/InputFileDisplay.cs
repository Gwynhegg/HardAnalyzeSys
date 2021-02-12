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
        private CustomControl cust_control;     //добавление кастомного элемента в отображение
        Interfaces.AbstractDataEntity reference_entity;        //сылка на родителя-элемент данных

        public InputFileDisplay(Interfaces.AbstractDataEntity entity)
        {
            cust_control = new CustomControl();

            BitmapImage bitmap = new BitmapImage();     //загружаем изображение и устанавливаем в качестве иконки элемента
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("inputfile.png", UriKind.Relative);
            bitmap.EndInit();
            cust_control.image.Source = bitmap;
            cust_control.image.MouseLeftButtonUp += toDataElementForm;

            cust_control.name.Content = entity.getEntityName();     //отображаем имя элемента данных
            reference_entity = entity;      //передаем ссылку на родительский элемент
        }

        private void moveElement(object sender, EventArgs e)
        {

        }
        private void toDataElementForm(object sender, EventArgs e)
        {
            ElementForm.Element new_dataform = new ElementForm.Element(reference_entity);       //при нажатии на картинку вызываем новую форму для отображения данных
            new_dataform.Show();
        } 
        public CustomControl getDisplayedImage(int left, int top)       //метод для вывода элемента в указанной точке экрана
        {
            cust_control.Margin = new System.Windows.Thickness(left, top, 0, 0);
            return cust_control;
        }
    }
}
