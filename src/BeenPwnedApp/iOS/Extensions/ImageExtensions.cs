using System;
using System.Drawing;
using UIKit;

namespace BeenPwned.App.Core.iOS.Extensions
{
    public static class ImageExtensions
    {
        public static UIImage ToUIImage(this UIColor color)
        {
            var imageSize = new SizeF(1, 1);
            var imageSizeRectF = new RectangleF(0, 0, 1, 1);
            UIGraphics.BeginImageContextWithOptions(imageSize, false, 0);
            var context = UIGraphics.GetCurrentContext();

            context.SetFillColor(color.CGColor);
            context.FillRect(imageSizeRectF);
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return image;
        }
    }
}
