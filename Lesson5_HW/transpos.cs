using System;
using System.Linq;
using System.Text;

namespace Lesson5_HW
{
    public class Transposition
    {
        public void Trnspos()
        {
            string firstword;
            string secword;
            do
            {
                Console.Clear();
                Console.WriteLine("Определяем перестановку");
                Console.Write("Введите первое слово:  ");
                firstword = Console.ReadLine();
                Console.Write("Введите второе слово:  ");
                secword = Console.ReadLine();
                if (firstword.Length != secword.Length)
                    Console.WriteLine("Слова должны быть одинаковой длины.");
            } while (firstword.Length != secword.Length);
            if (!firstword.SequenceEqual(secword))
                Console.WriteLine(firstword.Select(Char.ToUpper).OrderBy(x => x).SequenceEqual(secword.Select(Char.ToUpper).OrderBy(x => x)));
            else
                Console.WriteLine("Строки одинаковые.");
            Console.ReadKey();
            bool equal = false;
            char a = 'a';
            firstword = firstword.ToUpper();
            Console.WriteLine(firstword);
            
            char[] tmp = new char[firstword.Length];
            for (int i = 0; i < firstword.Length; i++)
            {
                for (int j = 0; j < firstword.Length; j++)
                {
                    if (firstword[i]. <= a)
                        tmp[i] = firstword[i];
                }

            }
            Console.WriteLine(tmp);
            Console.ReadKey();
            


        }
    }
}