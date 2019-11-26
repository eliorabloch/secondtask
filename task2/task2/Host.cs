using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Host : IEnumerable
    {
        public int HostKey;
        public List<HostingUnit> HostingUnitCollection { get; set; }
        public Host() { HostingUnitCollection = new List<HostingUnit>(); }
        public Host(int hk, int numOfUnits)
        {
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
            HostKey = hk;

        }
        public HostingUnit this[int index]
        {
            get
            {
                for (int i = 0; i < HostingUnitCollection.Count; i++)
                {
                    if (index == i)
                    {
                        return HostingUnitCollection[i];
                    }
                }

                return null;
            }
            set
            {
                // set values at the specified index
            }
        }
        public bool AssignRequests(params GuestRequest[] requests)
        {
            foreach (GuestRequest item in requests)
            {
                if (this.SubmitRequest(item) == -1)
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHostAnnualBusyDays()
        {
            int sum = 0;
            foreach (HostingUnit item in HostingUnitCollection)
            {
                sum += item.GetAnnualBusyDays();
            }
           // Console.WriteLine();
            Console.WriteLine("This is the amount of occupide days in all the hotel units.");
            return sum;
        }
        public void SortUnits()
        {
            HostingUnitCollection.Sort();
        }
        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit item in HostingUnitCollection)
            {
                if (item.ApproveRequest(guestReq))
                {
                   // Console.WriteLine();
                    //  Console.WriteLine("This is your hotel units key: ");
                    guestReq.isApproved = true;
                    // Console.WriteLine(item.HostingUnitKey);
                   // Console.WriteLine();
                    return (long)item.HostingUnitKey;
                }
            }
            Console.WriteLine();
            // Console.WriteLine("We are sorry to inform you that no hosting units are available on the days you requested.");
            guestReq.isApproved = false;
            return (long)-1;
        }
        public string toString(List<HostingUnit> L)
        {
            foreach (HostingUnit item in L)
            {
                item.ToString();
            }
            string str = "Bye";
            return str;
        }

        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }

       
    }



}
