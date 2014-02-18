using System;
using System.Threading;
using System.Threading.Tasks;

namespace FindSmallest
{
    class Program
    {

        private static readonly int[][] Data = new int[][]{new int[]{1,5,4,2}, 
            new int[]{3,2,4,11,4},
            new int[] {33,2,3,-1, 10},
            new int[] {3,2,8,9,-1},
            new int[] {22,1,9,-3, -3}
        };

        private static int FindSmallest(int[] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("There must be at least one element in the array");
            }

            int smallestSoFar = numbers[0];
            foreach (int number in numbers)
            {
                if (number < smallestSoFar)
                {
                    smallestSoFar = number;
                }
            }
            //Console.WriteLine(String.Join(", ", numbers) + ": " + smallestSoFar);
            return smallestSoFar;

        }

        //private static int findLargest(int[] comparison, Comparison<int> comparison)
        //{
        //    int findLargestSoFar = comparison;
        //    foreach (int number in numbers )
        //    {
        //        if (number > findLargestSoFar)
        //        {
        //            findLargestSoFar = number;
        //        }
        //    }
        
        //}

        static void Main(string[] args)
        {
            //int smallest = 0;
            foreach (int[] data in Data)
            {
                //int smallest = FindSmallest(data);

                Task<int> task = new Task<int>(() => FindSmallest(data));
                task.Start();
                Console.WriteLine(String.Join(", ", data) + "; " + task.Result);

                //Task.Factory.StartNew(() => FindSmallest(data));


                //Thread t1 = new Thread(() => smallest = FindSmallest(data));
                //t1.Start();
                //Console.ReadLine();
              
                
            }
        }

        public static System.Collections.Generic.IEnumerable<int> numbers { get; set; }
    }
}