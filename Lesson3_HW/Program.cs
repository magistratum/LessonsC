// autor: Мартыненко Александр
using System;
using System.ComponentModel;
using System.Threading;

namespace Lesson3_HW
{
    class Complex
    {
        private double im;
        double re;
        public Complex()
        {
            im = 0;
            re = 0;
        }
        public Complex(double _im, double re)
        {
            im = _im;
            this.re = re;
        }
        public Complex Plus(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }
        public Complex Sub(Complex x2)
        {
            Complex x3 = new Complex();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }
        public Complex Multi(Complex x)
        {
            Complex y = new Complex();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public Complex Div(Complex x)
        {
            Complex y = new Complex();
            double z = Math.Pow(x.re, 2) + Math.Pow(x.im,2);
            y.im = (re * x.im - im * x.re)/z;
            y.re = (re * x.re + im * x.im)/z;
            return y;
        }
        public double Im
        {
            get => im;
            set => im = value;
        }
        public double Re
        {
            get => re;
            set => re = value;
        }
        public string NewToString()
        {
            return re + " + " + im + "i";
        }
    }
    class Fractions
    {
        double _dividend, _divider;
        public Fractions()
        {
            _dividend = 0;
            _divider = 0;
        }
        public Fractions(double dividend, double divider)
        {
            _dividend = dividend;
            _divider = divider;
        }
        public double dividend
        {
            get => _dividend;
            set => _dividend = value;
        }
        public double divider
        {
            get => _divider;
            set => _divider = value;
        }
        public double Addition(Fractions y, Fractions z) 
        {
            z._dividend = (_dividend * y._divider + _divider * y._dividend);
            z._divider = (_divider * y._divider);
            if ( z.divider == 0) throw new ArgumentException($"Ошибка - деление на ноль", "z.divider");
            return (z._dividend / z._divider);
        }        
        public double Substract(Fractions y, Fractions z) 
        {
            z._dividend = (_dividend * y._divider - _divider * y._dividend);
            z._divider = (_divider * y._divider);
            if (z.divider == 0) throw new ArgumentException($"Ошибка - деление на ноль", "z.divider");
            return (z._dividend / z._divider);
        }        
        public double Multip(Fractions y, Fractions z)
        {
            z._dividend = _dividend * y._dividend;
            z._divider = _divider * y._divider;
            if (z.divider == 0) throw new ArgumentException($"Ошибка - деление на ноль", "z.divider");
            return (z._dividend / z._divider);
        }       
        public double Division(Fractions y, Fractions z)
        {
            z._dividend = _dividend * y._divider;
            z._divider = _divider * y._dividend;
            if (z.divider == 0) throw new ArgumentException($"Ошибка - деление на ноль", "z.divider");
            return (z._dividend / z._divider);
        }

    }
    class Program
    {
        static void GetValue( ref string buf)
        {
            int x;
            string s;
            bool flag;  
            do
            {
                Console.WriteLine("Введите число:");
                s = Console.ReadLine();
                flag = int.TryParse(s, out x);
                if (!flag)
                    Console.WriteLine(s + " не является числом");
                else
                    if (!IsOdd(x) && x > 0) buf += s + " ";
            }
            while ( !flag || x != 0);  
        }
        static void Main()
        {
            ComplexArithmetic();
            SumNumber();
            MathFraction();



        }
        static void ComplexArithmetic()
        {
            //а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
            //б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
            //в) Добавить диалог с использованием switch демонстрирующий работу класса.
            Complex complex1;
            complex1 = new Complex(1, 1);
            Complex complex2 = new Complex(2, 2);
            Complex result;      
            ConsoleKeyInfo z;
            Random rnd = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine($"Complex1 = {complex1.NewToString()}");
                Console.WriteLine($"Complex2 = {complex2.NewToString()}");
                Console.WriteLine("Выберите необходимое действие:\n1 - Сложение\n2 - Вычитание\n3 - Умножение\n4 - Деление\n0 - Выход");
                z = Console.ReadKey(true);
                switch (z.Key)
                {
                    case ConsoleKey.D1:
                        result = complex1.Plus(complex2);
                        Console.WriteLine($"Сложение {result.Re} {(result.Im < 0 ? " - " : " + ")} {result.Im}i");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        result = complex1.Sub(complex2);
                        Console.WriteLine($"Вычитание {result.Re} {(result.Im < 0 ? " - " : " + ")} {Math.Abs(result.Im)}i");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        result = complex1.Multi(complex2);
                        Console.WriteLine($"Умножение {result.Re} {(result.Im < 0 ? " - " : " + ")} {Math.Abs(result.Im)}i");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        result = complex1.Div(complex2);
                        Console.WriteLine($"Деление {result.Re:f} {(result.Im < 0 ? " - " : " + ")} {Math.Abs(result.Im):f}i");
                        Console.ReadKey();
                        break;
                }
                complex1.Re = rnd.Next(10);
                complex1.Im = rnd.Next(10);
                complex2.Re = rnd.Next(10);
                complex2.Im = rnd.Next(10);
            } while (z.Key != ConsoleKey.D0);
            Console.Clear();
        }
        static void SumNumber()
        {
            //а) С клавиатуры вводятся числа, пока не будет введен 0(каждое число в новой строке).
            //    Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
            //б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные.
            //    При возникновении ошибки вывести сообщение.Напишите соответствующую функцию;
            string number = "", tmp_buf = "";
            Console.Clear();
            int sum = 0;
            GetValue(ref number); // Мы не ищем лёгких путей :)
            for ( int i = 0; i < number.Length; i++)
            {
                if (!number[i].Equals(' '))
                {
                    tmp_buf += number[i];
                }
                else
                {
                    sum += int.Parse(tmp_buf);
                    tmp_buf = "";
                }
            }
            Console.WriteLine("Введенные нечетные значения: " + number);
            Console.WriteLine("Сумма положительных нечетных: {0}", sum);
            Console.ReadKey();
        }
        static void MathFraction()
        {
            //Описать класс дробей -рациональных чисел, являющихся отношением двух целых чисел.
            //Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу,
            //демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи.Все программы сделать в одном решении.
            //Добавить проверку, чтобы знаменатель не равнялся 0.Выбрасывать исключение
            //ArgumentException("Знаменатель не может быть равен 0");
            Fractions fraction1 = new Fractions(3,7);
            Fractions fraction2 = new Fractions(8, 9);
            Fractions fraction3 = new Fractions();
            double result = 0;
            ConsoleKeyInfo z;
            Random rnd = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine($"fraction1 = {fraction1.dividend}/{fraction1.divider}");
                Console.WriteLine($"fraction2 = {fraction2.dividend}/{fraction2.divider}");
                Console.WriteLine("Выберите необходимое действие:\n1 - Сложение\n2 - Вычитание\n3 - Умножение\n4 - Деление\nESC - Выход");
                z = Console.ReadKey(true);
                switch (z.Key)
                {
                    case ConsoleKey.D1:
                        try
                        {
                            result = fraction1.Addition(fraction2, fraction3);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                        }
                        Console.WriteLine($"Сложение {fraction1.dividend}/{fraction1.divider} + {fraction2.dividend}/{fraction2.divider} = {fraction3.dividend}/{fraction3.divider} = {result:f}");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        try
                        {
                            result = fraction1.Substract(fraction2, fraction3);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                        }
                        Console.WriteLine($"Вычитание {fraction1.dividend}/{fraction1.divider} - {fraction2.dividend}/{fraction2.divider} = {fraction3.dividend}/{fraction3.divider} = {result:f}");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        try
                        {
                            result = fraction1.Multip(fraction2, fraction3);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                        }
                        Console.WriteLine($"Умножение {fraction1.dividend}/{fraction1.divider} * {fraction2.dividend}/{fraction2.divider} = {fraction3.dividend}/{fraction3.divider} = {result:f}");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        try
                        {
                            result = fraction1.Division(fraction2, fraction3);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                        }
                        Console.WriteLine($"Деление {fraction1.dividend}/{fraction1.divider} / {fraction2.dividend}/{fraction2.divider} = {fraction3.dividend}/{fraction3.divider} = {result:f}");
                        Console.ReadKey();
                        break;
                }
                fraction1.dividend = rnd.Next(10);
                fraction1.divider = rnd.Next(10);
                fraction2.dividend = rnd.Next(10);
                fraction2.divider = rnd.Next(10);
            } while (z.Key != ConsoleKey.Escape);
            Console.Clear();
        }
        static bool IsOdd( int x)
        {
            if (x % 2 == 0) return true; else return false;
        }
    }
}
