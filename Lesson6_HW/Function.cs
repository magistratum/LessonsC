using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Lesson6_HW
{
    class Function
    {
        //1.	Изменить программу вывода таблицы функции так, чтобы можно было передавать функции 
        //типа double (double, double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
        public static double F(double x, double a, double b, double c)
        {
            return a*x * x - b * x + c;
        }
        public static double F(double x, double a)
        {
            return a * x * x;
        }
        public static double Fs(double x, double a)
        {
            return a * Math.Sin(x);
        }
        public static void SaveFunc(string fileName, double a, double b, double h, int f, double a1, double b1 = 0, double c1 = 0)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                if (f == 1) bw.Write(F(x,a1));
                else if (f == 2) bw.Write(Fs(x, a1));
                else if (f == 3) bw.Write(F(x, a1, b1, c1));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
                Console.Write("{0} - {1}", i, d);
            }
            bw.Close();
            fs.Close();
            return min;
        }
        public void Funct()
        {
            Console.WriteLine("Выберите желаемый вид функции: \n1 - a*x^2\n2 - a*sin(x)\n3 - a*x^2+b*x+c");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1)
            {
                Console.Write("Введите коэф. а:");
                double a = Convert.ToDouble(Console.ReadLine());
                SaveFunc("funct.bin", -100, 100, 0.5, 1, a);
            }
            else
            if (key.Key == ConsoleKey.D2)
            {
                Console.Write("Введите коэф. а:");
                double a = Convert.ToDouble(Console.ReadLine());
                SaveFunc("funct.bin", -100, 100, 0.5, 2, a);
            }
            else
            if (key.Key == ConsoleKey.D3)
            {
                Console.Write("Введите коэф. а:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэф. b:");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите коэф. c:");
                double c = Convert.ToDouble(Console.ReadLine());
                SaveFunc("funct.bin", -100, 100, 0.5, 3, a, b, c);
            }
            Console.WriteLine("\n MIN = " + Load("funct.bin"));
            Console.ReadKey();
        }


    }
}
