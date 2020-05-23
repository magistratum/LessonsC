using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public delegate double function(double x, double a, double b, double c);
//2.	Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
//а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
//б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр(с использованием модификатора out). 

namespace Lesson6_HW
{
    class Function_Delegate
    {
        public static double F(double x, double a, double b, double c)
        {
            return a * x * x - b * x + c;
        }
        public static double Fsqr(double x, double a, double b, double c)
        {
            return a * x * x;
        }
        public static double Fsin(double x, double a, double b, double c)
        {
            return a * Math.Sin(x);
        }
        public static void SaveFunc(string fileName, double a, double b, double h, double a1, double b1, double c1, function F )
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x, a1, b1, c1));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName, out double minfun)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            minfun = double.MaxValue;
            double d;
            double[] arr = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < minfun) minfun = d;
                arr[i] = d;
            }
            bw.Close();
            fs.Close();
            return arr;
        }
        public void Funct()
        {
            function[] function = { Fsqr, Fsin, F };
            Console.WriteLine("Выберите желаемый вид функции: \n1 - a*x^2\n2 - a*sin(x)\n3 - a*x^2+b*x+c");
            ConsoleKeyInfo key = Console.ReadKey(true);
            string s = key.KeyChar.ToString();
            int i = Convert.ToInt32(s);
            Console.Write("Введите коэф. а:");
            double a = Convert.ToDouble(Console.ReadLine());
            double b = 0;
            double c = 0;
            if (i == 3)
            {
                Console.Write("Введите коэф. b:");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэф. c:");
                c = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Введите минимум диапазона min:");
            double min = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите максимум диапазона max:");
            double max = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите шаг расчета h:");
            double h = Convert.ToDouble(Console.ReadLine().Replace('.',','));
            SaveFunc("funct.bin", min, max, h, a, b, c, function[i-1]);
            double minfun;
            double[] arr = Load("funct.bin", out minfun);
            Console.WriteLine("\n MIN = " + minfun);
            Console.ReadKey();
            foreach (double v in arr)
                Console.WriteLine($" {v} ");
            Console.ReadKey();
        }


    }
}
