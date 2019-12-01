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
        public Host(int hk, int numOfUnits)//constructor
        {
            HostingUnitCollection = new List<HostingUnit>();
            for (int i = 0; i < numOfUnits; i++)
            {
                HostingUnitCollection.Add(new HostingUnit());
            }
            HostKey = hk;

        }
        public override string ToString()
        {
            string hostAsString = "";
            foreach (var item in HostingUnitCollection)
            {
                hostAsString += item + "\n";
            }
            return hostAsString;
        }
        public HostingUnit this[int index]//indexer
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
                // Set values at the specified index
            }
        }

        public bool AssignRequests(params GuestRequest[] requests)//Request allocation function for hosting units.
        {
            foreach (GuestRequest item in requests)
            {
                if (this.SubmitRequest(item) == -1)//If there is no available hosting unit at the host.
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHostAnnualBusyDays()//A function that returns the total number of nights in all the units that one host has.
        {
            int sumBusyDays = 0;
            foreach (HostingUnit item in HostingUnitCollection)
            {
                sumBusyDays += item.GetAnnualBusyDays();
            }
            
            return sumBusyDays;
        }

        public void SortUnits()//Sort all hosting units by occupancy.
        {
            HostingUnitCollection.Sort();
        }

        private long SubmitRequest(GuestRequest guestReq)
        {
            foreach (HostingUnit item in HostingUnitCollection)
            {
                if (item.ApproveRequest(guestReq))//If there is an hosting unit returns its key number.
                {
                    
                    guestReq.IsApproved = true;
                    
                    return (long)item.HostingUnitKey;
                }
            }
          
            guestReq.IsApproved = false;//If there is no available unit.
            return (long)-1;
        }

        public IEnumerator GetEnumerator()
        {
            return HostingUnitCollection.GetEnumerator();
        }
    }
}
