using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CybersecurityChatbot.GUI2
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer typingTimer = null!;
        private string typingBuffer = "";
        private Color typingColor;
        private int typingIndex = 0;
        private string userName = "";
        private bool nameCollected = false;
        private string lastTopic = "";
        private Dictionary<string, string> userMemory = new Dictionary<string, string>();
        private Random random = new Random();
        //cool typing effect inspired by ai
        private void TypeMessage(string message, Color color)
        {
            typingBuffer = message + "\n\n";
            typingColor = color;
            typingIndex = 0;

            // Disable input while typing
            txtInput.Enabled = false;
            button1.Enabled = false;

            typingTimer = new System.Windows.Forms.Timer();
            typingTimer.Interval = 18; // milliseconds per character
            typingTimer.Tick += TypingTimer_Tick;
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object? sender, EventArgs e)
        {
            if (typingIndex < typingBuffer.Length)
            {
                rtbChat.SelectionStart = rtbChat.TextLength;
                rtbChat.SelectionLength = 0;
                rtbChat.SelectionColor = typingColor;
                rtbChat.AppendText(typingBuffer[typingIndex].ToString());
                rtbChat.ScrollToCaret();
                typingIndex++;
            }
            else
            {
                typingTimer.Stop();
                typingTimer.Dispose();

                // Re-enable input when done
                txtInput.Enabled = true;
                button1.Enabled = true;
                txtInput.Focus();
            }
        }
        // Random response lists
        private List<string> phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information — scammers disguise themselves as trusted organisations.",
            "Always check the sender's actual email address, not just the display name.",
            "Never click links in unexpected emails — go directly to the website instead.",
            "Look for spelling mistakes and generic greetings like 'Dear Customer' — these are red flags.",
            "Legitimate companies will never ask for your password via email."
        };

        private List<string> passwordTips = new List<string>
        {
            "Use at least 12 characters mixing uppercase, lowercase, numbers and symbols.",
            "Never reuse the same password across multiple sites.",
            "Consider using a password manager like Bitwarden to generate and store strong passwords.",
            "Avoid using personal details like your name or birthdate in passwords.",
            "Enable two-factor authentication wherever possible for extra security."
        };

        private List<string> privacyTips = new List<string>
        {
            "Review the privacy settings on your social media accounts regularly.",
            "Be careful about what personal information you share online — once it's out there, it's hard to take back.",
            "Use a VPN when connecting to public Wi-Fi to protect your data.",
            "Check app permissions on your phone — many apps request more access than they need.",
            "Use encrypted messaging apps like Signal for sensitive conversations."
        };

        public Form1()
        {
            InitializeComponent();
            WireUpEvents();

            new CybersecurityChatbot.AudioHelper().Play();
            WelcomeUser();
        }

        private void WireUpEvents()
        {
            button1.Click += BtnSend_Click;
            txtInput.KeyDown += TxtInput_KeyDown;
        }

        private void WelcomeUser()
        {
            TypeMessage("🛡️ Bot: Welcome to the Cybersecurity Awareness Bot!", Color.Cyan);
            TypeMessage("🛡️ Bot: I'm here to help you stay safe online.", Color.Cyan);
            TypeMessage("🛡️ Bot: What is your name?", Color.Cyan);
        }

        private void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSend_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void BtnSend_Click(object? sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                AppendMessage("🛡️ Bot: Please type something first!", Color.Orange);
                return;
            }

            AppendMessage($"👤 You: {input}", Color.Yellow);
            txtInput.Clear();

            // Collect name first
            if (!nameCollected)
            {
                userName = input;
                nameCollected = true;
                userMemory["name"] = userName;
                AppendMessage($"🛡️ Bot: Great to meet you, {userName}! 😊", Color.Cyan);
                AppendMessage("🛡️ Bot: Type 'help' to see what I can assist you with.", Color.Cyan);
                return;
            }

            string response = GetResponse(input.ToLower().Trim());
            TypeMessage($"🛡️ Bot: {response}", Color.Cyan);
        }

        private string GetResponse(string input)
        {
            // Follow-up handling
            if (input.Contains("more") || input.Contains("another tip") || input.Contains("tell me more") || input.Contains("explain more"))
            {
                return GetFollowUp();
            }

            // Sentiment detection
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("anxious"))
            {
                string tip = phishingTips[random.Next(phishingTips.Count)];
                return $"It's completely understandable to feel that way — cyber threats are real. Here's something that might help: {tip}";
            }

            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
            {
                return $"I hear you, {userName} — cybersecurity can feel overwhelming. Let's take it one step at a time. Type 'help' to pick a topic.";
            }

            if (input.Contains("curious") || input.Contains("interested") || input.Contains("want to learn"))
            {
                return $"Love the enthusiasm, {userName}! Type 'help' to see all the topics I can teach you about.";
            }

            // Memory — interest recall
            if (input.Contains("privacy"))
            {
                userMemory["interest"] = "privacy";
                lastTopic = "privacy";
                string tip = privacyTips[random.Next(privacyTips.Count)];
                return $"Great topic! I'll remember that you're interested in privacy. Here's a tip: {tip}";
            }

            // Help menu
            if (input.Contains("help"))
            {
                return "Here's what I can help you with:\n" +
                       "• password — tips for strong passwords\n" +
                       "• phishing — how to spot scam emails\n" +
                       "• privacy — protecting your personal data\n" +
                       "• malware — staying virus free\n" +
                       "• scam — recognising online scams\n" +
                       "• safe browsing — staying safe online\n\n" +
                       "You can also say 'another tip' for more on the last topic!";
            }

            // Keywords
            if (input.Contains("password"))
            {
                lastTopic = "password";
                return passwordTips[random.Next(passwordTips.Count)];
            }

            if (input.Contains("phishing"))
            {
                lastTopic = "phishing";
                return phishingTips[random.Next(phishingTips.Count)];
            }

            if (input.Contains("scam"))
            {
                lastTopic = "phishing";
                return "Scammers often create urgency to pressure you into acting fast. Always slow down and verify before clicking anything or sharing personal details.";
            }

            if (input.Contains("malware") || input.Contains("virus"))
            {
                lastTopic = "malware";
                return "Never download software from untrusted sources, and keep your antivirus updated. Be cautious with email attachments even from known contacts.";
            }

            if (input.Contains("browsing") || input.Contains("browser") || input.Contains("internet"))
            {
                lastTopic = "browsing";
                return "Always check for HTTPS before entering personal info, and avoid using public Wi-Fi for banking or sensitive tasks.";
            }

            if (input.Contains("how are you"))
            {
                return "Running smoothly and keeping threats at bay! How can I help you stay safe today?";
            }

            if (input.Contains("purpose") || input.Contains("what can you do"))
            {
                return $"I'm your Cybersecurity Awareness Assistant, {userName}! I educate South African citizens on staying safe online. Type 'help' to get started.";
            }

            // Memory recall
            if (userMemory.ContainsKey("interest"))
            {
                return $"As someone interested in {userMemory["interest"]}, you might want to review your account security settings regularly. Type 'help' to explore more topics.";
            }

            // Default fallback
            return "I didn't quite understand that. Could you rephrase? Type 'help' to see what I can assist with.";
        }

        private string GetFollowUp()
        {
            return lastTopic switch
            {
                "password" => passwordTips[random.Next(passwordTips.Count)],
                "phishing" => phishingTips[random.Next(phishingTips.Count)],
                "privacy" => privacyTips[random.Next(privacyTips.Count)],
                "malware" => "Regularly back up your important files to an external drive or cloud storage in case of a ransomware attack.",
                "browsing" => "Keep your browser and extensions up to date — outdated software is a common entry point for attackers.",
                _ => "Could you remind me what topic you'd like more on? Type 'help' to see all available topics."
            };
        }

        private void AppendMessage(string message, Color color)
        {
            rtbChat.SelectionStart = rtbChat.TextLength;
            rtbChat.SelectionLength = 0;
            rtbChat.SelectionColor = color;
            rtbChat.AppendText(message + "\n\n");
            rtbChat.ScrollToCaret();
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}