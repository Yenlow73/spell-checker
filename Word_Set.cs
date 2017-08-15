using System;
using System.Collections.Generic;

namespace SpellChecker
{
    class Word_Set
    {
        List<Word> words;
        /// Construct an empty set of words.
        public Word_Set()
        {
            words = new List<Word>();
        }
        /// Make wd a member of this set of words.
        public void add(Word wd)
        {
            words.Add(wd);
        }
        /// Return true if and only if wd is a member of this set of words.
        public bool contains(Word wd)
        {
            return words.Contains(wd);
        }    
    }
}