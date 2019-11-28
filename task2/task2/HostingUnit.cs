using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class HostingUnit : IComparable
    {
        private static int stSerialKey = 10000000;
        public bool[,] dairy;
        public int HostingUnitKey { get; private set; }
        public void FillMatrix(bool[,] d)//Filing the dairy with fals valuse
        {
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    dairy[i, j] = false;
                }
            }
        }

        public HostingUnit()//Constructor.
        {
            dairy = new bool[12, 31];// Matrix of hotel capacity.
            FillMatrix(dairy);
            HostingUnitKey = stSerialKey;
            stSerialKey++;
        }

        public int GetAnnualBusyDays()// Function who returns the total number of busy days per year.
        {
            Console.WriteLine();
            int counter = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (dairy[i, j])
                    {
                        counter++;// The counter will count how many days are taken.
                    }
                }
            }
            //Console.WriteLine("The amount of taken days: ");
            ///Console.WriteLine(counter);
           // Console.WriteLine();
            return counter;
        }

        public float GetAnnualBusyPercentage()//A function that returns the percentage of annual occupancy.
        {
            Console.WriteLine();
            int counter = 0;
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (dairy[i, j])
                    {
                        counter++;// The counter will count how many days are taken.
                    }
                }
            }
            //Console.WriteLine("The precentege of the yearly capacity: ");
            double precent = 0;
            precent = ((double)counter / 365) * (100);
            Console.WriteLine((float)precent);
            return (float)precent;
        }

        interface Icomparable
        {
            int compareTo(HostingUnit h);
        }

        int compareTo(HostingUnit h)//Comparison of hosting units by total occupied days per year.
        {
            if (this.GetAnnualBusyDays() > h.GetAnnualBusyDays())
            {
                return 1;
            }
            if (this.GetAnnualBusyDays() < h.GetAnnualBusyDays())
            {
                return -1;
            }
            if (this.GetAnnualBusyDays() == h.GetAnnualBusyDays())
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()//A function that displays for the unit its serial number and list of periods in which it is occupied.
        {
            // Console.WriteLine();
            // Console.WriteLine("This is your serialkey number: ");
            //Console.WriteLine(stSerialKey);
            // Console.WriteLine();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (dairy[i, j])//It will enter this if if the matrix has true on this day and month
                    {
                        Console.WriteLine("First day of stay: ");
                        Console.WriteLine("Month: ");
                        Console.WriteLine(++i);//We  do ++ because we did -- at the begining,do to the matrix starting from 0
                        Console.WriteLine("Day: ");
                        Console.WriteLine(++j);// Same as ++i.
                        Console.WriteLine("Last day of stay: ");
                        --i; --j;
                        while (dairy[i, j])//As long as we still have true, have the days ++.
                        {
                            if (j == 30 && i != 12)
                            {
                                i++;
                                j = 1;
                            }
                            j++;
                        }
                        Console.WriteLine("Month: ");
                        Console.WriteLine(++i);
                        Console.WriteLine("Day: ");
                        Console.WriteLine(j);
                        --j;
                        --i;
                    }
                }
            }
            string str = "Have a nice day!";
            return str;
        }

        public bool ApproveRequest(GuestRequest guestReq)//A function that accepts a hosting request and checks whether it is accepted or not
            //If the request is approved, it changes those days to occupancy.
        {
            int amount = 0;
            int newAmount = 0;
            int sumAmount = 0;
            int day = guestReq.EntryDate.Day - 1;
            int month = guestReq.EntryDate.Month - 1;
            if (guestReq.ReleasDate.Day - day < 1)
            {
                amount = 31 - day;
                newAmount = day;
                sumAmount = amount + newAmount;
            }
            bool available = false;
            if (!dairy[month, day])// If the room ia availeble we will enter the for.
            {
                for (int i = 0; i < amount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (dairy[month, day + i])
                    {
                        // Console.WriteLine("Sorry, the request has been denighd.");
                        return false;
                    }
                }
            }
            else
            {
                // Console.WriteLine("Sorry, the request has been denighd.");
                return false;
            }
            int month2 = 0;
            bool available2 = false;
            if (available)
            {
                for (int i = 0; i < newAmount - 1; i++)//We will check that we have the room availeble for the whole amount that the costumer requested. Amount-1 is because if the last day is taken it is dose not matter.
                {
                    if (dairy[month2, day + i])
                    {
                        //Console.WriteLine("Sorry, the request has been denighd.");
                        return false;
                    }
                }
            }
            if (!(available && available2))// This is where we update the capacity.
            {
                for (int i = 0; i < amount; i++)
                {
                    dairy[month, i] = true;
                }
                if (month2 != 0)
                {
                    for (int i = 0; i < newAmount; i++)
                    {
                        dairy[month2, i] = true;

                    }
                }
                // Console.WriteLine("The request has been answerred");
                return true;
            }
            day = guestReq.EntryDate.Day + 1;
            month = guestReq.EntryDate.Month + 1;
            return false;
        }

        public int CompareTo(object obj)//Comparison of accommodation units by total occupied days per year.
        {
            HostingUnit hu = (HostingUnit)obj;
            if (this.GetAnnualBusyDays() > hu.GetAnnualBusyDays())
            {
                return 1;
            }
            else if (this.GetAnnualBusyDays() == hu.GetAnnualBusyDays())
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}




