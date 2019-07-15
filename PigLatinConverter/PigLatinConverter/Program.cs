using System;
using System.Collections;
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

            //Display the converted sentence
            Console.WriteLine("\nTranslation to Pig Latin:\r");
            Console.WriteLine(sentence);
            Console.WriteLine("\nPress any key to EXIT.");
            Console.ReadKey();
        }

        //Translates sentence to Pig Latin
        static string PLConverter(string sentence)
        {
            StringBuilder PLSentence = new StringBuilder();
            StringBuilder word = new StringBuilder();
            bool wordBuilding = false;
 
            //Loop through the sentence
            foreach (char c in sentence)
            {
                if (!Char.IsLetter(c)) //If c is a space, comma, exclamation mark, number, etc
                {
                    if (wordBuilding) //Then we are at the end of a word
                    {
                        PLSentence.Append(ConvertWord(word.ToString())); //Add Pig Latin word to sentence
                        word.Clear(); //Reset
                        wordBuilding = false; //No longer building a word
                    }                    
                    PLSentence.Append(c); //Add the ' '
                }
                else
                {
                    word.Append(c); //Build the English word
                    wordBuilding = true; //We are building a word
                }
            }
            if (wordBuilding) PLSentence.Append(ConvertWord(word.ToString())); //Add the final word if it exists
            return PLSentence.ToString(); //Return the finished sentence
        }

        //Returns the Pig Latin translation of a word
        static string ConvertWord(string word)
        {
            StringBuilder PLWord = new StringBuilder();
            char[] cluster = new char[5]; //Longest word-initial cluster in English is 3 (ex: 'splashy') 
            bool buildingCluster = true;
            bool isCapital = false;

            //Check for capitalization so we can move it
            if (Char.IsUpper(word[0]))
            {
                isCapital = true;
            }

            //Loop through the word
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                if (buildingCluster) //Get the consonant cluster if it exists
                {
                    if (!IsVowel(c))
                    {
                        int j;
                        for (j = 0; j < cluster.Length - 2; j++)
                        {
                            if (i + j >= word.Length) //Error: word ended
                            {
                                //Make the word anyway before ending
                                foreach (char l in cluster) { if (l != '\0') PLWord.Append(l); } 
                                PLWord.Append("ay");
                                return PLWord.ToString();
                            }
                            else if (IsVowel(word[i + j])) //Break: we have the consonant cluster
                            {
                                break;
                            }
                            else //Build up cluster array
                            {
                                cluster[j] = word[i + j]; //Store start of consonant cluster
                            }
                        }
                        i += j - 1; //Update sentence index
                        cluster[j] = 'a';
                        cluster[j + 1] = 'y';
                    }
                    else
                    {
                        PLWord.Append(c); //Vowel, so we still add to word
                        cluster = new char[3] { 'w', 'a', 'y' }; //Word ends with 'way'
                    }
                    buildingCluster = false;
                }
                else //We have the consonant cluster if it exists
                {
                    if (isCapital)
                    {
                        isCapital = false;
                        PLWord.Append(Char.ToUpper(c)); //Capitalize first letter of word
                    }
                    else
                    {
                        PLWord.Append(c); //Continue building word
                    }
                }
            }
            foreach (char l in cluster) { if (l != '\0') PLWord.Append(Char.ToLower(l)); } //Add cluster to end of word
            return PLWord.ToString(); //Return the finished word
        }

        //Check if a char is a vowel
        static bool IsVowel(char c)
        {
            string vowels = "aeiou";
            if (vowels.Contains(Char.ToLower(c))) return true;
            else return false;
        }

    }
}
