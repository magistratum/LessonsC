using System;
using System.IO;
using System.Linq;


namespace Lesson4_HW
{
    class MyArray
    {
        private int[] arr;
        Random rnd = new Random();
        public MyArray(int n)
        {
            arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = rnd.Next(-10000, 10000);
        }
        public MyArray(int size, int init, int step)
        {
            arr = new int[size];
            arr[0] =  init;
            for (int i = 1; i < size; i++ )
                arr[i] = arr[i - 1] + step;
        }

        public MyArray(string filename)
        {
            if (!String.IsNullOrEmpty(filename) || File.Exists(filename))
            {
                string[] ss = File.ReadAllLines(filename);
                arr = new int[ss.Length];
                for (int i = 0; i < ss.Length; i++)
                    try
                    {
                        arr[i] = Convert.ToInt32(ss[i]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("\n {0}", e.Message);
                    }
            }
            else Console.WriteLine("Отсутствует файл с таким именем.");
        }
        public int CoupleCount()
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
                if ((arr[i - 1] % 3 == 0 && arr[i] % 3 != 0) || (arr[i - 1] % 3 != 0 && arr[i] % 3 == 0))
                    count++;
            return count;
        }
        public int Max
        {
            get
            {
                return arr.Max();
            }
        }
        public int this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
        public void Print()
        {
            foreach (int el in arr)
                Console.Write($" {el} ");
            Console.WriteLine();
        }
        public void Print( int[] vs)
        {
            foreach (int el in vs)
                Console.Write($" {el} ");
            Console.WriteLine();
        }
        public int Summ
        {
            get
            {
                return arr.Sum();
            }
        }
        public int MaxCount
        {
            get
            {
                int max = arr.Max();
                int count = arr.Aggregate(0, (total, next) => next == max ? total + 1 : total);
                return count;
            }
        }
        public int[] Inverse()
        {
            int[] arrinvers = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                arrinvers[i] = -arr[i];
            return arrinvers;
        }
        public void Multi( int multi)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] *= multi;
        }
    }
}
