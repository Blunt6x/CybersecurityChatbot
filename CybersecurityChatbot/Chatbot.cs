using System;
using System.Collections.Generic;
using System.Text;

namespace CybersecurityChatbot
{
    class Chatbot
    {
        private string userName;

        public void Start()
        {
            GetUserName();
            DisplayHelper.PrintDivider();
            DisplayHelper.PrintBotMessage($"Nice to meet you, {userName}! I'm here to help you stay safe online.");
            DisplayHelper.PrintBotMessage("Type 'help' to see what I can help you with, or 'exit' to quit.");
            DisplayHelper.PrintDivider();

            RunConversationLoop();
        }

        private void GetUserName()
        {
            DisplayHelper.PrintBotMessage("Before we begin, what's your name?");
            Console.Write("  👤 You: ");
            userName = Console.ReadLine();

            // Input validation — same idea as a while loop in Java
            while (string.IsNullOrWhiteSpace(userName))
            {
                DisplayHelper.PrintWarning("I didn't catch that. Please enter your name.");
                Console.Write("  👤 You: ");
                userName = Console.ReadLine();
            }

            userName = userName.Trim();
        }

        private void RunConversationLoop()
        {
            bool running = true;

            while (running)
            {
                DisplayHelper.PrintUserPrompt(userName);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayHelper.PrintWarning("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                string response = GetResponse(input.ToLower().Trim());

                if (response == "EXIT")
                {
                    DisplayHelper.PrintBotMessage($"Stay safe online, {userName}! Goodbye! 🛡️");
                    running = false;
                }
                else
                {
                    DisplayHelper.PrintBotMessage(response);
                }

                DisplayHelper.PrintDivider();
            }
        }

        private string GetResponse(string input)
        {
            // Exit
            if (input == "exit" || input == "quit" || input == "bye")
                return "EXIT";

            // Help menu
            if (input.Contains("help"))
                return "You can ask me about:\n" +
                       "  • passwords\n" +
                       "  • phishing\n" +
                       "  • safe browsing\n" +
                       "  • malware\n" +
                       "  • social engineering";

            // How are you
            if (input.Contains("how are you"))
                return "I'm running smoothly and keeping threats at bay! How can I help you today?";

            // Purpose
            if (input.Contains("purpose") || input.Contains("what can you do") || input.Contains("what do you do"))
                return "I'm your Cybersecurity Awareness Assistant! I educate South African citizens " +
                       "on staying safe online — from spotting phishing emails to creating strong passwords.";

            // Passwords
            if (input.Contains("password"))
                return "🔐 Password Tips:\n" +
                       "  • Use at least 12 characters\n" +
                       "  • Mix uppercase, lowercase, numbers and symbols\n" +
                       "  • Never reuse passwords across sites\n" +
                       "  • Consider using a password manager like Bitwarden";

            // Phishing
            if (input.Contains("phishing"))
                return "🎣 Phishing Awareness:\n" +
                       "  • Be suspicious of urgent emails asking for personal info\n" +
                       "  • Check the sender's actual email address carefully\n" +
                       "  • Never click links in unexpected emails — go directly to the website\n" +
                       "  • Look for spelling mistakes and generic greetings like 'Dear Customer'";

            // Safe browsing
            if (input.Contains("browsing") || input.Contains("browse") || input.Contains("internet"))
                return "🌐 Safe Browsing Tips:\n" +
                       "  • Always check for HTTPS before entering personal info\n" +
                       "  • Avoid using public Wi-Fi for banking\n" +
                       "  • Keep your browser and extensions up to date\n" +
                       "  • Use a reputable ad blocker to avoid malicious ads";

            // Malware
            if (input.Contains("malware") || input.Contains("virus"))
                return "🦠 Malware Protection:\n" +
                       "  • Install reputable antivirus software and keep it updated\n" +
                       "  • Don't download software from untrusted sources\n" +
                       "  • Be cautious with email attachments, even from known contacts\n" +
                       "  • Regularly back up your important files";

            // Social engineering
            if (input.Contains("social engineering"))
                return "🎭 Social Engineering:\n" +
                       "  • Attackers manipulate people rather than systems\n" +
                       "  • Be cautious of anyone urgently requesting sensitive info\n" +
                       "  • Verify identities before sharing anything — even with 'IT support'\n" +
                       "  • When in doubt, hang up and call back on an official number";

            // Default fallback
            return "I didn't quite understand that. Could you rephrase? Type 'help' to see what I can assist with.";
        }
    }
}
