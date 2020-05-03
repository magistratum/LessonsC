using System;

namespace Lesson1_HW
{
    class Program
    {
        static void Main()
        {
            NewClass newClass = new NewClass();
            // Задание №1
            newClass.Print("Введите Имя:", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            newClass.Print("Введите Фамилию:", ConsoleColor.Green);
            string family = Console.ReadLine();
            newClass.Print("Введите Возраст:", ConsoleColor.White);
            string age = Console.ReadLine();
            newClass.Print("Введите Рост (в метрах):");
            double height = newClass.GetDouble();
            newClass.Print("Введите вес (в килограммах):");
            double weight = newClass.GetDouble();
            newClass.Print("Вывод путем склеивания");
            Console.WriteLine("Привет " + name + " " + family + ". Возраст " + age + ". Рост " + height + ". Вес " + weight);
            newClass.Print("Форматированный вывод");
            Console.WriteLine("Привет {0} {1}. Возраст {2}. Рост {3}. Вес {4}", name, family, age, height, weight);
            newClass.Print("Интерполяция ");
            Console.WriteLine($"Привет {name} {family}. Возраст {age}. Рост {height}. Вес {weight}");
            Console.ReadKey();
            // Задание №2,5
            Console.Clear();
            string str = "Индекс массы тела:";
            str += weight / (height * height);
            newClass.Print(str, (Console.WindowWidth - str.Length)/ 2 , Console.WindowHeight / 2);
            Console.ReadKey();
            // Задание №3
            Console.Clear();
            Distance();
            // Задание №4
            Console.Clear();
            SwitchAB();

        }
        static void Distance()
        {
            Console.WriteLine("Введите Х1:");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Х2:");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y1:");
            double y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Y2:");
            double y2 = double.Parse(Console.ReadLine());
            //double res = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Расстояние между точками: {0:f}", CalculateDistance(x1, x2, y1, y2));
            Console.ReadKey();
        }
        static double CalculateDistance(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        static void SwitchAB()
        {
            Console.WriteLine("Введите значение А:");
            double A = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение B:");
            double B = Convert.ToDouble(Console.ReadLine());
            A = A + B;
            B = A - B;
            A = A - B;
            Console.WriteLine($"После замены А = {A:F}, B = {B:F}.");
            Console.ReadKey();
        }
    }
}
