using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class GuestRequest
    {
        public DateTime EntryDate { get; set; }
        public DateTime ReleasDate { get; set; }
        public bool IsApproved { get; set; }
        public GuestRequest(bool flagEntryDate)//Constractor for a random guest.
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string leaveDate = getRandomDateString();
            DateTime dateOut;
            while (!DateTime.TryParse(leaveDate, out dateOut))//Try to turn the string into a daytime parameter.
            {
                leaveDate = getRandomDateString();//If the date doesnt exist, we get a new random date.
            }
            EntryDate = dateOut;
            ReleasDate = EntryDate.AddDays(rand.Next(2, 10));//Add days,and gives us the release date.
        }

        private string getRandomDateString()//Funcion that creates the random guest request.
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int randBeginMonth = rand.Next(1, 12);//Random month.
            int randBeginDay = rand.Next(1, 31);//Random day.
            string leaveDate = (string)(randBeginDay + "-" + randBeginMonth);
            return leaveDate;//Returns the string with the new random date.
        }

        public GuestRequest()//Regular constractor.
        {
            bool success = false;
            bool success2 = false;
            while (!success)
            {
                Console.WriteLine("please enter the date you want to reserve.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                try
                {
                    string date = Console.ReadLine();
                    EntryDate = DateTime.Parse(date);
                    success = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" sorry, invalid input, please try again. ");
                    Console.ResetColor();
                    success = false;

                }
            }
            while (!success2)
            {
                Console.WriteLine("please enter the date you want to leave.");
                Console.WriteLine("the format must be yyyy-mm-dd");
                try
                {
                    string date = Console.ReadLine();
                    ReleasDate = DateTime.Parse(date);
                    success2 = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" sorry, invalid input, please try again. ");
                    Console.ResetColor();
                    success2 = false;

                }
            }
        }
    }
}






