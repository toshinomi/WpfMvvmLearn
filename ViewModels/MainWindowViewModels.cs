using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
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
        public ICommand ImageSelect { set; get; }

        public MainWindowViewModels()
        {
            model = new MainWindowModels();
            ImageSelect = new ImageSelectCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }

    public class ImageSelectCommand : ICommand
    {
        private MainWindowViewModels _viewModel;

        public ImageSelectCommand(MainWindowViewModels viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new Uri(openFileDialog.FileName));
                _viewModel.Image = image;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
