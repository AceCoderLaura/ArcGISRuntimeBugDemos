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
            if (Map.LoadError is null)
            {
                MessageBox.Show("Bug fixed!");
            }
            else
            {
                MessageBox.Show(Map.LoadError.ToString());
            }
        }
    }
}