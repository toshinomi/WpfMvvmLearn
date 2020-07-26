using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WpfMvvmLearn.Models
{
    class MainWindowModels
    {
        public BitmapImage Image { get; set; }
        public MainWindowModels()
        {
            Image = new BitmapImage();
        }
    }
}
