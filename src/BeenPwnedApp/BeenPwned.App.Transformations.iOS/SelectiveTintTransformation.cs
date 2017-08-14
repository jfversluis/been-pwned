using System;
using Foundation;
using CoreGraphics;
using FFImageLoading.Transformations;
using UIKit;

namespace BeenPwned.App.Transformations
{

    [Foundation.Preserve(AllMembers = true)]
    public class SelectiveTintTransformation : TintTransformation
    {
        protected override UIImage Transform(UIImage sourceBitmap, string path, FFImageLoading.Work.ImageSource source, bool isPlaceholder, string key)
        {
            // Only do this if its a grayscale image.
            if (IsGrayScale(sourceBitmap))
            {
                if (EnableSolidColor)
                    return ToSolidColor(sourceBitmap, R, G, B, A);

                RGBAWMatrix = FFColorMatrix.ColorToTintMatrix(R, G, B, A);

                return base.Transform(sourceBitmap, path, source, isPlaceholder, key);
            }

            return sourceBitmap;
        }

        bool IsGrayScale(UIImage sourceBitmap)
        {
            var source = sourceBitmap.CGImage;
            var width = source.Width;
            var height = source.Height;
            var imageData = new byte[width * height * 4];
            var bytesPerPixel = 4;
            var bytesPerRow = bytesPerPixel * width;
            var bitsPerComponent = 8;

            var imageContext = new CGBitmapContext(imageData, width, height, bitsPerComponent, bytesPerRow, source.ColorSpace, CGImageAlphaInfo.PremultipliedLast);

            imageContext.SetBlendMode(CGBlendMode.Copy);
            imageContext.DrawImage(CGRect.FromLTRB(0, 0, width, height), source);
            imageContext.Dispose();

            int byteIndex = 0;
            bool imageIsGrayscale = true;

            for (; byteIndex < width * height * 4; byteIndex += 4)
            {
                var red = imageData[byteIndex] / 255.0f;
                var green = imageData[byteIndex + 1] / 255.0f;
                var blue = imageData[byteIndex + 2] / 255.0f;
                var alpha = imageData[byteIndex + 3] / 255.0f;

                if (alpha == 1 && (red != green || red != blue || green != blue))
                {
                    imageIsGrayscale = false;
                    break;
                }
            }

            return imageIsGrayscale;
        }
    }
}
