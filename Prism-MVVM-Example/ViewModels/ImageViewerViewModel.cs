using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

namespace Prism_MVVM_Example.ViewModels
{
    public class ImageViewerViewModel : BindableBase
    {
        private ImageSource backGroundImage;

        public DelegateCommand<object> ButtonCommand { get; set; }

        public ImageViewerViewModel()
        {
            ButtonCommand = new DelegateCommand<object>(this.OnImageOpen);
        }

        private void OnImageOpen(object obj)
        {
            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(@"../../Sample.jpg", UriKind.RelativeOrAbsolute);
            bi.EndInit();
            // Set the image source.
            BackGroundImage = bi;
        }

        public ImageSource BackGroundImage
        {
            get
            {
                return backGroundImage;
            }

            set
            {
                backGroundImage = value;
                this.RaisePropertyChanged(nameof(BackGroundImage));
            }
        }
    }
}
