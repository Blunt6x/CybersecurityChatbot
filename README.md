
# 📸 CI Workflow

![CI Status](https://github.com/Blunt6x/CybersecurityChatbot/blob/master/.github/workflows/dotnet-desktop.yml/badge.svg)

⚠️ **Note:** The CI workflow encountered a GitHub account-level billing 
> lock during setup. This is a known GitHub issue affecting some free accounts 
> on public repositories despite no paid features being used. GitHub Support 
> has been contacted to resolve this. The `dotnet-desktop.yml` workflow file is correctly 
> configured in `.github/workflows/` and is visible in the Actions tab.

 🛡️ Cybersecurity Awareness Chatbot

A command-line chatbot application built in C# that educates South African 
citizens on cybersecurity awareness and online safety practices.

---

## 📋 Project Overview

This chatbot was developed as Part 1 of a Portfolio of Evidence (POE) for the 
Department of Cybersecurity's public awareness campaign. It simulates real-life 
scenarios where users might encounter cyber threats and provides practical 
guidance on staying safe online.

---

## ✨ Features

- 🔊 **Voice Greeting** — plays a WAV audio welcome message on launch
- 🎨 **ASCII Art Logo** — displays a cybersecurity-themed header
- 👤 **Personalised Interaction** — asks for your name and uses it throughout
- 💬 **Cybersecurity Responses** — covers:
  - Password safety
  - Phishing awareness
  - Safe browsing
  - Malware protection
  - Social engineering
- ⚠️ **Input Validation** — handles empty or unrecognised inputs gracefully
- 🎨 **Colour-Coded Console UI** — structured interface with typewriter effect

---

## 🏗️ Project Structure
```
CybersecurityChatbot/
├── Program.cs          → Entry point
├── Chatbot.cs          → Core chat logic and responses
├── DisplayHelper.cs    → ASCII art, colours, UI formatting
├── AudioHelper.cs      → WAV greeting playback
└── Resources/
    └── greeting.wav    → Voice greeting audio file
```

---

## 🚀 How to Run

1. Clone the repository:
```
   git clone <your-repo-url>
```
2. Open the solution in Visual Studio
3. Ensure `greeting.wav` is in the `Resources` folder
4. Press **F5** to run

---

dotnet-desktop.yml
## 🎥 Video Presentation
IN CONSTRUCTION!!!

---

## 👤 Author

Lungile Sibanda
Student Number: St10476414  
The Independent Institute of Education  
