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
    public class MainWindowViewModels : INotifyPropertyChanged
    {
        private MainWindowModels model;
        public BitmapImage Image
        {
            get { return model.Image; }
            set
            {
                model.Image = value;
                NotifyPropertyChanged("Image");
            }
        }
        private DelegateCommand _imageSelectCommand;

        public DelegateCommand ImageSelectCommand
        {
            get
            {
                if (_imageSelectCommand == null)
                {
                    _imageSelectCommand = new DelegateCommand(
                        () => Image = CommaonLibrary.ImageSelect(),
                        () => true
                     );
                }
                return _imageSelectCommand;
            }
        }

        public MainWindowViewModels()
        {
            model = new MainWindowModels();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
