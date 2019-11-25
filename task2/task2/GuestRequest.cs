using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class GuestRequest
    {
        public DateTime entryDate { get ; set; }
        public DateTime ReleasDate { get; set; }
        public bool isApproved { get; set; }
        public GuestRequest(bool flagEntryDate)
        {
            Random rand = new Random (DateTime.Now.Millisecond);
            int randBeginMonth = rand.Next(1, 12);
            int randBeginDay = rand.Next(1, 31);
            string beginDate = (string)(randBeginDay + "-" + randBeginDay);
            entryDate = DateTime.Parse(beginDate);
            int amountOfDays = rand.Next(2, 10);
            int day= entryDate.Day + amountOfDays;
            int month = entryDate.Month;
            if(entryDate.Day + amountOfDays>31)
            {
                month++;
                day = entryDate.Day + amountOfDays - 31;
            }
            string leaveDate = (string)(day + "-" + month);
            ReleasDate = DateTime.Parse(leaveDate);
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
        public void approvedFunc(bool[,] cap)
        {
            int amount = 0;
            int newAmount = 0;
            int sumAmount = 0;
            int day= entryDate.Day-1;
            int month = entryDate.Month - 1;
            if (ReleasDate.Day- day<1)
            {
                amount = 31 - day;
                newAmount = day;
                sumAmount = amount + newAmount;
            }
            bool available = false;
            if (!cap[month, day])// If the room ia availeble we will enter the for.
            {
                for (int i = 0; i < amount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (cap[month, day + i])
                    {
                        Console.WriteLine("Sorry, the request has been denighd.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, the request has been denighd.");
            }
            int month2 = 0;
            bool available2 = false;
            if (available)
            {
                for (int i = 0; i < newAmount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (cap[month2, day + i])
                    {
                        Console.WriteLine("Sorry, the request has been denighd.");
                    }
                }
            }
          
            if (!(available && available2))// This is where we update the capacity.
            {
                Console.WriteLine("The request has been answerred");
            }
             day = entryDate.Day + 1;
             month = entryDate.Month + 1;
        }
    }
}

