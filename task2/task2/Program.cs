using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] capacity;
            capacity = new bool[12, 31];// Matrix of hotel capacity
            for (int i = 0; i < 12; i++)//This for fills the array with false values
            {
                for (int j = 1; j < 31; j++)
                {
                    capacity[i, j] = false;
                }
            }

            GuestRequest gr=new GuestRequest();
            Console.WriteLine(gr.entryDate);
            Console.WriteLine(gr.ReleasDate);
            gr.approvedFunc(capacity);
        }
    }
}
