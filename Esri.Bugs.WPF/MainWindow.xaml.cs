using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Esri.Bugs.WPF
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
            var bugWindow = new Window { Content = page };
            bugWindow.Show();
        }
    }
}