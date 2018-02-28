using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Mp3MusicPlater
{
    public static class FrameworkElementAnimations
    {
        #region Slide From Left To right

        public static async Task SlideFromLeftToFirstPosision(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideFromLeft(seconds, element.ActualWidth);
            sb.AddfadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideFromThirdPosisionToSecondPosisionAndGrowUp(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideToCenter(seconds, -element.ActualWidth);

            sb.GrowUp(element, 0.1f);

            sb.Begin(element, HandoffBehavior.SnapshotAndReplace, true);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideFromCenterPosisionToPosisionOnRightAndReduce(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideFromCenterToLeft(seconds, -element.ActualWidth);

            sb.Reduce(element, 0.1f);

            sb.Begin(element, HandoffBehavior.SnapshotAndReplace, true);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideOutToRight(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideOut(seconds, -element.ActualWidth);
            sb.AddfadeOut(seconds);
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        } 



        #endregion

        #region Animation From right to left

        public static async Task SlideFromRightToFirstPosision(this FrameworkElement element, 
            float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideFromRight(seconds, element.ActualWidth);
            sb.AddfadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task SlideFromFirstPosisionToSecondPosisionAndGrowUp(this FrameworkElement element,
            float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideToCenter(seconds, element.ActualWidth);

            sb.GrowUp(element, 0.1f);

            sb.Begin(element, HandoffBehavior.SnapshotAndReplace, true);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task SlideFromCenterPosisionToPosisionOnLeftAndReduce(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideFromCenterToLeft(seconds, element.ActualWidth);

            sb.Reduce(element, 0.1f);

            sb.Begin(element, HandoffBehavior.SnapshotAndReplace, true);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        }

        public static async Task SlideOutToLeft(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideOut(seconds, element.ActualWidth);
            sb.AddfadeOut(seconds);
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds);
        } 

        #endregion

        #region Animate In/Out Bottom

        public static async Task SlideInFromBottom(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideFromBotton(seconds, element.ActualHeight);
            sb.AddfadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task SlideOutToBottom(this FrameworkElement element, float seconds, int width = 0)
        {
            var sb = new Storyboard();

            sb.AddSlideOutToBootm(seconds, element.ActualHeight);
            sb.AddfadeOut(seconds);
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }


        #endregion

        #region Animate Fade In / Out

        public static async Task FadeIn(this FrameworkElement element, float seconds)
        {
            var sb = new Storyboard();

            sb.AddfadeIn(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        public static async Task FadeOut(this FrameworkElement element, float seconds)
        {
            var sb = new Storyboard();

            sb.AddfadeOut(seconds);

            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        } 

        #endregion
    }
}
