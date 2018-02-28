using Mp3.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Interaction logic for SongItemHost.xaml
    /// </summary>
    public partial class SongItemHost : UserControl
    {
        #region dependency property
        public BaseControl CurrentSong
        {
            get { return (BaseControl)GetValue(CurrentSongProperty); }
            set { SetValue(CurrentSongProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentSong.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentSongProperty =
            DependencyProperty.Register("CurrentSong", typeof(BaseControl), typeof(SongItemHost), new PropertyMetadata(new PropertyChangedCallback(CurrentsongPropertyChanged)));

        //trzeba zrobic refactoryzacje calej metody!!!
        private static async void CurrentsongPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pageOne = (d as SongItemHost).ContentOne;

            var pageTwo = (d as SongItemHost).ContentTwo;

            var pageThree = (d as SongItemHost).ContentThree;

            if (IoC.Get<ApplicationViewModel>().SlideFromRightToLeft)
            {
                if (pageThree.Content is BaseControl)
                {
                    var content = (BaseControl)pageThree.Content;
                    await content.Animation(ControlAnimation.ToFourthPosition);
                    //wate until the animation end and then clen up
                    await Task.Delay((int)(content.SlideSecont * 200));
                    Application.Current.Dispatcher.Invoke(() => pageThree.Content = null);
                }

                if (pageTwo.Content is BaseControl)
                {
                    var content = (BaseControl)pageTwo.Content;
                    await content.Animation(ControlAnimation.ToThirdPosition);
                    Application.Current.Dispatcher.Invoke(() => pageThree.Content = content);
                }
                if (pageOne.Content is BaseControl)
                {
                    var content = (BaseControl)pageOne.Content;
                    await content.Animation(ControlAnimation.ToSecondPosition);
                    Application.Current.Dispatcher.Invoke(() => pageTwo.Content = content);
                }
                pageOne.Content = e.NewValue;
           }
            else
            {
                if (pageOne.Content is BaseControl)
                {
                    var content = (BaseControl)pageOne.Content;
                    await content.Animation(ControlAnimation.ToZeroPosition);
                    //wate until the animation end and clean up
                    await Task.Delay((int)(content.SlideSecont * 200));
                    Application.Current.Dispatcher.Invoke(() => pageOne.Content = null);

                }
                if (pageTwo.Content is BaseControl)
                {
                    var content = (BaseControl)pageTwo.Content;
                    await content.Animation(ControlAnimation.ToFirstPosition);
                    Application.Current.Dispatcher.Invoke(() => pageOne.Content = content);
                }
                if (pageThree.Content is BaseControl)
                {
                    var content = (BaseControl)pageThree.Content;
                    await content.Animation(ControlAnimation.ToSecondPosition);
                    Application.Current.Dispatcher.Invoke(() => pageTwo.Content = content);
                }
                if (e.NewValue is BaseControl)
                {
                    var content = (BaseControl)e.NewValue;
                    content.AnimationStatus = ControlAnimation.ToThirdPosition;
                    pageThree.Content = content;
                }
                else
                    pageThree.Content = e.NewValue;
            }

            if (IoC.Get<ApplicationViewModel>().IsFirstLoad)
            {
                //wate until the first animation end
                await Task.Delay(600); // <= 400 = ((BaseControl)e.NewValue)._slideSecont * 1000 plus 200ms 

                IoC.Get<ApplicationViewModel>().SetNextSong();

                await Task.Delay(600);

                if (pageThree.Content is BaseControl)
                {
                    var content = (BaseControl)pageThree.Content;
                    await content.Animation(ControlAnimation.ToFourthPosition);
                    //wate until the animation end and then clen up
                    await Task.Delay((int)(content.SlideSecont * 100));
                    Application.Current.Dispatcher.Invoke(() => pageThree.Content = null);
                }

            }
        }

        #endregion

        #region Constructor

        public SongItemHost()
        {
            InitializeComponent();
        }

        #endregion
    }
}
