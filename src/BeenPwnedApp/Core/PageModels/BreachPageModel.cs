namespace BeenPwned.App.Core.PageModels
{
    public class BreachPageModel : BasePageModel
    {
        //public Breach Breach { get; set; }

        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData != null)
            {
                //Breach = (Breach)initData;
            }
        }
    }
}
