using BeenPwned.Api.Models;
using Xamarin.Forms;

namespace BeenPwned.App.Core.DataTemplateSelectors
{
    public class BreachOrPasteTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BreachTemplate { get; set; }
        public DataTemplate PasteTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item is Breach ? BreachTemplate : PasteTemplate;
        }
    }
}