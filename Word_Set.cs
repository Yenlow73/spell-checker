using System;
using System.Collections.Generic;
using System.Linq;

namespace SpellChecker
{
    class Word_Set
    {
        public List<Word> words;
        /// Construct an empty set of words.
        public Word_Set()
        {
            words = new List<Word>();
        }
        /// Make wd a member of this set of words.
        public void add(Word wd)
        {
            wd.spelling = wd.spelling.ToLower();
            words.Add(wd);
        }
        /// Return true if and only if wd is a member of this set of words.
        public bool contains(Word wd)
        {
            return words.Find(word => (word.spelling == wd.spelling.ToLower())) != null;
        }    
    }
}