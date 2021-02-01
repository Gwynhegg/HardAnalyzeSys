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
        private Image display_image;

        public InputFileDisplay()
        {
            display_image = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("inputfile.png", UriKind.Relative);
            bitmap.EndInit();
            display_image.Width = 100; display_image.Height = 100;
            display_image.Stretch = System.Windows.Media.Stretch.Fill;
            display_image.Source = bitmap;
        }

        public Image getDisplayedImage(int left, int top)
        {
            display_image.Margin = new System.Windows.Thickness(left, top, 0, 0);
            return display_image;
        }
    }
}
