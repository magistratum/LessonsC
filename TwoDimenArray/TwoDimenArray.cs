using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Configuration;

namespace LibArray
{
    public class TwoDimenArray
    {
        private int[,] arr;
        Random rnd = new Random();
        public TwoDimenArray(int n, int m)
        {
            arr = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    arr[i, j] = rnd.Next(-10000, 10000);
        }
        public int this[int i, int j]
        {
            get { return arr[i, j]; }
            set { arr[i, j] = value; }
        }
        public TwoDimenArray(string filename)
        {
            if (!String.IsNullOrEmpty(filename) && File.Exists(filename))
            {
                string[] separators = { " " };
                string[] datafile = File.ReadAllLines(filename);
                string[][] arrstring = new string[datafile.Length][];
                int countempty = 0;
                int maxarr = 0;
                for (int i = 0; i < datafile.Length; i++)
                {
                    if (!string.IsNullOrEmpty(datafile[i]))
                    {
                        arrstring[i] = datafile[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        if (arrstring[i].Length > maxarr) maxarr = arrstring[i].Length;
                    }
                    else
                        countempty++;
                }
                arr = new int[datafile.Length-countempty,maxarr];
                
                for (int i = 0; i < arr.GetLength(0); i++)
                    for (int j = 0; j < arrstring[i].Length; j++)
                    {
                        if (IsDigit(arrstring[i][j]))
                            arr[i, j] = Convert.ToInt32(arrstring[i][j]);
                        else
                            arr[i, j] = 0;
                    }
            }
            else Console.WriteLine("Отсутствует файл с таким именем.");
        }
        public int Max
        {
            get
            {
                int max = int.MinValue;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] > max)
                            max = arr[i, j];
                    }
                }
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = int.MaxValue;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (arr[i, j] < min)
                            min = arr[i, j];
                    }
                }
                return min;
            }
        }
        public int Sum()
        {
            int Sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Sum += arr[i, j];
                }
            }
            return Sum;
        }
        public int Sum(int n)
        {
            int Sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > n)
                        Sum += arr[i, j];
                }
            }
            return Sum;
        }
        public int NumberMax(ref int n, ref int m)
        {
            int max = int.MinValue;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        n = i;
                        m = j;
                    }
                }
            }
            return max;
        }
        public void Print()
        {
            for ( int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"#{i+1} - ");
                for ( int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($" {arr[i, j]}");
                }
                Console.WriteLine();
            }
        }

        public static bool IsDigit(string str)
        {
            bool yes = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str, i) || str[i] == '-')
                    yes = true;
                else
                {
                    yes = false;
                    break;
                }
            }
            return yes;
        }
        public void WriteArray()
        {
            Console.Write("Введите имя файла:");
            string filename = Console.ReadLine();
            string[] writestring = new string[arr.GetLength(0)];
            StreamWriter filewrite = new StreamWriter(filename);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    writestring[i] += arr[i, j] + " ";
                }
                filewrite.WriteLine(writestring[i]);
            }
            filewrite.Flush();
            filewrite.Close();
        }
    }
}
