using System;
using System.Text.RegularExpressions;

namespace Lesson5_HW
{
    public class CorrektLogin
    {
        public void CorLogin()
        {
            //1.Создать программу, которая будет проверять корректность ввода логина.
            //    Корректным логином будет строка от 2 до 10 символов, содержащая только буквы
            //    латинского алфавита или цифры, при этом цифра не может быть первой:
            //а) без использования регулярных выражений;
            //б) **с использованием регулярных выражений

            Console.Write("Введите логин:");
            string log = Console.ReadLine();
            //log = "asd123da";
            bool logcorrect = false;
            if (log.Length >= 2 || log.Length <= 10)
                logcorrect = true;
            else
            {
                Console.WriteLine("Логин должен быть больше 2, но меньше 10 символов.");
                logcorrect = false;
            }
            if (log[0] >= '0' && log[0] <= '9')
            {
                logcorrect = false;
                Console.WriteLine("Логин не может содержать первым символом цифру");
            }
            else if ((log[0] >= 'a' && log[0] <= 'z') || (log[0] >= 'A' && log[0] <= 'Z'))
                logcorrect = true;
            else logcorrect = false;
            if (logcorrect == true)
            {
                for (int i = 1; i < log.Length; i++)
                    if ((log[i] >= 'a' && log[i] <= 'z') || (log[i] >= 'A' && log[i] <= 'Z') || (log[i] >= '0' && log[i] <= '9'))
                        logcorrect = true;
                    else
                    {
                        logcorrect = false;
                        break;
                    }
            }
            if (logcorrect)
                Console.WriteLine("Правильный логин!");
            else
                Console.WriteLine("Неправильный логин!");
            //с использованием регулярных выражений
            Regex regex = new Regex(@"^[a-zA-Z][0-9a-zA-Z]{1,9}$");
            if (!regex.IsMatch(log))
                Console.WriteLine("Введен неверный логин.");
            else
                Console.WriteLine("Логин корректен!");
        }
    }
}