using System;

    public class NewClass
    {
        public static void Print(string msg, int x, int y)
        {
            // Установим позицию курсора на экране
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
        public static void Print(string msg, ConsoleColor foregroundcolor )
        {
            // Установим цвет символов
            Console.ForegroundColor = foregroundcolor;
            Console.WriteLine(msg);
        }
        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }
        public void Pause()
        {
            Console.ReadKey();
        }

        public static string GetString()
        {
            return Console.ReadLine();
        }

        public static int GetInt(string str)
        {
            Print(str);
            return Int32.Parse(GetString());
        }

        public static double GetDouble()
        {
            return Double.Parse(GetString().Replace('.', ','));
        }
    }


