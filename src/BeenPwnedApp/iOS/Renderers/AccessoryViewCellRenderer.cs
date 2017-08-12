using System;
using BeenPwned.App.Core.Controls;
using BeenPwned.App.Core.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AccessoryViewCell), typeof(AccessoryViewCellRenderer))]
namespace BeenPwned.App.Core.iOS.Renderers
{
    public class AccessoryViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            switch (((AccessoryViewCell)item).Accessory)
            {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;

                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;

                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;

                case "detail-disclosure-button":
                    cell.Accessory = UITableViewCellAccessory.DetailDisclosureButton;
                    break;

                case "disclosure":
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;

                default:
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
            }

            return cell;
        }
    }
}
