namespace BeenPwned.App.Core.Pages
{
    public partial class BreachesPage : BasePage
    {
        public BreachesPage()
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