using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;

namespace BeenPwned.App.Core.PageModels
{
    public class BreachesPageModel : FreshBasePageModel
    {
        bool _isNavigating;

        //public List<Breach> Breaches { get; set; }
        public ICommand OpenBreachCommand => new Command(async (item) => await OpenBreach(item), (arg) => !_isNavigating);

        public BreachesPageModel()
        {
            //Breaches = new List<Breach>(){
            //    new Breach{ Title="000webhost", BreachDate=new DateTime(2015,3,1), Domain="000webhost.com", PwnCount=13545468, ImageUrl="https://haveibeenpwned.com/Content/Images/PwnedLogos/000webhost.png" },
            //    new Breach{ Title="126", BreachDate=new DateTime(2012,1,1), Domain="126.com", PwnCount=6414191, ImageUrl="https://haveibeenpwned.com/Content/Images/PwnedLogos/DDO.png" },
            //    new Breach{ Title="17Media", BreachDate=new DateTime(2016,4,19), Domain="17app.co", PwnCount=4009640, ImageUrl="https://haveibeenpwned.com/Content/Images/PwnedLogos/Teracod.png" },
            //    new Breach{ Title="Abandonia", BreachDate=new DateTime(2015,11,1), Domain="abandonia.com", PwnCount=776125, ImageUrl="https://haveibeenpwned.com/Content/Images/PwnedLogos/Abandonia.png" },
            //    new Breach{ Title="AcneOrg", BreachDate=new DateTime(2014,11,25), Domain="acne.org", PwnCount=432943, ImageUrl="https://haveibeenpwned.com/Content/Images/PwnedLogos/NonNudeGirls.png" },
            //};
        }

        public async Task OpenBreach(object breach)
        {
            _isNavigating = true;
            await CoreMethods.PushPageModel<BreachPageModel>(breach, false, true);
            _isNavigating = false;
        }
    }
}

