using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearYourself
{
    public class HearCode
    {
        private bool open = false;
        private WaveInEvent waveIn;
        private WaveOutEvent waveOut;

        public HearCode()
        {
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(0).Channels);
            waveOut = new WaveOutEvent();
            waveIn.DataAvailable += (sender, e) =>
            {
                byte[] buffer = new byte[e.BytesRecorded];
                Buffer.BlockCopy(e.Buffer, 0, buffer, 0, e.BytesRecorded);
                if (!waveOut.PlaybackState.Equals(PlaybackState.Playing))
                {
                    waveOut.Init(new WaveInProvider(waveIn));
                    waveOut.Play();
                }
            };
        }

        public void Switch()
        {
            if (open)
            {
                waveIn.StopRecording();
                waveOut.Stop();
            }
            else
            {
                waveIn.StartRecording();
            }
            open = !open;
        }

        public bool GetStatus()
        {
            return open;
        }
    }
}
