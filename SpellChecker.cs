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
            Console.WriteLine("Word not found = " + current_word.spelling);
            Console.WriteLine("1 - Accept 2 - Ignore 3 - Replace");
            Console.WriteLine("Enter choice:");

            string input = Console.ReadLine();
            int number;

            while(!Int32.TryParse(input, out number))
            {
                Console.WriteLine("Please enter a valid number:");
                input = Console.ReadLine();
            }

            switch(number)
            {
                case 1:
                    main_dict.add(current_word);
                    break;
                case 2:
                    ignored.add(current_word);
                    break;
                case 3:
                    Console.WriteLine("Enter a new word:");
                    current_word.spelling = Console.ReadLine();
                    break;
                default:
                    break;
            }

        }
        /* 
            Copy all words and punctuation from the input document to the output document,
            but ask the user what to do with any words that are unknown (i.e., not in
            main_dict or ignored).
        */
        static void process_document(Dictionary main_dict, Dictionary ignored) 
        {        
            Word current_word = new Word("");
            string document = "apolo11.txt";
            string document2 = "apolo11c.txt";
            StreamReader in_doc = new StreamReader(new FileStream(document, FileMode.Open, FileAccess.Read));
            StreamWriter out_doc = new StreamWriter(new FileStream(document2, FileMode.Create, FileAccess.Write));                     


            while(current_word != null)
            {
                current_word = Word.get_word(in_doc, out_doc);               

                if(current_word != null)
                {

                    if(!main_dict.contains(current_word) && !ignored.contains(current_word) &&
                        !Word.IsNumeric(current_word))
                    {
                        consult_user(current_word, main_dict, ignored);
                    }

                    Word.put_word(out_doc, current_word);
                    //Console.WriteLine(current_word.spelling);
                }                
            } 

            in_doc.Dispose();
            out_doc.Dispose();
        }
        static void Main(string[] args)
        {          
            main_dict = new Dictionary();
            ignored = new Dictionary();

            using(FileStream fileStreamRead = new FileStream("main-dict.txt", FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine("Loading dictionary...");
                main_dict.load(fileStreamRead);                 
            }

                process_document(main_dict, ignored);

            using(FileStream fileStreamWrite = new FileStream("main-dict.txt", FileMode.Create, FileAccess.Write))
            {
                Console.WriteLine("Saving dictionary...");
                main_dict.save(fileStreamWrite);    
            }
            Console.WriteLine("Done.");
        }
    }
}
