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

namespace EsriBugsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var pageType = (Type)e.Parameter;
            var page = (Page)Activator.CreateInstance(pageType);
            var bugWindow = new Window() { Content = page };
            bugWindow.Show();
        }
    }
}