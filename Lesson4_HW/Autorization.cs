using System;
using System.IO;


namespace Lesson4_HW
{
    public class Autorization
    {
        public bool Autoriz()
        {
            //4.Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив.
            //  Создайте структуру Account, содержащую Login и Password
            bool autor = false;
            int count = 0;
            string login;
            string pass;
            if (File.Exists("logpass.dbd"))
            {
                string[] ss = File.ReadAllLines("logpass.dbd");
                Account[] ArrAcount = new Account[ss.Length / 2];
                int j = 0;
                for (int i = 0; i < ss.Length; i += 2)
                {
                    ArrAcount[j].login = ss[i];
                    ArrAcount[j].password = ss[i + 1];
                    j++;
                }
                do
                {
                    Console.Write("Login:");
                    login = Console.ReadLine();
                    Console.Write("Password:");
                    pass = Console.ReadLine();
                    for (int i = 0; i < ArrAcount.Length; i++)
                    {
                        if (login.Equals(ArrAcount[i].login) && pass.Equals(ArrAcount[i].password))
                        {
                            autor = true;
                            break;
                        }
                    }
                    if (autor == false) Console.WriteLine("Error login or passord");
                    count++;
                } while (count < 3 && autor == false);
            }
            else
            {
                Console.WriteLine("Отсутствует файл с базой доступа.");
                Console.WriteLine("Хотите ипользовать доступ по умолчанию? Y/N");
                string quest = Console.ReadLine();
                if (quest.Equals("y") || quest.Equals("Y"))
                {
                    do
                    {
                        Console.Write("Login:");
                        login = Console.ReadLine();
                        Console.Write("Password:");
                        pass = Console.ReadLine();
                        if (login.Equals("root") && pass.Equals("GeekBrains"))
                            autor = true;
                        else
                            Console.WriteLine("Error login or passord");
                        count++;
                    } while (count < 3 && autor == false);
                }
                else
                {
                    Console.WriteLine("Хотите заполнить файл? Y/N");
                    quest = Console.ReadLine();
                    if (quest.Equals("y") || quest.Equals("Y"))
                    {
                        WriteLogPass();
                        Console.WriteLine("Перейти к авторизации? Y/N");
                        quest = Console.ReadLine();
                        if (quest.Equals("y") || quest.Equals("Y"))
                            autor = Autoriz();
                    }
                }
            }
            return autor;
        }
        public void WriteLogPass()
        {
            StreamWriter filewrite = new StreamWriter("logpass.dbd");
            Account WriteLogPass = new Account();
            Console.WriteLine("Login = exit окончание ввода:");
            do
            {
                Console.WriteLine("Login:");
                WriteLogPass.login = Console.ReadLine();
                if (WriteLogPass.login.Equals("exit")) break;
                filewrite.WriteLine(WriteLogPass.login);
                Console.WriteLine("Password:");
                WriteLogPass.password = Console.ReadLine();
                filewrite.WriteLine(WriteLogPass.password);
            } while (!WriteLogPass.login.Equals("exit"));
            filewrite.Flush();
            filewrite.Close();
        }
    }
}
