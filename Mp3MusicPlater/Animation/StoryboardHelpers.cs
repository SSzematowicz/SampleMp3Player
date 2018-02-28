using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Mp3MusicPlater
{
    public static class StoryboardHelpers
    {
        #region Aniamtion from Left to Right
        public static void AddSlideFromLeft(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(-offset / 4, 0, offset / 4, 0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        #endregion

        #region Animation From right to left
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(offset / 4, 0, -offset / 4, 0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        public static void AddSlideToCenter(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(0),
                From = new Thickness(offset / 4, 0, -offset / 4, 0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);

        }

        public static void AddSlideFromCenterToLeft(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset / 4, 0, offset / 4, 0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        public static void AddSlideOut(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        #endregion

        #region Scal Transform
        public static void GrowUp(this Storyboard storyboard, FrameworkElement element, float seconds, double StartScale = 1, double EndScale = 1.4)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds * 2)),
                From = StartScale,
                To = EndScale
            }; var animation2 = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds * 2)),
                From = StartScale,
                To = EndScale
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(animation2, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(animation, element);

            storyboard.Children.Add(animation);
            storyboard.Children.Add(animation2);
        }

        public static void Reduce(this Storyboard storyboard, FrameworkElement element, float seconds, double StartScale = 1.4, double EndScale = 1)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds * 2)),
                From = StartScale,
                To = EndScale
            }; var animation2 = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds * 2)),
                From = StartScale,
                To = EndScale
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(animation2, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(animation, element);

            storyboard.Children.Add(animation);
            storyboard.Children.Add(animation2);
        } 
        #endregion

        #region Fade Transform
        public static void AddfadeIn(this Storyboard storybord, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1

            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storybord.Children.Add(animation);
        }

        public static void AddfadeOut(this Storyboard storybord, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0

            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storybord.Children.Add(animation);
        } 
        #endregion

        #region Aniate in/out Bottom

        public static void AddSlideFromBotton(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness( 0, offset, 0,-offset),
                To = new Thickness(0),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        public static void AddSlideOutToBootm(this Storyboard storyboard, float seconds, double offset, float declaration = 0.9F)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = new Thickness(0, offset, 0, -offset),
                DecelerationRatio = declaration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }


        #endregion
    }
}
