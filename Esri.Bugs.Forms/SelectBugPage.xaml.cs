using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Esri.Bugs.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectBugPage : ContentPage
    {
        public SelectBugPage()
        {
            InitializeComponent();
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (!(e.SelectedItem is BugInfo bug)) return;
                var demoPage = (Page)Activator.CreateInstance(bug.DemoPageType);
                await Navigation.PushAsync(demoPage);
                BugList.ClearValue(ListView.SelectedItemProperty);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}