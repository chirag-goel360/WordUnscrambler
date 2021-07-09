using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnScrambler.Data_Files;
using WordUnScrambler.Helpers;

namespace WordUnScrambler
{
    class Program
    {
        private const string wordListFileName = "words.txt";
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        static void Main(string[] args)
        {
            try
            {
                bool continueScrambling = true;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the Option for Scrambled Words:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("F for File M for Manual");
                    var option = Console.ReadLine() ?? string.Empty;
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.Write("Enter full path including the File Name: ");
                            ExecuteFileScrambling();
                            break;
                        case "M":
                            Console.Write("Enter scrambled words Manually (separated by comma if multiple): ");
                            ExecuteManualScrambling();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("The Option was not Recognized.\n");
                            break;
                    }
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Would you want like to Continue? Y/N");
                        continueDecision = Console.ReadLine() ?? string.Empty;
                    } while (!continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));
                    continueScrambling = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);
                } while (continueScrambling);
            }
            catch (Exception ex)
            {
                Console.WriteLine("The Program will terminated because of " + ex.Message);
            }
        }

        private static void ExecuteManualScrambling()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayWords(scrambledWords);
        }

        private static void ExecuteFileScrambling()
        {
            try
            {
                var fileName = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(fileName);
                DisplayWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        private static void DisplayWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("No matches have been Found...");
            }
        }
    }
}
