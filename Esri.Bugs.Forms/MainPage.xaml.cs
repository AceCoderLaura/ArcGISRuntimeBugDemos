namespace Esri.Bugs.Forms
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            PushAsync(new FreezeDemo());
        }
    }
}