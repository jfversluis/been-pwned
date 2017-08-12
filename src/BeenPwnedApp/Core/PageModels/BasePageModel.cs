using FreshMvvm;
using PropertyChanged;

namespace BeenPwned.App.Core.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class BasePageModel : FreshBasePageModel
    {
        public bool IsLoading { get; set; }
    }
}