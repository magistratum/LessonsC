using System;
using System.Linq;
using System.IO;
using System.Collections;
using LibArray;
using System.Collections.Generic;
using System.Text;


namespace Lesson4_HW
{
    class Program
    {
        static void Main()
        {
            new MyArray20().Array20();
            new MathCoupleClass().MathCouple();
            new MathClass().MathArray();
            Console.WriteLine("Просьба пройти авторизацию");
            bool autor = new Autorization().Autoriz();
            if (autor)
                Console.WriteLine("Авторизация пройдена успешно");
            else
                Console.WriteLine("В доступе отказано");
            Console.WriteLine("Нажмите любую клавишу ...");
            Console.ReadKey(true);
            new TwoDimen().TwoDimension();
            Console.ReadKey();
        }
    }
}
