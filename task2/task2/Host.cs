using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Host
    {
        public int HostKey;
        public List<HostingUnit> HostingUnitCollection { get; set; }

        public Host(int hk, List<HostingUnit> l)
        {
            HostingUnitCollection = l;
            HostKey = hk;
            foreach (HostingUnit item in HostingUnitCollection)
            {
                item.fillMatrix(item.dairy);

            }


        }
        public HostingUnit this[int index]
        {
            get
            {
                foreach (var item in HostingUnitCollection)
                {
                    if (index== item.HostingUnitKey)
                    { return item; }
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
            Console.WriteLine();
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
                    Console.WriteLine();
                    Console.WriteLine("This is your hotel units key: ");
                    return (long)item.HostingUnitKey;

                }


            }
            Console.WriteLine();
            Console.WriteLine("We are sorry to inform you that no hosting units are available on the days you requested.");
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
    }


}
