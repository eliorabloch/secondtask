﻿using System;
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
            // Console.WriteLine();
            //Console.WriteLine("This is the amount of occupide days in all the hotel units:");
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
                    // Console.WriteLine();
                    //  Console.WriteLine("This is your hotel units key: ");
                    guestReq.IsApproved = true;
                    // Console.WriteLine(item.HostingUnitKey);
                    // Console.WriteLine();
                    return (long)item.HostingUnitKey;
                }
            }
            Console.WriteLine();
            // Console.WriteLine("We are sorry to inform you that no hosting units are available on the days you requested.");
            guestReq.IsApproved = false;//If there is no available unit.
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
