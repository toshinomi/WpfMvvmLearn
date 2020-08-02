using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfMvvmLearn.Common;
using WpfMvvmLearn.Common.ImageProcessing;
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
                        (image) =>
                        {
                            try
                            {
                                Image = CommonHelper.ImageSelect(image);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                     );
                }
                return _imageSelectCommand;
            }
        }
        private DelegateCommand<BitmapImage> _imageProcessingCommand;
        public DelegateCommand<BitmapImage> ImageProcessingCommand
        {
            get
            {
                if (_imageProcessingCommand == null)
                {
                    _imageProcessingCommand = new DelegateCommand<BitmapImage>(
                        (image) =>
                        {
                            var edgeDetection = new EdgeDetection();
                            var writeableBitmap = new WriteableBitmap(image);
                            edgeDetection.ImageProcessing(ref writeableBitmap);
                            Image = CommonHelper.ToBitmapImage(writeableBitmap);
                        },
                        () => Image != null
                     );
                }
                return _imageProcessingCommand;
            }
        }

        public MainWindowViewModels()
        {
            model = new MainWindowModels();
        }
    }
}
