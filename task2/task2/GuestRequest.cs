using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class GuestRequest
    {
        public DateTime entryDate { get; set; }
        public DateTime ReleasDate { get; set; }
        public bool isApproved  { get; set;  }
        public GuestRequest(bool flagEntryDate)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            string leaveDate = getRandomDateString();
            DateTime dateOut;
            while (!DateTime.TryParse(leaveDate, out dateOut))
            {
                leaveDate = getRandomDateString();
            }
            entryDate = dateOut;
            ReleasDate = entryDate.AddDays(rand.Next(2, 10));
        }

        private string getRandomDateString()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int randBeginMonth = rand.Next(1, 12);
            int randBeginDay = rand.Next(1, 31);
            
            string leaveDate = (string)(randBeginDay + "-" + randBeginMonth);
            return leaveDate;
        }

        public GuestRequest()
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
                    entryDate = DateTime.Parse(date);
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
            

        
    
  
       
