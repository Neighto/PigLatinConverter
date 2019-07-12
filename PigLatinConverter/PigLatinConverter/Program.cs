using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************************************************
 * CONVERT USER SUBMITTED SENTENCE INTO PIG LATIN
 * **********************************************
 * 
 * RULES:
 * Move first consonant cluster of word to the end of
 * the word and add "ay". If the word starts with a 
 * vowel then we add "way" at the end of the word.
 * 
 *  - Written in C# with Visual Studio -
 */

namespace PigLatinConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable declaring
            string sentence;

            //Display information to user
            Console.WriteLine("---------------------------\r");
            Console.WriteLine("Console Pig Latin Converter\r");
            Console.WriteLine("---------------------------\n");
            Console.WriteLine("Write a sentence in English and it will be converted to Pig Latin.");
            Console.WriteLine("Press ENTER when done.");

            //Get sentence from user
            sentence = Console.ReadLine();

            //Convert sentence to Pig Latin
            sentence = PLConverter(sentence);




        }

        static string PLConverter(string sentence)
        {
            StringBuilder builder = new StringBuilder();
            string output;
            bool isNewWord = true;

            foreach (char c in sentence)
            {
                if (isNewWord) //Beginning of new word
                {
                    if (!IsVowel(c))
                    {

                    }
                }


                if (IsVowel(c))
                {
                    //once ' ' reached add 'way' to builder
                }


                if (c == ' ')
                {

                }
            }

            return output;
        }

        static bool IsVowel(char c)
        {
            string vowels = "aeiou";
            if (vowels.Contains(c)) return true;
            else return false;
        }
    }
}
