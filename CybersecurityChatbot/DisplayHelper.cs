using System;
using System.Collections.Generic;
using System.Text;

namespace CybersecurityChatbot
{
    class DisplayHelper
    {
        public static void ShowAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗  ██████╗ ████████╗
 ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██╔═══██╗╚══██╔══╝
 ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝    ██████╔╝██║   ██║   ██║   
 ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗    ██╔══██╗██║   ██║   ██║  
 ╚██████╗   ██║   ██████╔╝███████╗██║  ██║    ██████╔╝╚██████╔╝   ██║   
  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝    ╚═╝  
        ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║       🛡️  Cybersecurity Awareness Assistant 🛡️        ║");
            Console.WriteLine("  ║         Keeping South African Citizens Safe          ║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ──────────────────────────────────────────────────────");
            Console.ResetColor();
        }

        public static void PrintBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("  🤖 Bot: ");
            Console.ResetColor();
            TypewriterEffect(message);
        }

        public static void PrintUserPrompt(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  👤 {name}: ");
            Console.ResetColor();
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ⚠️  {message}");
            Console.ResetColor();
        }

        // Simulates a typing effect — makes it feel conversational
        private static void TypewriterEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(18); // slight delay per character
            }
            Console.WriteLine();
        }
    }
}
