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
        public int HostingUnitKey { get { return stSerialKey; } }
        public void fillMatrix(bool[,] d)
        {
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    dairy[i, j] = false;
                }
            }
        }
        public HostingUnit()
        {
            dairy = new bool[12, 31];// Matrix of hotel capacity
            fillMatrix(dairy);
            stSerialKey++;
        }
        public int GetAnnualBusyDays()
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
            Console.WriteLine("The amount of taken days: ");
            return counter;
        }
        public float GetAnnualBusyPercentage()
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
            Console.WriteLine("The precentege of the yearly capacity: ");
            double precent = 0;
            precent = ((double)counter / 365) * (100);
            Console.WriteLine((float)precent);
            return (float)precent;
        }
        interface Icomparable
        {
            int compareTo(HostingUnit h);
        }
        int compareTo(HostingUnit h)
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
        public override string ToString()
        {
            Console.WriteLine();
            Console.WriteLine("This is your serialkey number: ");
            Console.WriteLine(stSerialKey);
            Console.WriteLine();
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
        public bool ApproveRequest(GuestRequest guestReq)
        {
            int amount = 0;
            int newAmount = 0;
            int sumAmount = 0;
            int newMonth = 0;
            if (guestReq.isApproved)
            {
                int day = guestReq.entryDate.Day - 1;
                int month = guestReq.entryDate.Month - 1;
                if (guestReq.ReleasDate.Day - day < 1)
                {
                    amount = 31 - day;
                    newAmount = day;
                    sumAmount = amount + newAmount;
                    newMonth++;
                }
                for (int i = 0; i < amount; i++)
                {
                    dairy[month, day + i] = true;
                }
                for (int i = 1; i < newAmount + 1; i++)
                {
                    dairy[newMonth, i] = true;
                }
                day = guestReq.entryDate.Day + 1;
                month = guestReq.entryDate.Month + 1;
                Console.WriteLine();
                Console.WriteLine("We have set your vecaition, looking forward to seeing you!");
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Sorry, the days you have requested are already occoupide.");
                return false;
            }
        }
        public int  CompareTo(object obj)
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

