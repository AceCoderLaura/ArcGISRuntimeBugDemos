using System;
using System.Windows.Controls;
using System.Windows.Input;
using Esri.ArcGISRuntime.Mapping;

namespace EsriBugsWPF.Bugs.StickyVisibility
{
    public partial class StickyVisibilityPage : Page
    {
        public StickyVisibilityPage()
        {
            InitializeComponent();
        }

        private async void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var step = int.Parse(e.Parameter.ToString());

            switch (step)
            {
                case 0:
                {
                    await GroupLayer.Layers[0].LoadAsync();
                    GroupLayer.Layers[0].IsVisible = !GroupLayer.Layers[0].IsVisible;
                    break;
                }
                case 1:
                {
                    GroupLayer.IsVisible = !GroupLayer.IsVisible;
                    GroupLayer.IsVisible = !GroupLayer.IsVisible;
                    break;
                }
            }
        }
    }
}