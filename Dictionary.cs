using System;
using System.IO;

namespace SpellChecker
{
    /// Each Dictionary object is a set of words that can be loaded and saved.
    class Dictionary : Word_Set
    {
        public StreamReader sr;
        public StreamWriter sw;
        /// Construct an empty dictionary.
        public Dictionary() : base()
        {
            
        }
        /// Load this dictionary from filestream
        public void load(Stream filestream)
        {
            try
            {
                /*
                    Create an instance of StreamReader to read from a file.
                    The using statement also closes the StreamReader.
                */
                using (sr = new StreamReader(filestream))
                {
                    string line;
                    
                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);
                        base.add(new Word(line));
                    }
                }
            }
            catch (IOException e)
            {                
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        
        /// Save this dictionary to filestream.
        public void save(Stream filestream)
        {
            sw = new StreamWriter(filestream);
        }
        
    }
}