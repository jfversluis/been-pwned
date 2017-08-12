//using System;
//using CoreAnimation;
//using BeenPwned.App.Core.iOS.Renderers;
//using UIKit;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(NavigationPage), typeof(AnimationNavigationRenderer))]
//namespace BeenPwned.App.Core.iOS.Renderers
//{
//    public class AnimationNavigationRenderer : NavigationRenderer
//    {
//        public override void PushViewController(UIViewController viewController, bool animated)
//        {
//            if (animated)
//            {
//                // Alternative way with different set of trannsition
//                /*
//				UIView.Animate(0.75, () =>
//				{
//					UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);
//					base.PushViewController(viewController, false);
//					UIView.SetAnimationTransition(UIViewAnimationTransition.CurlUp, this.View, false);
//				});
//				 */
//                var transition = CATransition.CreateAnimation();
//                transition.Duration = 0.75;
//                IUIViewControllerAnimatedTransitioning.
//                transition.Type = CAAnimation.TransitionReveal;

//                View.Layer.AddAnimation(transition, null);
//                base.PushViewController(viewController, false);
//            }
//            else
//            {
//                base.PushViewController(viewController, false);
//            }
//        }

//        public override UIViewController PopViewController(bool animated)
//        {
//            if (animated)
//            {
//                // Alternative way with different set of trannsition
//                /*                UIView.Animate(0.75, () =>
//				{
//					UIView.SetAnimationCurve(UIViewAnimationCurve.EaseInOut);
//					UIView.SetAnimationTransition(UIViewAnimationTransition.CurlDown, this.View, false);
//				});
//				*/

//                var transition = CATransition.CreateAnimation();
//                transition.Duration = 0.75;
//                transition.Type = CAAnimation.TransitionMoveIn;

//                View.Layer.AddAnimation(transition, null);

//                return base.PopViewController(false);
//            }

//            return base.PopViewController(false);
//        }
//    }
//}