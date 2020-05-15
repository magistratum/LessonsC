using System;
using LibArray;

namespace Lesson4_HW
{
    public class MathCoupleClass
    {
        public void MathCouple()
        {
            //2.Реализуйте задачу 1 в виде статического класса StaticClass;
            //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
            //б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
            //в)**Добавьте обработку ситуации отсутствия файла на диске
            int arrlength = 0;
            Console.WriteLine("Введите размер одномерного массива:");
            arrlength = int.Parse(Console.ReadLine());
            MyArray arr = new MyArray(arrlength);
            int count = arr.CoupleCount();
            arr.Print();
            Console.WriteLine($"\nИз класса счетчик пар с делением на 3: {count}");
            Console.ReadKey(true);
            MyArray array = new MyArray("data.txt");
            Console.WriteLine("Считанно из файла:");
            array.Print();
            Console.ReadKey(true);
        }
    }
}