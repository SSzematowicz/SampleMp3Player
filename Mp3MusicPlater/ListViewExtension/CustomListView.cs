using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace Mp3MusicPlater
{
    /// <summary>
    /// https://www.codeproject.com/Articles/1092326/WPF-ListView-With-Drag-Selection
    /// </summary>
    public class CustomListView : ListView, IDragSelector
    {
        #region Property
        public DragSelector DragSelector
        {
            get { return (DragSelector)GetValue(DragSelectorProperty); }
            set { SetValue(DragSelectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DragSelector.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DragSelectorProperty =
            DependencyProperty.Register("DragSelector", typeof(DragSelector), typeof(CustomListView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //*****************************************************************************************************************************************************************************************
        /// <summary>
        /// Enables selecting items whiile draging with a rectangle selector
        /// </summary>
        public bool IsDragSelectionEnabled
        {
            get { return (bool)GetValue(IsDragSelectionEnabledProperty); }
            set { SetValue(IsDragSelectionEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragSelectionEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragSelectionEnabledProperty =
            DependencyProperty.Register("IsDragSelectionEnabled", typeof(bool), typeof(CustomListView),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //*****************************************************************************************************************************************************************************************
        /// <summary>
        /// Determines whether or not selections should  wrap to beginig or end
        /// </summary>
        public bool ScrollWrap
        {
            get { return (bool)GetValue(ScrollWrapProperty); }
            set { SetValue(ScrollWrapProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollWrap.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollWrapProperty =
            DependencyProperty.Register("ScrollWrap", typeof(bool), typeof(CustomListView),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        //*****************************************************************************************************************************************************************************************
        /// <summary>
        /// Indicates offset to apply when automatically scrolling.
        /// </summary>
        public double ScrollOffset
        {
            get { return (double)GetValue(ScrollOffsetProperty); }
            set { SetValue(ScrollOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollOffsetProperty =
            DependencyProperty.Register("ScrollOffset", typeof(double), typeof(CustomListView),
                new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //*****************************************************************************************************************************************************************************************
        /// <summary>
        /// Indicates how far from outer width/height to allow offset application when automatically scrolling.
        /// </summary>
        public double ScrollTolerance
        {
            get { return (double)GetValue(ScrollToleranceProperty); }
            set { SetValue(ScrollToleranceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScrollTolerance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScrollToleranceProperty =
            DependencyProperty.Register("ScrollTolerance", typeof(double), typeof(CustomListView), new FrameworkPropertyMetadata(5.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //*****************************************************************************************************************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        public Selection Selection
        {
            get { return (Selection)GetValue(SelectionProperty); }
            set { SetValue(SelectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionProperty =
            DependencyProperty.Register("Selection", typeof(Selection), typeof(CustomListView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        //***************************************************************************************************************************************************************************************** 
        #endregion //Property

        #region Private Method
        /// <summary>
        /// Move curent selection to the left
        /// </summary>
        void MoveLeft()
        {
            if (SelectedItems.Count == 0)
            {
                this.Items.MoveCurrentToFirst();
            }
            else if (!this.Items.MoveCurrentToPrevious())
            {
                if (ScrollWrap)
                    this.Items.MoveCurrentToLast();
            }
        }

        /// <summary>
        /// Move current selection to the right
        /// </summary>
        void MoveRight()
        {
            if (this.SelectedItems.Count == 0)
            {
                this.Items.MoveCurrentToLast();
            }
            else if (!this.Items.MoveCurrentToNext())
            {
                if (ScrollWrap)
                {
                    this.Items.MoveCurrentToFirst();
                }
            }
        }

        void MoveToNextRow(string Direction, int ItemsPerRow, int offset = 1)
        {
            int? NewIndex = null;
            if (Direction == "Up")
            {
                NewIndex = this.SelectedIndex - ItemsPerRow + offset;
                if (NewIndex < 0)
                {
                    //NewIndex = this.ScrollWrap ? this.Items.Count + NewIndex : null;
                }
            }
            else if (Direction == "Down")
            {
                NewIndex = this.SelectedIndex + ItemsPerRow - offset;
                if (NewIndex >= this.Items.Count)
                {
                    //NewIndex = this.ScrollWrap ? NewIndex - this.Items.Count : null;
                }
            }

            if (NewIndex != null)
            {
                NewIndex = NewIndex < 0 ? 0 :
                    (NewIndex >= this.Items.Count ? this.Items.Count - 1 : NewIndex);
            }
            this.SelectedIndex = NewIndex.Value;
        }
        #endregion //Private Method

        #region Override
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.DragSelector = new DragSelector(this);
        }

        #endregion

        #region Command
        public static readonly RoutedUICommand MakeSelection = new RoutedUICommand("MakeSelection", "MakeSelection", typeof(CustomListView));

        void MakeSelection_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Can't select nating so doo nathing
            if (this.Items.Count == 0)
                return;

            string Direction = e.Parameter.ToString();
            switch(Direction)
            {
                case "Up":
                case "Down":

                    double listViewWidth = this.ActualWidth - this.Padding.Left - this.Padding.Right;
                    double SelectedItemwidth =
                        ((ListViewItem)this.ItemContainerGenerator.ContainerFromItem(this.Items.CurrentItem)).ActualWidth;
                    int ItemPerRow = Convert.ToInt32(Math.Round(listViewWidth / SelectedItemwidth));
                    if(ItemPerRow > 1)
                    {
                        if (Direction == "Up")
                            this.MoveLeft();
                        else if (Direction == "Down")
                            this.MoveRight();
                        return;
                    }
                    this.MoveToNextRow(Direction, ItemPerRow);
                    break;

                case "Left":
                    this.MoveLeft();
                    break;

                case "Right":
                    this.MoveRight();
                    break;
            }
        }
        #endregion

        #region Constructor
        public CustomListView() : base()
        {
            this.DefaultStyleKey = typeof(CustomListView);

            //enables moving current selection around 
            this.IsSynchronizedWithCurrentItem = true;

            this.CommandBindings.Add(new CommandBinding(MakeSelection, this.MakeSelection_Executed));

            this.InputBindings.Add(new KeyBinding(MakeSelection, Key.Up, ModifierKeys.None)
            {
                CommandParameter = "Up"
            });

            this.InputBindings.Add(new KeyBinding(MakeSelection, Key.Down, ModifierKeys.None)
            {
                CommandParameter = "Doun"
            });

            this.InputBindings.Add(new KeyBinding(MakeSelection, Key.Left, ModifierKeys.None)
            {
                CommandParameter = "Left"
            });

            this.InputBindings.Add(new KeyBinding(MakeSelection, Key.Right, ModifierKeys.None)
            {
                CommandParameter = "Right"
            });
        }
        #endregion
    }
}
