using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

//3.	Переделать программу Пример использования коллекций для решения следующих задач:
//а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
//б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
//в) отсортировать список по возрасту студента;
//г) * отсортировать список по курсу и возрасту студента;

namespace Lesson6_HW
{
    public class CountStudent
    {
        public class Student
        {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;
            public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }
        }

        static int MyDelegat(Student st1, Student st2)         
        {
            return String.Compare(st1.firstName, st2.firstName);          
        }
        static int AgeCompare(Student st1, Student st2)          
        {
            if (st1.age < st2.age) return -1;
            if (st1.age > st2.age) return 1;
            return 0;
        }
        static int AgeCourseCompare(Student st1, Student st2)
        {
            if (st1.course > st2.course) return 1;
            if (st1.course < st2.course) return -1;
            if (st1.age > st2.age) return 1;
            if (st1.age < st2.age) return -1;
            return 0;
        }
        public void MainStud()
        {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();                             
            DateTime dt = DateTime.Now;
            int[] arrcourse = new int[6];
            StreamReader sr = new StreamReader("students_1.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]));
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                    if (int.Parse(s[5]) >= 18 && int.Parse(s[5]) <= 20 && int.Parse(s[6]) < 7) arrcourse[int.Parse(s[6])-1]++;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Сортировка по имени");
            foreach (var v in list) Console.WriteLine($"{v.firstName} курс {v.course} age {v.age}");
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров(5-6 аурс):{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            list.Sort(new Comparison<Student>(AgeCompare));
            Console.WriteLine("Сортировка по возрасту");
            foreach (var v in list) Console.WriteLine($"age {v.age}    {v.firstName} курс {v.course} ");
            list.Sort(new Comparison<Student>(AgeCourseCompare));
            Console.WriteLine("Сортировка по курсу и возрасту");
            foreach (var v in list) Console.WriteLine($"курс {v.course}   age {v.age}     {v.firstName}  ");
            Console.WriteLine($"на 1 курсе студентов от 18 до 20 лет {arrcourse[0]}");
            Console.WriteLine($"на 2 курсе студентов от 18 до 20 лет {arrcourse[1]}");
            Console.WriteLine($"на 3 курсе студентов от 18 до 20 лет {arrcourse[2]}");
            Console.WriteLine($"на 4 курсе студентов от 18 до 20 лет {arrcourse[3]}");
            Console.WriteLine($"на 5 курсе студентов от 18 до 20 лет {arrcourse[4]}");
            Console.WriteLine($"на 6 курсе студентов от 18 до 20 лет {arrcourse[5]}");

            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }

}