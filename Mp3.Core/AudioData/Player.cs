using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mp3.Core
{
    ///<summary>
    ///Class for all song playing functionalitys
    ///</summary>
    public static class Player
    {

        #region Fields

        static IWavePlayer WavePlayer;
        static AudioFileReader AudioFileReader;
        static Action<float> ChangeVolume;

        #endregion

        #region Public Method
        public static AudioFileReader Play()
        {
            if (WavePlayer != null)
            {
                if (WavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    return null;
                }
                else if (WavePlayer.PlaybackState ==
                    PlaybackState.Paused ||
                    WavePlayer.PlaybackState == PlaybackState.Stopped)
                {
                    WavePlayer.Play();
                    return AudioFileReader;
                }
            }
            return null;
        }

        public static void DisposeMp3()
        {
            if (WavePlayer != null)
            {
                WavePlayer.Stop();
            }
            if (AudioFileReader != null)
            {
                AudioFileReader.Dispose();
                ChangeVolume = null;
                AudioFileReader = null;
            }
            if (WavePlayer != null)
            {
                WavePlayer.Dispose();
                WavePlayer = null;
            }
        }

        public static void Pause()
        {
            if (WavePlayer != null)
            {
                if (WavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    WavePlayer.Pause();
                }
            }
        }

        public static void Stop()
        {
            if (WavePlayer != null)
            {
                WavePlayer.Stop();
                AudioFileReader.Position = 0;
            }
        }

        public static void CreateWavePlayer(string FileName)
        {
            DisposeMp3();
            WavePlayer = CreateWavePlayer();
            WavePlayer.Init(CreateInput(FileName));
        } 

        public static void SetVolume(float volume)
        {
            if(ChangeVolume != null)
            {
                ChangeVolume(volume);
            }
        }

        public static bool IsStoped() => WavePlayer.PlaybackState == PlaybackState.Stopped;


        #endregion

        #region Private Helper
        private static IWavePlayer CreateWavePlayer()
        {
            var callbackInfo = WaveCallbackInfo.FunctionCallback();
            var outputDevice = new WaveOut(callbackInfo);
            return outputDevice;
        }

        static ISampleProvider CreateInput(string FileName)
        {
            AudioFileReader = new AudioFileReader(FileName);
            var sampleChanel = new SampleChannel(AudioFileReader, true);

            ChangeVolume = vol => sampleChanel.Volume = vol;

            var postVolumeMeter = new MeteringSampleProvider(sampleChanel);

            return postVolumeMeter;
        } 
        #endregion
    }

}
