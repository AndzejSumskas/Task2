using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {         
            bool programIsActive = true;
            while (programIsActive)
            {
                Console.Clear();
                MainMenuSelectPropose();
                int caseSwitch = Convert.ToInt32(Console.ReadLine());
                switch (caseSwitch)
                {
                    case 1:
                        ReadAllContacts();
                        break;
                    case 2:
                        AddNewContact();
                        break;
                    case 3:
                        MakeSearch();
                        break;
                    case 4:
                        programIsActive = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect entry.");
                        break;
                }
            }
        }

        public static void MainMenuSelectPropose()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - view the whole list of contacts");
            Console.WriteLine("2 - add new contact");
            Console.WriteLine("3 - perform a search");
            Console.WriteLine("4 - close the program");
        }

        public static void ReadAllContacts()
        {
            string textFromCsv = System.IO.File.ReadAllText(@"C:\Users\Andzej\Desktop\IT Tasks\HomeWork\Task2\test.csv");

            char[] separators = new char[] { ',','\n'};

            string[] wordsArray = textFromCsv.Split(separators, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < wordsArray.Length; i++)
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($" {wordsArray[i]} ");
            }
            Console.WriteLine("\n");
            Console.WriteLine(" Press key to continue...");
            Console.ReadKey();
        }

        public static void AddNewContact()
        {
            bool isActive = true;
            StringBuilder csvContent = new StringBuilder();

            while (isActive)
            {
                Console.Clear();
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the last name.");
                string surName = Console.ReadLine();

                Console.Write("Enter phone number\n +370");
                long telephonNumber = Convert.ToInt32(Console.ReadLine());
                while (telephonNumber.ToString().Length != 8)
                {
                    Console.WriteLine("Incorrect entry.");
                    Console.Write("Enter phone number\n +370");
                    telephonNumber = Convert.ToInt32(Console.ReadLine());
                }
                csvContent.AppendLine($"{name},{surName},+370{telephonNumber}");

                bool returnToMenuOrAddNewContact = true;

                while(returnToMenuOrAddNewContact)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1 - add new contact");
                    Console.WriteLine("2 - return to main menu");

                    string oneMoreContact = Console.ReadLine();
                    switch (oneMoreContact)
                    {
                        case "1":
                            returnToMenuOrAddNewContact = false;
                            break;
                        case "2":
                            returnToMenuOrAddNewContact = false;
                            isActive = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect entry.");
                            break;
                    }
                }
                  
            }

            string csvPath = @"C:\Users\Andzej\Desktop\IT Tasks\HomeWork\Task2\test.csv";

            File.AppendAllText(csvPath, csvContent.ToString());
        }

        public static void MakeSearch()
        {
            string textFromCsv = System.IO.File.ReadAllText(@"C:\Users\Andzej\Desktop\IT Tasks\HomeWork\Task2\test.csv");

            char[] separators = new char[] {'\n'};
            char[] separators2 = new char[] { ',' };

            string[] wordsArray = textFromCsv.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] tempWordsArray;
            Console.WriteLine("Enter the required text");
            string requiredText = Console.ReadLine();

            for (int k = 0; k < wordsArray.Length; k++)
               
            {
                char[] charLine = wordsArray[k].ToCharArray();
                char[] charRequiredText = requiredText.ToCharArray();

                for (int i = 0; i < charLine.Length; i++)
                {
                    int charMatch = 0;
                    if(charLine[i].ToString().ToLower() == charRequiredText[0].ToString().ToLower())
                    {
                        charMatch++;
                        for (int j = 1; j < charRequiredText.Length; j++)
                        {
                            if(charLine[j+i].ToString().ToLower() == charRequiredText[j].ToString().ToLower())
                            {
                                charMatch++;                               
                            }
                            if (charMatch * 10 > charRequiredText.Length * 7)
                            {
                                tempWordsArray = wordsArray[k].Split(separators2, StringSplitOptions.RemoveEmptyEntries);

                                foreach (var word in tempWordsArray)
                                {
                                    Console.Write($" {word} ");
                                }
                                k++;
                                Console.WriteLine();
                                
                            }                           
                        }                     
                    }
                }    
            }
            Console.WriteLine("\n");
            Console.WriteLine(" Press key to continue...");
            Console.ReadKey();
        }
    }
    
}
