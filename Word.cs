using System;
using System.IO;

namespace SpellChecker
{
    class Word
    {
        string spelling;
        // Construct a word with spelling.
        public Word(string spelling)
        {
            this.spelling = spelling;
        }
        // Read the next word from in_doc, copying any preceding punctuation to
        // out_doc. Return nonzero if there is no next word to be read.
        public static Word get_word(StreamReader in_doc, StreamWriter out_doc)
        {
            Word new_word = new Word("");
            while (in_doc.Peek() >= 0)
            {
                char c = (char)in_doc.Read();
                if (c.Equals(' ') || c.Equals('\t') || c.Equals('\n') || c.Equals('\r'))
                {
                    break;
                }
                else
                {
                    new_word.spelling += c;
                }                    
            }
            return new_word.spelling.Length == 0 ? null : new_word;
        }
        // Write wd to out_doc.
        public static void put_word(StreamWriter out_doc, Word wd)
        {
            out_doc.WriteLine(wd);
        }
    }
}
