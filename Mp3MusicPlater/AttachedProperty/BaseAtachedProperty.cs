using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mp3MusicPlater
{
    public class BaseAtachedProperty<Perent, Parameter>
        where Perent : new()
    {
        private Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (s, e) => { };

        private Action<DependencyObject, object> ValueUpdate = (sender, value) => { };
        #region Fields

        private static Perent _instance = new Perent();

        #endregion

        #region Property

        #endregion

        #region Property

        public static Perent GetInstance() => _instance;

        #endregion

        #region Property

        public static void SetInstance(Perent value) => _instance = value;
        #endregion

        #region Attached Property Register

        public static Parameter GetValue(DependencyObject obj) => (Parameter)obj.GetValue(ValueProperty);

        public static void SetValue(DependencyObject obj, Parameter value) => obj.SetValue(ValueProperty, value);

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(Parameter), typeof(BaseAtachedProperty<Perent, Parameter>), new PropertyMetadata(default(Parameter), new PropertyChangedCallback(OnValuePropertyChanged),new CoerceValueCallback(OnValuePropertyUpdating)));



        #endregion

        #region Private Method

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (GetInstance() as BaseAtachedProperty<Perent, Parameter>).ValueChanged(d, e);
            (GetInstance() as BaseAtachedProperty<Perent, Parameter>).OnValueChanged(d, e);
        }

        private static object OnValuePropertyUpdating(DependencyObject d, object baseValue)
        {
            (GetInstance() as BaseAtachedProperty<Perent, Parameter>).ValueUpdate(d, baseValue);
            (GetInstance() as BaseAtachedProperty<Perent, Parameter>).OnValueUpdating(d, baseValue);

            return baseValue;
        } 

        #endregion

        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) { }

        public virtual void OnValueUpdating(DependencyObject d, object baseValue) { }

    }
}
