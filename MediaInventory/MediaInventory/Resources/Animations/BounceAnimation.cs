using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MediaInventory.Resources.Animations
{
    public static class BounceAnimation
    {
        //http://blog.pixelingene.com/?p=37
        //Genie animation
        public static void Play(UIElement controlToAnimate)
        {
            Storyboard story = new Storyboard();
            // opacity animation
            DoubleAnimationUsingKeyFrames opacityAnimation = new DoubleAnimationUsingKeyFrames();
            opacityAnimation.BeginTime = TimeSpan.FromMilliseconds(0);
            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(0.8, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));
            ((SplineDoubleKeyFrame)opacityAnimation.KeyFrames[2]).KeySpline = new KeySpline(0, 1, 1, 1);
            Storyboard.SetTarget(opacityAnimation, controlToAnimate);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            story.Children.Add(opacityAnimation);
            //stretch horizontally
            DoubleAnimationUsingKeyFrames scaleXAnimation = new DoubleAnimationUsingKeyFrames();
            scaleXAnimation.BeginTime = TimeSpan.FromMilliseconds(0);
            scaleXAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(0.95, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            scaleXAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(1.08, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
            scaleXAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));
            Storyboard.SetTarget(scaleXAnimation, controlToAnimate);
            Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));
            story.Children.Add(scaleXAnimation);
            //stretch vertically
            DoubleAnimationUsingKeyFrames scaleYAnimation = new DoubleAnimationUsingKeyFrames();
            scaleYAnimation.BeginTime = TimeSpan.FromMilliseconds(0);
            scaleYAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(0.95, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0))));
            scaleYAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(1.08, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(200))));
            scaleYAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300))));
            Storyboard.SetTarget(scaleYAnimation, controlToAnimate);
            Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));
            story.Children.Add(scaleYAnimation);
            if (!(controlToAnimate.RenderTransform is TransformGroup))
            {
                TransformGroup group = new TransformGroup();
                group.Children.Add(new ScaleTransform(1, 1, controlToAnimate.RenderSize.Height / 2, controlToAnimate.RenderSize.Width / 2));
                controlToAnimate.RenderTransform = group;
            }
            story.Begin();
        }
    }
}