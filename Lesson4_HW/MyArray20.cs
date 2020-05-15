using System;


namespace Lesson4_HW
{
    public class MyArray20
    {
        public void Array20()
        {
            //1.Дан  целочисленный массив  из 20 элементов.Элементы массива  могут принимать  целые значения 
            //    от –10 000 до 10 000 включительно.Заполнить случайными числами.Написать программу,
            //    позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
            //    В данной задаче под парой подразумевается два подряд идущих элемента массива. 
            //    Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2
            int arrlength = 0;
            Console.WriteLine("Введите размер одномерного массива:");
            arrlength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrlength];
            Random rnd = new Random();
            for (int i = 0; i < arrlength; i++)
                arr[i] = rnd.Next(-10000, 10000);
            int count = 0;
            for (int i = 1; i < arrlength; i++)
                if ((arr[i - 1] % 3 == 0 && arr[i] % 3 != 0) || (arr[i - 1] % 3 != 0 && arr[i] % 3 == 0))
                    count++;
            for (int i = 0; i < arrlength; i++)
                Console.WriteLine(arr[i]);
            Console.WriteLine($"Cчетчик пар с делением на 3: {count}");
            Console.ReadKey(true);
        }
    }
}