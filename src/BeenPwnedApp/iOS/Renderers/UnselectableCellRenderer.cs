using System;
using BeenPwned.App.Core.ViewCells;
using BeenPwned.App.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UnselectableCell), typeof(UnselectableCellRenderer))]
namespace BeenPwned.App.iOS.Renderers
{
    public class UnselectableCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            cell.SelectedBackgroundView = new UIView() { BackgroundColor = UIColor.Clear };
            cell.SelectionStyle = UITableViewCellSelectionStyle.None;

            return cell;
        }
    }
}