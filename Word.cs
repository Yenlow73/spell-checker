using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SpellChecker
{
    class Word : IComparable<Word>
    {
        public string spelling;
        static char current;
        // Construct a word with spelling.
        public Word(string spelling)
        {
            this.spelling = spelling;
        }
        // Read the next word from in_doc, copying any preceding punctuation to
        // out_doc. Return null if there is no next word to be read.
        public static Word get_word(StreamReader in_doc, StreamWriter out_doc)
        {
            Regex regex = new Regex(@"\w");
            Word new_word = new Word(string.Empty);
            
           
            current = (char)in_doc.Read();  

            while (!regex.IsMatch(current.ToString()) && !in_doc.EndOfStream)
            {
                //Console.WriteLine("current = " + current);
                out_doc.Write(current);    
                current = (char)in_doc.Read();                                 
            }       

            while (regex.IsMatch(current.ToString()))
            {     
                new_word.spelling += current;    

                if(regex.IsMatch(((char)in_doc.Peek()).ToString()))  
                {
                    current = (char)in_doc.Read();  
                }
                else break;                                              
            }    

            //Console.WriteLine("current = " + current);

            return new_word.spelling == string.Empty ? null : new_word;
        }
        // Write wd to out_doc.
        public static void put_word(StreamWriter out_doc, Word word)
        {
            out_doc.Write(word.spelling);
        }

        public static bool IsNumeric(Word word)
        {
            return Regex.IsMatch(word.spelling, @"^\d+$");
        }

        public int CompareTo(Word word)
        {       
            if (word == null)
            {
                return 1;  
            }
            else 
            {
                return this.spelling.CompareTo(word.spelling);
            }
        }
    }
}
