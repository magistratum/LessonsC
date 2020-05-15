using System;
using LibArray;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson4_HW
{
    public class MathClass
    {
        public void MathArray()
        {
            //3.а) Дописать класс для работы с одномерным массивом.Реализовать конструктор, создающий массив 
            //определенного размера и заполняющий массив числами от начального значения с заданным шагом.
            //Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, 
            //возвращающий новый массив с измененными знаками у всех элементов массива(старый массив, остается без изменений), 
            //метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
            //б)**Создать библиотеку содержащую класс для работы с массивом.Продемонстрировать работу библиотеки
            //е) ***Подсчитать частоту вхождения каждого элемента в массив(коллекция Dictionary< int,int>)
            // Добавлена запись отсортированного массива в файл
            Console.Clear();
            Console.WriteLine("Введите размер одномерного массива:");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите начальное значение массива:");
            int init = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите шаг заполнения массива:");
            int step = Convert.ToInt32(Console.ReadLine());
            MyArray array = new MyArray(size, init, step);
            array.Print();
            Console.WriteLine($"Сумма всех элементов = {array.Summ}");
            Console.WriteLine("Проинвертированный массив:");
            int[] invarr = array.Inverse();
            array.Print(invarr);
            Console.WriteLine("Введите число на которое надо умножить:");
            int multiplier = Convert.ToInt32(Console.ReadLine());
            array.Multi(multiplier);
            Console.WriteLine($"Массив умноженный на {multiplier}:");
            array.Print();
            Console.WriteLine($"Колическтво макс. элементов в массиве: {array.MaxCount}");
            var dictionaryArr = new Dictionary<int, int>();
            MyArray array1 = new MyArray(20, false);
            Console.WriteLine("Произвольно сгенерированный массив");
            Console.WriteLine("До сортировки:");
            array1.Print();
            array1.Sort();
            Console.WriteLine("После сортировки:");
            array1.Print();
            int j = 1;
            for (int i = 0; i < array1.GetLength; i++)
            {
                if (i < array1.GetLength - 1)
                {
                    if (array1[i] != array1[i + 1])
                    {
                        dictionaryArr.Add(array1[i], j);
                        j = 1;
                    }
                    else j++;
                }
                else
                {
                    dictionaryArr.Add(array1[i], j);
                }
            }
            foreach (KeyValuePair<int, int> a in dictionaryArr)
            {
                Console.WriteLine($"Вхождений => {a.Value} Элемента массива => {a.Key}");
            }
            Console.Write("Введите имя файла для сохранения массива:");
            string filename = Console.ReadLine();
            StreamWriter sw = new StreamWriter(filename, false, Encoding.ASCII);
            for (int i = 0; i < array1.GetLength; i++)
            {
                sw.WriteLine(array1[i]);
            }
            sw.Flush();
            sw.Close();
        }
    }
}