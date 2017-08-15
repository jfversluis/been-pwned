using FreshMvvm;
using PropertyChanged;

namespace BeenPwned.App.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageModel : FreshBasePageModel
    {
        protected bool _isNavigating;

        public bool IsLoading { get; set; }
    }
}