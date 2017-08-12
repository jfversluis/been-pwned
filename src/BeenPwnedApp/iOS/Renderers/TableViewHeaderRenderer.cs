using System;
using CoreGraphics;
using BeenPwned.App.Core.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TableView), typeof(TableViewHeaderRenderer))]
namespace BeenPwned.App.Core.iOS.Renderers
{
    public class TableViewHeaderRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var nativeTableView = Control as UITableView;
            var tableView = Element as TableView;
            nativeTableView.WeakDelegate = new CustomHeaderTableModelRenderer(tableView);
        }

        private class CustomHeaderTableModelRenderer : UnEvenTableViewModelRenderer
        {
            private readonly TableView _tableView;

            public CustomHeaderTableModelRenderer(TableView model) : base(model)
            {
                _tableView = model as TableView;
            }

            public override UIView GetViewForHeader(UITableView tableView, nint section)
            {
                var view = new UIView(new CGRect(0, 200, 300, 244));
                var top = section == 0 ? 17 : 0;

                var label = new UILabel(new CGRect(15, top, 300, 44))
                {
                    Text = TitleForHeader(tableView, section),
                    Font = UIFont.FromName("Ubuntu-Regular", 15),
                    TextAlignment = UITextAlignment.Left,
                    TextColor = UIColor.Gray
                };

                view.AddSubview(label);

                return view;
            }
        }
    }
}
