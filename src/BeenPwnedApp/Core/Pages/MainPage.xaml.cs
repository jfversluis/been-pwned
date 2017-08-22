namespace BeenPwned.App.Core.Pages
{
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BreachesList.SelectedItem = null;
        }
    }
}