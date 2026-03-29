using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace CybersecurityChatbot
{
    public class AudioHelper
    {
      
       public void Play() 
        {
            try
            {

                SoundPlayer player = new SoundPlayer("path_to_audio_file.wav");
                player.Play();
            } catch (Exception ex)
            { 
            Console.WriteLine("Message could not be loaded"+ex.Message);
            }

        }
    }
}
