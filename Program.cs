using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POEPART_01
{
    public class Program
    {
        static void Main(string[] args)
        {

            // creating an instance class for the audioPlay
            new audioPlay();
            // For the intro and welcome message with visual effects
            PrintGreeting();
            // creating an instance class for the ASCII logo
            new Logo();
            // The loop for the conversation
            ConversationLoop();
        }
        // First method which prints the greeting with visual effects
        static void PrintGreeting()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine( "Welcome to the Cybersecurity Awareness Bot"  );
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            TypewriterEffect("Hi, What is your name?");
            Console.WriteLine();

            // recording the user's name
            string userName = Console.ReadLine();
            Thread.Sleep(500); 
            Console.WriteLine();

            // uses name to greet back
            TypewriterEffect($"Hi {userName}, I'm here to assist you with any questions related to password safety, phishing, and safe browing. I'll try my best to assist you with helpful advice! Go head?");
            Thread.Sleep(500); // pause before the next line
            Console.WriteLine();

        }
        // effects to simulate conversation
        static void TypewriterEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                // adjusting delay to simulate typing speed
                Thread.Sleep(15);
            }
        }
        // the method for the conversationloop with the input validation and the basic response system
        static void ConversationLoop()
        {
            string userInput;
            do
            {
                // prompting the user for input
                Console.WriteLine("\n-------------------------------------------------");
                Console.WriteLine("     What would you like to know?"     );
                Console.WriteLine("    (Type 'exit' to end the conversation)"     );
                Console.WriteLine("---------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Your question: ");
                Console.ForegroundColor = ConsoleColor.White;
                userInput = Console.ReadLine()?.Trim();

                // If user types exit to end the conversation
                if (userInput?.ToLower() == "exit")
                {
                    ExitConversation();
                    break;
                }
                //process the user's questions
                ProcessUserInput(userInput);
                // repeat the loop untile the user press exit
            } while (true);
        }
        // method to process the users input and provide reponses based on the topic
        static void ProcessUserInput(string userInput)
        {
            string[] keywords = userInput.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            if (keywords == null || keywords.Length == 0)
            {
                DefaultResponse();
                return;
            }
            // checks if there are related keywords
            if (keywords.Contains("password") || keywords.Contains("safe") || keywords.Contains("strong"))
            {
                ProvidePasswordSafetyAdvice();
            }
            else if (keywords.Contains("phishing") || keywords.Contains("scam"))
            {
                ProvidePhishingAdvice();
            }
            else if (keywords.Contains("browsing") || keywords.Contains("safe"))
            {
                ProvideSafeBrowsingAdvice();
            }
            else
            {
                DefaultResponse();
            }

        }
        //provides adice for password safety
        static void ProvidePasswordSafetyAdvice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypewriterEffect("A strong password should be at least 12 characters long, use differnt kinds of letters, numbers, and symbols");
            Console.WriteLine();
            TypewriterEffect("Avoid using easily and weak guessable information such as your name, birthdate or common words.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
        // advice about phishing
        static void ProvidePhishingAdvice()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypewriterEffect("Be aware when receiving unrequested emails or infomation asking for personal information");
            Console.WriteLine();
            TypewriterEffect("Phishing attempts often involve a sense of urgency or enticing offers,such as prize or urgent account verification.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Provide advice on safe browsing
        static void ProvideSafeBrowsingAdvice()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypewriterEffect("To ensure safe browsing, always use safe websites with 'https' in the URL.");
            Console.WriteLine();
            TypewriterEffect("Avoid clicking on suspicious links or downloading attachments from unknwon sources.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        // default response if input is invalid
        static void DefaultResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypewriterEffect("I didn't quite understand that input. Could you please rephrase");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        // method to gracefuuly exit the conversation
        static void ExitConversation()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine(" Thank you for using the Cybersecurity Awareness Bot!");
            Console.WriteLine(" Be cautious, be aware online and protect your information");
            Console.WriteLine("--------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);



        }
    }
}
