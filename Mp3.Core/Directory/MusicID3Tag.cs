using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using TagLib;

namespace Mp3.Core
{
    ///<summary>
    ///class, get all tag mp3 information
    ///</summary>
    class MusicID3Tag
    {
        #region Fields

        public byte[] mTAGID = new byte[3];      //  3
        public byte[] mTitle = new byte[30];     //  30
        public byte[] mArtist = new byte[30];    //  30 
        public byte[] mAlbum = new byte[30];     //  30 
        public byte[] mYear = new byte[4];       //  4 
        public byte[] mComment = new byte[30];   //  30 
        public byte[] mGenre = new byte[1];

        #endregion
    }

    public static class Mp3Data
    {
        #region Public method

        public static PlayListitemControlViewModel GetData(string path)
        {
            if (path == string.Empty)
            {
                throw new ArgumentException("Path is empty!");
            }

            if (!path.EndsWith(".mp3", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ArgumentException("That shuld be mp3 File!");
            }

            using (var fs = System.IO.File.OpenRead(path))
            {
                PlayListitemControlViewModel item = null;

                if (fs.Length >= 128)
                {
                    var tag = new MusicID3Tag();
                    fs.Seek(-128, SeekOrigin.End);
                    fs.Read(tag.mTAGID, 0, tag.mTAGID.Length);
                    fs.Read(tag.mTitle, 0, tag.mTitle.Length);
                    fs.Read(tag.mArtist, 0, tag.mArtist.Length);
                    fs.Read(tag.mAlbum, 0, tag.mAlbum.Length);
                    fs.Read(tag.mYear, 0, tag.mYear.Length);
                    fs.Read(tag.mComment, 0, tag.mComment.Length);
                    fs.Read(tag.mGenre, 0, tag.mGenre.Length);

                    var f = TagLib.File.Create(path, TagLib.ReadStyle.Average);

                    item = new PlayListitemControlViewModel
                    {
                        Album = Encoding.Default.GetString(tag.mAlbum),
                        Band = Encoding.Default.GetString(tag.mArtist),
                        Title = Encoding.Default.GetString(tag.mTitle),
                        FilePath = path,
                        Dauration = f.Properties.Duration.TotalSeconds,
                        Cover = GetImageFromTag(path)
                    };
                }

                return item;
            }
        }

        private static BitmapImage GetImageFromTag(string fileName)
        {
            try
            {
                using (var file = TagLib.File.Create(fileName))
                {
                    var pictures = file.Tag.Pictures.FirstOrDefault();
                    if (pictures != null)
                    {
                        var bi = new BitmapImage();
                        bi.BeginInit();
                        bi.CreateOptions = BitmapCreateOptions.DelayCreation;
                        bi.CacheOption = BitmapCacheOption.OnDemand;
                        bi.StreamSource = new MemoryStream(pictures.Data.Data);
                        bi.EndInit();
                        bi.Freeze();
                        return bi;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to load cover from picture tag: {0}, {1}", fileName, e);
            }
            return null;
        }

        #endregion //Public method

        #region Private Method


        #endregion //Private Method


    }
}
