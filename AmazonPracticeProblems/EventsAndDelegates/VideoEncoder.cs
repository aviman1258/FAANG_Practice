using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        // 1- Define a delegate (agreement between publisher and subscriber
        // 2- Define an event based on that delegate;
        // 3- Raise the event

        /*

        //Declare delagate that holds reference to function that has the following signature
        //The function has to be void and has 2 parameters

        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        //Define Event based on that delegate
        public event VideoEncodedEventHandler VideoEncoded;

        */

        //EventHandler
        //EventHandler<TEventArgs>

        public event EventHandler<VideoEventArgs> VideoEncoded;

        internal void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            //Notifies subscribers
            OnVideoEncoded(video);
        }

        //We need to raise that event
        //In .net the convention is your event handler must be
        //protected, virtual, and void
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video});
        }
    }
}
