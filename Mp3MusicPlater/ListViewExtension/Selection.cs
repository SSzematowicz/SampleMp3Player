using System;
using System.Windows;
using Mp3.Core;

namespace Mp3MusicPlater
{
    /// <summary>
    /// https://www.codeproject.com/Articles/1092326/WPF-ListView-With-Drag-Selection
    /// </summary>
    public class Selection : BaseViewModel
    {
        #region Properties

        public event EventHandler<EventArgs> SelectionChanged;

        private double mWidth = 0;
        public double Width
        {
            get
            {
                return mWidth;
            }
            set
            {
                this.mWidth = value;
                OnPropertyChanged("Width");
                if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
            }
        }

        private double height = 0;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                this.height = value;
                OnPropertyChanged("Height");
                if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
            }
        }

        private double x = 0;
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
                OnPropertyChanged("X");
                if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
            }
        }

        private double y = 0;
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
                OnPropertyChanged("Y");
                if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
            }
        }

        public Point TopLeft => new Point(this.X, this.Y);

        public Point TopRight => new Point(this.X + this.Width, this.Y);

        public Point BottomLeft => new Point(this.X, this.Y + this.Height);

        public Point BottomRight => new Point(this.X + this.Width, this.Y + this.Height);

        #endregion

        #region Methods

        /// <summary>
        /// Sets new selection with given values.
        /// </summary>
        /// <param name="X">X-position of selection.</param>
        /// <param name="Y">Y-position of selection.</param>
        /// <param name="Width">Width of selection.</param>
        /// <param name="Height">Height of selection.</param>
        public void Set(double X, double Y, double Width, double Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        #endregion

        #region Selection

        /// <summary>
        /// Initializes new instance of Selection.
        /// </summary>
        /// <param name="X">X-position of selection.</param>
        /// <param name="Y">Y-position of selection.</param>
        /// <param name="Width">Width of selection.</param>
        /// <param name="Height">Height of selection.</param>
        public Selection(double X, double Y, double Width, double Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        #endregion
    }
}
