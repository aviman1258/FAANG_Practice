using System;

namespace EventsAndDelegates
{
    public class MailService
    {
        
        //Making an event handler that conforms to the delegate signature
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email..." + e.Video.Title);
        }
    }
}
