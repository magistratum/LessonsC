using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.IO;

namespace Lesson5_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            //Message message = new Message(50);
            //new CorrektLogin().CorLogin();
            //Console.Write("Введите ограничение по кол-ву символов в слове:");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Введите имя файла для проверки на символ и длину :"); // Предлагается rus.txt or data.txt
            //string filename = Console.ReadLine();
            //message.MsgLessN(n, filename);
            //message.MsgDel();
            //message.MaxLong();
            //Console.Write("Введите наименование файла с массивом ключевых слов:"); // Предлагается word.txt
            //string fileword = Console.ReadLine();
            //Console.Write("Введите наименование файла с текстовым массивом:"); // Предлагается rus1.txt
            //string filetext = Console.ReadLine();
            //string[] separator = { " ", ",", ".", ";", ":", "/", "|","«","»","-","?","!","–" };
            //if (!string.IsNullOrEmpty(fileword) && File.Exists(fileword) && !string.IsNullOrEmpty(filetext) && File.Exists(filetext))
            //{
            //    StreamReader fw = new StreamReader(fileword);
            //    StreamReader ft = new StreamReader(filetext);
            //    string arrw = fw.ReadToEnd();
            //    string arrt = ft.ReadToEnd();
            //    string[] arrword = arrw.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //    string[] arrtext = arrt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //    var dict = new TextFreq().TextFrequenc(arrword, arrtext);
            //    fw.Close();
            //    ft.Close();
            //    foreach (KeyValuePair<string, int> keyValue in dict)
            //        Console.WriteLine($"Слово -{keyValue.Key}- в тексте повторяется -{keyValue.Value}- раз.");
            //}
            //else if (string.IsNullOrEmpty(fileword) || !File.Exists(fileword))
            //    Console.WriteLine($"Файл с именем {fileword} не найден.");
            //else if (string.IsNullOrEmpty(filetext) || !File.Exists(filetext))
            //    Console.WriteLine($"Файл с именем {filetext} не найден.");
            new Transposition().Trnspos();
            Console.ReadKey();
        }
    }
}
