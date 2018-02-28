using System.Windows;
using System.Windows.Controls;

namespace Mp3MusicPlater
{
    /// <summary>
    /// https://www.codeproject.com/Articles/1092326/WPF-ListView-With-Drag-Selection
    /// </summary>
    public sealed class DragSelection : UserControl
    {
        public static DependencyProperty SelectionProperty = DependencyProperty.Register("Selection", typeof(Selection), typeof(DragSelection), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Selection Selection
        {
            get
            {
                return (Selection)GetValue(SelectionProperty);
            }
            set
            {
                SetValue(SelectionProperty, value);
            }
        }

        public DragSelection() : base()
        {
            this.DefaultStyleKey = typeof(DragSelection);
        }
    }
}
