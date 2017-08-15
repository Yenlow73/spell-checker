using System;
using System.IO;

namespace SpellChecker
{
    class SpellChecker
    {
        static Dictionary main_dict;
        static Dictionary ignored;
        /* 
            Ask the user what to do with current_word, which is unknown.
            If the user chooses to accept the word, make it a member of main_dict.
            If the user chooses to ignore the word, make it a member of ignored.
            If the user chooses to replace the word, get the user to enter a replacement word,
            and update current_word.
        */
        static void consult_user(Word current_word, Dictionary main_dict, Dictionary ignored) 
        {

        }
        /* 
            Copy all words and punctuation from the input document to the output document,
            but ask the user what to do with any words that are unknown (i.e., not in
            main_dict or ignored).
        */
        static void process_document(Dictionary main_dict, Dictionary ignored) 
        {        
            Word current_word = new Word("");
            StreamReader in_doc = new StreamReader(new FileStream("apolo11.txt", FileMode.Open, FileAccess.Read));
            StreamWriter out_doc = new StreamWriter(new FileStream("apolo11c.txt", FileMode.Create, FileAccess.Write));
            
            while(current_word != null)
            {
                current_word = Word.get_word(in_doc, out_doc);

                if (!main_dict.contains(current_word) && !ignored.contains(current_word))
                {
                    consult_user(current_word, main_dict, ignored);
                }
                
                Word.put_word(out_doc, current_word);
            } 

        }
        static void Main(string[] args)
        {          
            main_dict = new Dictionary();
            ignored = new Dictionary();

            using(FileStream fileStreamRead = new FileStream(args[0], FileMode.Open, FileAccess.Read))
            {
                main_dict.load(fileStreamRead);                
            }
            
            process_document(main_dict, ignored);

            /* 
            using(FileStream fileStreamWrite = new FileStream(args[1], FileMode.Create, FileAccess.Write))
            {
                main_dict.load(fileStreamWrite);                
            }
            */
        }
    }
}
