using System;
using CybersecurityChatbot;
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
      
        AudioHelper playgreet = new AudioHelper();
        playgreet.Play();
        CybersecurityChatbot.DisplayHelper.ShowAsciiLogo();
        Chatbot bot = new Chatbot();
        bot.Start();


    }
}

