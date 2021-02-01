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
            display_image.Stretch = System.Windows.Media.Stretch.Fill;
            display_image.Source = bitmap;
        }

        public Image getDisplayedImage()
        {
            return display_image;
        }
    }
}
