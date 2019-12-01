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
        public void FillMatrix(bool[,] d)//Filing the dairy with false valuse
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
            // Console.WriteLine();
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
           
            return counter;
        }

        public float GetAnnualBusyPercentage()//A function that returns the percentage of annual occupancy.
        {
            Console.WriteLine();
            int counter = GetAnnualBusyDays();
            double precent = ((double)counter / 365) * (100); 
            return (float)precent;
        }

        interface Icomparable //compares units by amount of busy days;
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
            string hostingUnitAsString = "";
            hostingUnitAsString += "This is your serialkey number: \n";
            hostingUnitAsString += this.HostingUnitKey + "\n";
            hostingUnitAsString += "Busy days: " + GetAnnualBusyDays() + "\n";
            
            hostingUnitAsString += "\n";
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (dairy[i, j])//It will enter this if if the matrix has true on this day and month
                    {
                        hostingUnitAsString += $"Stay days: {i + 1}-{j + 1} --> ";
                        while (dairy[i, j])//As long as we still have true, have the days ++.
                        {
                            if (j == 30 && i != 12)
                            {
                                i++;
                                j = 0;
                            }
                            j++;
                        }
                        hostingUnitAsString += $"{i + 1}-{j + 1}\n";
                    }
                }
            }
            return hostingUnitAsString;//Returning the string with all the hosts information
        }

        public bool ApproveRequest(GuestRequest guestReq)//A function that accepts a hosting request and checks whether it is accepted or not
                                                         //If the request is approved, it changes those days to occupancy.
        {
            // check if request is allowed
            DateTime temp = guestReq.EntryDate;
            while (temp < guestReq.ReleasDate)
            {
                if (this.dairy[temp.Month - 1, temp.Day - 1])
                {
                    return false;
                }
                temp = temp.AddDays(1);
            }

            // update the dairy with the new request
            temp = guestReq.EntryDate;
            while (temp < guestReq.ReleasDate)
            {
                this.dairy[temp.Month - 1, temp.Day - 1] = true;
                temp = temp.AddDays(1);
            }

            return true;
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




