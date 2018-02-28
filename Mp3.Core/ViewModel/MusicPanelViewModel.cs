using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using NAudio.Wave;

namespace Mp3.Core
{
    public class MusicPanelViewModel : BaseViewModel
    {
        #region Fields
        const double SliderMax = 10;

        public double mSlidePosition;
        /// <summary>
        /// help to sett current time
        /// </summary>
        AudioFileReader mReader;

        private DispatcherTimer mTimer = new DispatcherTimer();

        public string CurrentTime { get; set; } = "00:00:00";

        /// <summary>
        /// get the information about thath how long is the song 
        /// </summary>
        public double Dauration { get; private set; }

        /// <summary>
        /// current plaing list
        /// </summary>
        public PlayListViewModel CurrentSongs { get; set; } = new PlayListViewModel();

        /// <summary>
        /// the number of current plaing song
        /// </summary>
        public int Index { get; set; } = 0;

        public float mVolume = 1;

        private bool m_menuVisable;

        private PlayListPopupMenuViewModel m_attachmentMenu;

        #endregion

        #region Public Property

        /// <summary>
        /// Get or set the plaing progres slider 
        /// </summary>
        public double SlidePosition
        {
            get => mSlidePosition;
            set
            {
                mSlidePosition = value;
                if (mReader != null)
                {
                    var pos = (long)(mReader.Length * mSlidePosition / SliderMax);
                    mReader.Position = pos;
                }
            }
        }
        /// <summary>
        /// If song pley then ture else false;
        /// </summary>
        public bool IsPlaing { get; set; } = false;

        public PlayListPopupMenuViewModel AttachmentMenu
        {
            get => m_attachmentMenu;
            set
            {
                m_attachmentMenu = value;
                OnPropertyChanged("AttachmentMenu");
            }
        }


        public bool MenuVisable
        {
            get => m_menuVisable;
            set
            {
                m_menuVisable = value;
                OnPropertyChanged("MenuVisable");

            }
        }

        public float Volume
        {
            get => mVolume * (float)SliderMax;
            set
            {
                if (value != mVolume)
                {
                    mVolume = value / (float)SliderMax;
                    Player.SetVolume(mVolume);
                }
            }
        }

        #endregion

        #region Commands

        public ICommand NextSongCommand { get; set; }
        public ICommand PrevSongCommand { get; set; }
        public ICommand AttachmentButtoncommand { get; set; }
        public ICommand PopupMenuAwayCommand { get; internal set; }
        public ICommand PlaySongCommand { get; internal set; }
        public ICommand StopSongCommadn { get; internal set; }
        public ICommand AddNewSongCommand { get; internal set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constuctor
        /// </summary>
        public MusicPanelViewModel()
        {
            IoC.Get<ApplicationViewModel>().PlaingList.PropertyChanged -= PlaingList_PropertyChanged;
            IoC.Get<ApplicationViewModel>().PlaingList.PropertyChanged += PlaingList_PropertyChanged;
            //Commands
            NextSongCommand = new ReleyCommand(async () => await NextSongAsync());
            PrevSongCommand = new ReleyCommand(async () => await PrevSongAsync());
            AttachmentButtoncommand = new ReleyCommand(AttachmentButton);
            PopupMenuAwayCommand = new ReleyCommand(PopupMenuAway);
            PlaySongCommand = new ReleyCommand(PlaySong);
            StopSongCommadn = new ReleyCommand(StopSong);
            AddNewSongCommand = new ReleyCommand(AddNewwSong);

            mTimer.Interval = TimeSpan.FromMilliseconds(500);
            mTimer.Tick += TimerOnTickAsync;
            AttachmentMenu = new PlayListPopupMenuViewModel();
        }
        #endregion

        #region Events
        private async void TimerOnTickAsync(object sender, EventArgs e)
        {
            if (mReader != null)
            {
                var currentTime = Player.IsStoped() ? TimeSpan.Zero : mReader.CurrentTime;
                mSlidePosition = Math.Min(SliderMax, Player.IsStoped() ? 0 : mReader.Position * SliderMax / mReader.Length);
                CurrentTime = string.Format("{0:00}:{1:00}:{2:00}", (int)currentTime.TotalHours,
                    (int)currentTime.TotalMinutes, (int)currentTime.Seconds);

                //if current song is end play next song or stop playing
                if(mSlidePosition == 10)
                {
                    if (Index < CurrentSongs.Items.Count - 1)
                    {
                        await NextSongAsync();
                    }
                    else
                    {
                        StopSong();
                    }
                }
                OnPropertyChanged(nameof(SlidePosition));
                OnPropertyChanged(nameof(CurrentTime));    

            }
        }
        /// <summary>
        /// /fired when reloded song list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaingList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CurrentSongs = IoC.Get<ApplicationViewModel>().PlaingList;
            Index = 0;
            RelodedSong();
            Play();
        }
        #endregion

        #region Commands Method
        /// <summary>
        /// Open File Explorer in the bootm of the window
        /// </summary>
        private void AddNewwSong() => IoC.Get<ApplicationViewModel>().NewSongMenuVisable ^= true;

        /// <summary>
        /// Stop plaing the song
        /// </summary>
        private void StopSong()
        {
            IsPlaing = false;
            Player.Stop();
            mReader.Position = 0;
        }

        /// <summary>
        /// start plaing the song and change the play button
        /// </summary>
        private void PlaySong()
        {
            if (CanNotPlay())
                return;

            IsPlaing ^= true;

            Play();
        }

        /// <summary>
        /// Start plaing the song
        /// </summary>
        private void Play()
        {
            if (CanNotPlay())
                return;

            if (IsPlaing)
            {
                mReader = Player.Play();

                mTimer.Start();
            }
            else
            {
                Player.Pause();
                mTimer.Stop();
            }
        }

        /// <summary>
        /// Check that can play a song
        /// </summary>
        /// <returns></returns>
        private bool CanNotPlay() => CurrentSongs.Items == null || CurrentSongs.Items.Count == 0;


        private void PopupMenuAway() => MenuVisable = false;

        private void AttachmentButton() => MenuVisable ^= true;

        /// <summary>
        /// Set the Previous Song
        /// </summary>
        /// <returns></returns>
        private async Task PrevSongAsync()
        {
            if (Index <= 0)
                return;

            await Task.Run(() =>
            {
                IoC.Get<ApplicationViewModel>().SetPrevSong();
            });

            Index--;

            RelodedSong();

            if (IsPlaing)
                Play();

            await Task.Delay(1);


        }

        /// <summary>
        /// Set The next Song
        /// </summary>
        /// <returns></returns>
        private async Task NextSongAsync()
        {
            if (CanNotPlay() ||
                    Index >= CurrentSongs.Items.Count - 1)
                return;

            await Task.Run(() =>
            {
                IoC.Get<ApplicationViewModel>().SetNextSong();
            });
             
            Index++;
            RelodedSong();

            if (IsPlaing)
                Play();
            PopupMenuAway();




            //await Task.Delay(1);

        }

        private void RelodedSong()
        {
            Player.DisposeMp3();
            Dauration = CurrentSongs.Items[Index].Dauration;
            Player.CreateWavePlayer(CurrentSongs.Items[Index].FilePath);
            Player.SetVolume(mVolume);
        }

        #endregion
    }
}
