using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;

namespace Esri.Bugs.WPF.Bugs.SiteFeaturesNotRendered;

public partial class SiteNotRenderedPage
{
    private const string UserName = "<USERNAME HERE>";
    private const string Password = "<PASSWORD HERE>";
    private readonly Uri _tokenServiceUri = new("https://www.arcgis.com/sharing/generateToken");

    private readonly Uri _siteLayerUri =
        new("https://services7.arcgis.com/NJHIMDi2fUuUjO4A/arcgis/rest/services/Sites/FeatureServer/0");


    public SiteNotRenderedPage()
    {
        AuthenticationManager.Current.ChallengeHandler = new ChallengeHandler(HardCodedCredentialsChallengeHandler);

        InitializeComponent();
        
        var siteLayer = new FeatureLayer(_siteLayerUri);
        Map.Basemap = new Basemap(BasemapStyle.OSMStandard);
        Map.OperationalLayers.Add(siteLayer);
        siteLayer.LoadAsync().ContinueWith(OnLayerLoaded);
    }

    private async Task<Credential> HardCodedCredentialsChallengeHandler(CredentialRequestInfo arg)
    {
        return await AccessTokenCredential.CreateAsync(_tokenServiceUri, UserName, Password);
    }

    private async void OnLayerLoaded(Task loadTask)
    {
        try
        {
            await loadTask;
            await ViewSite1289();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debugger.Break();
        }
    }

    private async Task ViewSite1289()
    {
        await MapView.SetViewpointGeometryAsync(new Envelope
        (
            19093357.123163823,
            -5130897.340611409,
            19093525.463407494,
            -5130814.47087067,
            SpatialReference.Create(3857)
        ));
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var siteLayer = (FeatureLayer)Map.OperationalLayers.Single();
            if (siteLayer.FeatureTable == null) throw new InvalidOperationException("Feature table was null!");
            await siteLayer.FeatureTable.QueryFeaturesAsync(new QueryParameters
                { MaxFeatures = 1, WhereClause = "AdaptKey = '1289'" });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Debugger.Break();
        }
    }
}