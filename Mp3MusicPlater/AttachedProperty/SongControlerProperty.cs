using Mp3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mp3MusicPlater
{
    public class AnimationTypeProperty : BaseAtachedProperty<AnimationTypeProperty, ControlAnimation>
    {
        public async override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs value)
        {
            FrameworkElement element;

            if (!(sender is FrameworkElement))
            {
                return;
            }

            element = (FrameworkElement)sender;

            //if (sender.GetValue(ValueProperty) == value.NewValue)
            //    return;

            await ((BaseControl)element).Animation((ControlAnimation)value.NewValue);
        }
    }
}
