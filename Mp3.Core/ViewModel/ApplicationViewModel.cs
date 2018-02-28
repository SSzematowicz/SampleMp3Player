using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mp3.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        private ControlAnimation m_animation;

        public PlayListViewModel PlaingList { get; set; } = new PlayListViewModel();

        /// <summary>
        /// this item use to corect animate
        /// </summary>
        public PlayListitemControlViewModel Song { get; set; }

        public int mIndex = 0;

        /// <summary>
        /// contein information that the songs first load ist
        /// </summary>
        public bool IsFirstLoad { get; set; }

        /// <summary>
        /// Contein information that the newsongexplorermenu sHuld be visable
        /// </summary>
        public bool NewSongMenuVisable { get; set; } = false;


        /// <summary>
        /// Set the Direction of the song item control animation
        /// When false slide from right to left
        /// when true from left to right
        /// </summary>
        public bool SlideFromRightToLeft { get; set; }

        public ControlAnimation Animation
        {
            get => m_animation;
            set
            {
                m_animation = value;
                OnPropertyChanged("Animation");
            }
        }

        /// <summary>
        /// Property can set or get new ViewModel for ListView
        /// </summary>
        public DirectoryItemInofoViewModel ListViewViewModel { get; set; } = new DirectoryItemInofoViewModel
        {
            Children = new System.Collections.ObjectModel.ObservableCollection<DirectoryItemInofoViewModel>
            {
                new DirectoryItemInofoViewModel
                {
                     FullPath = "AA",
                     Type = DirectoryType.Drive
                },
                new DirectoryItemInofoViewModel
                {
                     FullPath = "AA",
                     Type = DirectoryType.Drive
                },
                new DirectoryItemInofoViewModel
                {
                     FullPath = "AA",
                     Type = DirectoryType.Drive
                },
            }
        };

        #region Constructor

        public ApplicationViewModel()
        {

            Animation = ControlAnimation.ToFirstPosition;

            SlideFromRightToLeft = true;

            IsFirstLoad = true;

        }

        #endregion

        public void ChangeAnimation(ControlAnimation animation) => Animation = animation;

        public void RessetAll()
        {
            Animation = ControlAnimation.ToFirstPosition;

            SlideFromRightToLeft = true;

            IsFirstLoad = true;

            mIndex = 0;

            Song = PlaingList.Items[mIndex];

            NewSongMenuVisable = false;
        }

        #region Song changes
        public void SetNextSong()
        {
            if (PlaingList.Items == null)
                return;

            SlideFromRightToLeft = true;

            IsFirstLoad = false;

            if (mIndex < PlaingList.Items.Count - 1)
            {
                mIndex++;
                Song = PlaingList.Items[mIndex];
            }
            else if (mIndex < PlaingList.Items.Count)
            {
                Song = null;
                mIndex++;
            }
        }

        public void SetPrevSong()
        {
            if (PlaingList.Items == null)
            {
                return;
            }

            SlideFromRightToLeft = false;

            if (mIndex >= 3)
            {
                mIndex--;
                Song = PlaingList.Items[mIndex - 2];

            }

            else if (mIndex == 2)
            {
                Song = null;
                mIndex--;
            }

        }
        #endregion
    }
}