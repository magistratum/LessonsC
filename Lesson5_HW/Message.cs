using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_HW
{
    public class Message
    {
        string _msg;
        string[] _arrmsg;
        string fileread;
        string filesave;

        public Message(int n)
        {
            _msg = "";
            _arrmsg = new string[n];
        }
       public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        public string[] Arrmsg
        {
            set { _arrmsg = value; }
            get { return _arrmsg; }
        }
        public void MsgLessN(int n, string filename)
        {
            //Вывести только те слова сообщения,  которые содержат не более n букв
            if(File.Exists(filename))
            {
                StreamReader filedat = new StreamReader(filename);
                while (!filedat.EndOfStream)
                {
                    _msg = filedat.ReadLine();
                    _arrmsg = _msg.Split(' ');
                    for (int i = 0; i < _arrmsg.Length; i++)
                    {
                        if (_arrmsg[i].Length < n)
                            Console.WriteLine(_arrmsg[i]);
                    }
                }
                filedat.Close();
            }
        }
        public void MsgDel()
        {
            //Удалить из сообщения все слова, которые заканчиваются на заданный символ
            if (string.IsNullOrEmpty(fileread))
            {
                Console.Write("Введите имя файла для чтения:");
                fileread = Console.ReadLine();
            }
            Console.Write("Введите контрольный символ:");
            string  str = Console.ReadLine();
            char symbol = str[0];
            while (filesave == fileread || string.IsNullOrEmpty(filesave))
            {
                Console.Write("Введите имя файла для записи:");
                filesave = Console.ReadLine();
                if (filesave == fileread) Console.WriteLine("Имя файла для записи не может совпадать с именем файла для чтения");
                if (string.IsNullOrEmpty(filesave)) Console.WriteLine("Имя файла не может быть пустым");
            }
            if (File.Exists(fileread))
            {
                StreamReader rfile = new StreamReader(fileread);
                StreamWriter sfile = new StreamWriter(filesave, false);
                string[] separator = { " ", ",", "." };
                while (!rfile.EndOfStream)
                {
                    _msg = rfile.ReadLine();
                    _arrmsg = _msg.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string arrdel = "";
                    for (int i = 0; i < _arrmsg.Length; i++)
                        if (_arrmsg[i][_arrmsg[i].Length - 1] != symbol)
                            arrdel += _arrmsg[i] + " ";
                    sfile.WriteLine(arrdel);
                }
                rfile.Close();
                sfile.Close();
                Console.WriteLine("Файл сохранен.");
            }
            else Console.WriteLine($"Файл {fileread} не найден");
        }
        public void MaxLong()
        {
            //Найти самое длинное слово сообщения
            Console.WriteLine("Поиск самого длинного слова.");
            if (string.IsNullOrEmpty(fileread))
            {
                Console.Write("Введите имя файла для чтения:");
                fileread = Console.ReadLine();
            }
            string[] maxword = new string[2] { "", "" };
            StringBuilder strbuild = new StringBuilder();
            int count = 0;
            int max = 0;
            if (File.Exists(fileread))
            {
                StreamReader rfile = new StreamReader(fileread);
                string[] separator = { " ", ",", "." };
                while (!rfile.EndOfStream)
                {
                    _msg = rfile.ReadLine();
                    _arrmsg = _msg.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < _arrmsg.Length; i++)
                        if (_arrmsg[i].Length > maxword[count].Length)
                        {
                            max = _arrmsg.Length;
                            maxword[count] = _arrmsg[i];
                        }
                        else if (_arrmsg[i].Length == maxword[count].Length)
                        {
                            count++;
                            if (count >= maxword.Length)
                            {
                                Array.Resize(ref maxword, maxword.Length + 1);
                            }
                            maxword[count] = _arrmsg[i];
                        }
                }
                rfile.Close();
                foreach (string z in maxword)
                {
                    Console.WriteLine($"Самое длинное слово: {z} из {max} символов.");
                    strbuild.Append(z + " ");
                }
                string zx = strbuild.ToString();
                Console.WriteLine("Строка StringBuilder: " + zx);
            }
            else Console.WriteLine($"Файл {fileread} не найден");
            
        }
    }
}
