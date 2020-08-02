using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfMvvmLearn.Common;
using WpfMvvmLearn.Models;

namespace WpfMvvmLearn.ViewModels
{
    public class MainWindowViewModels : ViewModelsBase
    {
        private MainWindowModels model;
        public BitmapImage Image
        {
            get { return model.Image; }
            set
            {
                model.Image = value;
                OnPropertyChanged("Image");
            }
        }

        private DelegateCommand<BitmapImage> _imageSelectCommand;

        public DelegateCommand<BitmapImage> ImageSelectCommand
        {
            get
            {
                if (_imageSelectCommand == null)
                {
                    _imageSelectCommand = new DelegateCommand<BitmapImage>(
                        (image) => Image = CommaonLibrary.ImageSelect(image)
                     );
                }
                return _imageSelectCommand;
            }
        }

        public MainWindowViewModels()
        {
            model = new MainWindowModels();
        }
    }
}
