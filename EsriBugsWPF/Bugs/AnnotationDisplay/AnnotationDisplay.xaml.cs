using System;
using System.Windows;
using System.Windows.Controls;

namespace EsriBugsWPF.Bugs.AnnotationDisplay
{
    public partial class AnnotationDisplay : Page
    {
        public AnnotationDisplay()
        {
            InitializeComponent();
            Map.Loaded += MapOnLoaded;
        }

        private void MapOnLoaded(object? sender, EventArgs e)
        {
            MessageBox.Show(Map.LoadError is null ? "Bug fixed!" : Map.LoadError.ToString());
        }
    }
}