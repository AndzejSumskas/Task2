using System;
using System.IO;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            StringBuilder csvContent = new StringBuilder();
            //csvContent.AppendLine("Name,Age,TelNumber");

            while (isActive)
            {
                Console.WriteLine("Iveskite varda.");
                string name = Console.ReadLine();

                Console.WriteLine("Iveskite pavarde.");
                string surName = Console.ReadLine();

                Console.Write("Iveskite Telefono numeri.\n +370");
                int telephonNumber = Convert.ToInt32(Console.ReadLine());
                while(telephonNumber.ToString().Length != 8)
                {
                    Console.WriteLine("Klaidingas ivedimas");
                    Console.Write("Iveskite Telefono numeri.\n +370");
                    telephonNumber = Convert.ToInt32(Console.ReadLine());
                }
                csvContent.AppendLine($"{name},{surName},+370{telephonNumber}");
                Console.WriteLine("Ar norite prideti dar viena kontakta? N");
                string oneMoreContact = Console.ReadLine();               
                if(oneMoreContact == "N")
                {
                    isActive = false;
                }         
            }
 
            string csvPath = @"C:\Users\Andzej\Desktop\IT Tasks\HomeWork\Task2\test.czv";

            File.AppendAllText(csvPath, csvContent.ToString());
        }
    }
}
