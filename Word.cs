using System;
using System.IO;

namespace SpellChecker
{
    class Word
    {
        string word;
        // Construct a word with spelling.
        public Word(string spelling)
        {
            word = spelling;
        }
        // Read the next word from in_doc, copying any preceding punctuation to
        // out_doc. Return nonzero if there is no next word to be read.
        public static Word get_word(StreamReader in_doc, StreamWriter out_doc, Word wd)
        {
            in_doc.Read();
            return wd;
        }
        // Write wd to out_doc.
        public static void put_word(StreamWriter out_doc, Word wd)
        {
            out_doc.WriteLine(wd);
        }
    }
}
