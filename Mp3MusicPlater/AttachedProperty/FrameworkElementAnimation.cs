using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mp3MusicPlater
{
    public class FrameworkElementAnimation<Perent> : BaseAtachedProperty<Perent, bool>
        where Perent : BaseAtachedProperty<Perent, bool>, new()
    {
        #region Fields

        private bool _firstLoad = true; 

        #endregion

        #region Property

        public bool FirstLoad
        {
            get { return _firstLoad; }
            set { _firstLoad = value; }
        } 

        #endregion

        public override void OnValueUpdating(System.Windows.DependencyObject sender, object baseValue)
        {
            FrameworkElement element;

            if (!(sender is FrameworkElement))
                return;

            element = (FrameworkElement)sender;

            if (sender.GetValue(ValueProperty) == baseValue && !FirstLoad)
                return;

            if(FirstLoad)
            {
                RoutedEventHandler OnLoad = null;

                OnLoad = (ss, ee) =>
                    {
                        element.Loaded -= OnLoad;

                        DoAnimation(element, (bool)baseValue);

                        FirstLoad = false;
                    };

                element.Loaded += OnLoad;
            }
            else
                DoAnimation(element, (bool)baseValue);

        }

        protected virtual void DoAnimation(FrameworkElement element, bool p) { }
    }

    public class AnimateSlideFromButton : FrameworkElementAnimation<AnimateSlideFromButton>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if(value)
            {
                await element.SlideInFromBottom(0.3F);
            }
            else
            {
                await element.SlideOutToBottom(0.3F);
            }
        }
    }

    public class AnimateFadeInAndOut : FrameworkElementAnimation<AnimateFadeInAndOut>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.FadeIn(0.3F);
            }
            else
            {
                await element.FadeOut(0.3F);
            }
        }
    }
}
