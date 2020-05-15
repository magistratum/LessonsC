using System;
using System.Linq;
using System.IO;
using System.Collections;
using LibArray;
using System.Collections.Generic;
using System.Text;

namespace Lesson4_HW
{
    public class TwoDimen
    {
        public void TwoDimension()
        {
            //Реализовать библиотеку с классом для работы с двумерным массивом.Реализовать конструктор, 
            //заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех элементов массива,
            //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, 
            //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
            //**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            //* *в) Обработать возможные исключительные ситуации при работе с файлами.
            int n = 0;
            int m = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите размерность массива (n.m или n,m):");
                string charsize = Console.ReadLine();
                string[] separators = { ",", ".", "!", "?", ";", ":", " " };
                string[] result = charsize.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                if (result.Length >= 1)
                    if (TwoDimenArray.IsDigit(result[0]))
                    {
                        n = Convert.ToInt32(result[0]);
                    }
                    else
                        Console.WriteLine("Размерность строки должна быть в цифрах");
                else
                    Console.WriteLine("Размерность строки не может быть пустой");
                if (result.Length > 1)
                    if (TwoDimenArray.IsDigit(result[1]))
                    {
                        m = Convert.ToInt32(result[1]);
                    }
                    else
                        Console.WriteLine("Размерность столбца должна быть в цифрах");
                else
                    Console.WriteLine("Размерность столбца не может быть пустой");
                if (n == 0 || m == 0)
                {
                    Console.WriteLine("Размерность строки и столбца должна быть больше нуля.");
                    Console.WriteLine("Нажмите любую клавишу ...");
                    Console.ReadKey(true);
                }
            } while (n == 0 || m == 0);
            TwoDimenArray two = new TwoDimenArray(n, m);
            two.Print();
            Console.WriteLine($"Max = {two.Max}");
            Console.WriteLine($"Min = {two.Min}");
            Console.WriteLine($"Sum = {two.Sum()}");
            Console.WriteLine($"Sum(n) = {two.Sum(5)}");
            Console.WriteLine($"Max(n.m) = {two.NumberMax(ref n, ref m)}({n},{m})");
            ConsoleKeyInfo key;
            string filepath;
            Console.WriteLine("Сохранить в файл? Y/N");
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
            {
                two.WriteArray();
            }
            Console.Write("Введите имя файла для чтения:");
            filepath = Console.ReadLine();
            TwoDimenArray twoDimension = new TwoDimenArray(filepath);
            twoDimension.Print();

        }
    }
}
    