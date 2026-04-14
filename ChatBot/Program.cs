using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;
using System.Threading;

namespace ChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = "User";
            }

            PlayVoiceGreeting();

            TypeText($"\nHello {name}! Welcome to the Cybersecurity Awareness Bot.");

            StartChat();
        }

        static void PlayVoiceGreeting()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chatbot.wav");
            if (!File.Exists(path))
            {
                Console.WriteLine($"(Voice greeting file missing at: {path})");
                return;
            }

            try
            {
                using (var player = new SoundPlayer(path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio error: " + ex.Message);
            }
        }

        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("=======================================");
            Console.WriteLine("       CYBERSECURITY CHATBOT           ");
            Console.WriteLine("=======================================\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("         [=======]                     "); 
            Console.WriteLine("        /  O   O  \\                    ");
            Console.WriteLine("       |     ^     |                    ");
            Console.WriteLine("       |    '-'    |                    ");
            Console.WriteLine("        \\  \\___/  /                    ");
            Console.WriteLine("         `-------`                      "); 
            Console.WriteLine("=======================================\n");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your digital safety helper!\n");
            Console.ResetColor();
        }

        static void StartChat()
        {
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n I have a menu ready for you !");
                Console.WriteLine("\n You can type : \n 1.phishing\n 2 password \n 3.links \n 4.purpose \n 5 how are you\n 6.what can I ask? \n 7.exit\n 8.record");
                Console.ResetColor();

                string input = Console.ReadLine();
                if (input == null) input = "";

                input = input.ToLower();

                if (input.Contains("how are you"))
                {
                    TypeText("Bot: I'm running smoothly and ready to help 😄");
                }

                else if (input.Contains("1") || input.Contains("phishing"))
                {
                    TypeText("Bot: Phishing is when attackers trick you into giving personal info through fake emails.");
                }
                else if (input.Contains("2") || input.Contains("password"))
                {
                    TypeText("Bot: Use strong passwords with uppercase, lowercase, numbers, and symbols.");
                }
                else if (input.Contains("3") || input.Contains("links"))
                {
                    TypeText("Bot: Always check URLs before clicking. Avoid suspicious links.");
                }
                else if (input.Contains("4") || input.Contains("purpose"))
                {
                    TypeText("Bot: My purpose is to educate you about cybersecurity.");
                }
                else if (input.Contains("5") || input.Contains("how are you"))
                {
                    TypeText("Bot: I'm running smoothly and ready to help 😄");
                }
                else if (input.Contains("6") || input.Contains("what can i ask"))
                {
                    TypeText("Bot: You can ask me about phishing, passwords, and safe browsing.");
                }
                else if (input.Contains("7") || input.Contains("exit"))
                {
                    TypeText("Bot: Stay safe online! Goodbye and BE ALERT!!");
                    running = false;
                }
                else if (input.Contains("8") || input.Contains("record"))
                {
                    TypeText("Bot: Recording started... (simulated)");
                    Thread.Sleep(1000);
                    TypeText("Bot: Recording saved successfully!");
                }
            }
        }

        static void TypeText(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(45);
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}