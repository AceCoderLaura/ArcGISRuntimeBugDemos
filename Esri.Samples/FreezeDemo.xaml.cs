using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Esri.Samples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreezeDemo : ContentPage
    {
        private readonly FreezeMapPage _freezeMapPage = new FreezeMapPage();
        
        public FreezeDemo()
        {
            InitializeComponent();
        }
        
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(_freezeMapPage);
        }
    }
}