using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Map = Esri.ArcGISRuntime.Mapping.Map;

namespace Esri.Bugs.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FreezeMapPage
    {
        private const int ReturnTime = 2000;

        public FreezeMapPage()
        {
            InitializeComponent();
            var basemap = new Basemap(new ArcGISTiledLayer(new Uri("https://services.arcgisonline.com/arcgis/rest/services/World_Topo_Map/MapServer")));
            MapView.Map = new Map(basemap);
            basemap.LoadAsync().ContinueWith(LayerLoadHandler);

            var groupLayer = new GroupLayer();
            MapView.Map.OperationalLayers.Add(groupLayer);
            
            var l0 = AddFeatureLayer("https://services1.arcgis.com/VuN78wcRdq1Oj69W/ArcGIS/rest/services/River_Management_Assets_(AMIS_Mobile)/FeatureServer/0");
            groupLayer.Layers.Add(l0);
            var l1 = AddFeatureLayer("https://services1.arcgis.com/VuN78wcRdq1Oj69W/ArcGIS/rest/services/River_Management_Assets_(AMIS_Mobile)/FeatureServer/1");
            groupLayer.Layers.Add(l1);
            var l2 = AddFeatureLayer("https://services1.arcgis.com/VuN78wcRdq1Oj69W/ArcGIS/rest/services/River_Management_Assets_(AMIS_Mobile)/FeatureServer/2");
            groupLayer.Layers.Add(l2);
        }

        private static FeatureLayer AddFeatureLayer(string layerAddress)
        {
            var featureLayer = new FeatureLayer(new Uri(layerAddress));
            featureLayer.LoadAsync().ContinueWith(LayerLoadHandler);
            return featureLayer;
        }

        protected override async void OnAppearing()
        {
            if (MapView.LocationDisplay.DataSource == null) throw new InvalidOperationException();
            
            base.OnAppearing();
        
            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            MapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.Navigation;
            await MapView.LocationDisplay.DataSource.StartAsync();
            MapView.LocationDisplay.IsEnabled = true;

            await Task.Delay(ReturnTime);
            await Navigation.PopAsync();
        }

        private static async void LayerLoadHandler(Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Debug.WriteLine(e);
            }
        }
    }
}