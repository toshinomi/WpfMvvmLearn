using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMvvmLearn.ViewModels;

namespace WpfMvvmLearn.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var image = new BitmapImage(new Uri("/Resources/dog.jpg", UriKind.Relative));
            var viewModels = new MainWindowViewModels()
            {
                Image = image,
            };

            this.DataContext = viewModels;
        }
    }
}
