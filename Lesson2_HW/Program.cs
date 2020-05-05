//autor: Мартыненко Александр 
using System;

namespace Lesson2_HW
{
    class Program
    {		
		static void Main()
        {
			MinOverThree();
			Console.ReadKey();
			QuantityNumber();
			Console.ReadKey();
			MathSumm();
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("Просьба пройти авторизацию");
			if (Autorization())
				Console.WriteLine("Авторизация пройдена успешно");
			else
				Console.WriteLine("В доступе отказано");
			Console.ReadKey();
			Imt();
			Console.ReadKey();
			CalculateGoodNumeric();
			Console.ReadKey();
			SummAB();
			Console.ReadKey();
		}
		static bool isOdd(int n)
		{
			return n % 2 == 0;
		}
		static void MinOverThree()
		{
			// Задание №1
			// Написать метод, возвращающий минимальное из трех чисел.
			int min;
			int a = NewClass.GetInt("Введите первое число");
			int b = NewClass.GetInt("Введите второе число");
			int c = NewClass.GetInt("Введите третье число");
			if (a < b && a < c) min = a;
			else if (b < a && b < c) min = b;
			else min = c;
			Console.WriteLine("Минимальное число {0}", min);
		}
		static void QuantityNumber()
		{
			// 2.	Написать метод подсчета количества цифр числа
			Console.Clear();
			int count = 0;
			Console.WriteLine("Number?");
			string num = Console.ReadLine();
			for (int i = 0; i < num.Length; i++)
			{
				if (char.IsDigit(num, i)) count++;
			}
			Console.WriteLine("В числе {0} цифр {1}", num, count);

		}
		static void MathSumm()
		{
			//3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел
			int summ = 0, num;
			Console.Clear();
			do
			{
				num = NewClass.GetInt("Введите целое число (0-окончание ввода)");
				if (!isOdd(num) && num > 0) summ += num;
			} while (num > 0);
			Console.WriteLine("Сумма = {0}", summ);
		}
		static bool Autorization()
		{
			//4.Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль.
			//На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password: GeekBrains).
			//Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
			//программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками
			int count = 0;
			do
			{
				Console.Write("Login:");
				string login = Console.ReadLine();
				Console.Write("Password:");
				string pass = Console.ReadLine();
				if (login.Equals("root") && pass.Equals("GeekBrains"))
					return true;
				else
					Console.WriteLine("Error login or passord");
				count++;
			} while (count < 3);
			return false;
		}
		static void Imt()
		{
			//5.а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает,
			//	нужно ли человеку похудеть, набрать вес или всё в норме.
			//б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
			double imt_min_norm = 18.5, imt_max_norm = 24.99;
			Console.Clear();
			Console.WriteLine("Расчет индекса массы тела");
			Console.WriteLine("Введите массу тела(кг)");
			double mass = NewClass.GetDouble();
			Console.WriteLine("Введите рост(м)");
			double height = NewClass.GetDouble();
			double imt = mass / (height * height);
			if (imt < imt_min_norm)
				Console.WriteLine($"Ваш ИМТ = {imt:f}(ниже нормы), необходимо набрать {(imt_min_norm - imt)* (height * height):f} кг.");
			else if (imt > imt_max_norm)
				Console.WriteLine($"Ваш ИМТ = {imt:f} (выше нормы), необходимо сбросить {(imt - imt_max_norm)* (height * height):f} кг.");
			else
				Console.WriteLine($"Ваш ИМТ = {imt:f} (норма), всё в порядке.");
		}
		static void CalculateGoodNumeric()
		{
			//6.  * Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
			//	«Хорошим» называется число, которое делится на сумму своих цифр.
			//	Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
			int count_num = 0;
			Console.ForegroundColor = ConsoleColor.Green;
			DateTime start = DateTime.Now;
			for (int i = 1; i < 1000000000; i++)
			{
				int tmp_i = i, tmp_sum = 0;
				while(tmp_i !=0)
				{
					tmp_sum += tmp_i % 10;
					tmp_i = tmp_i / 10;
				}
				if ((i % tmp_sum) == 0)
				{
					count_num++;
					Console.Write("*");
				}
			}
			DateTime stop = DateTime.Now;
			Console.WriteLine($"\nПодсчитано {count_num} хороших чисел за {stop - start} сек.");
		}
		static void SummAB()
		{
			//7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
			//б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
			int sum = 0;
			int a = NewClass.GetInt("Введите а:");
			int b = NewClass.GetInt("Введите b(больше а):");
			sum = SummAB_Rec(a, b, sum);
			Console.WriteLine($"Сумма = {sum}");
		}
		static int SummAB_Rec(int a, int b, int sum)
		{
			//7.a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a < b).
			//б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
			if (b >= a)
			{
				Console.WriteLine($"a = {a} --- b = {b}");
				return sum = a + SummAB_Rec(a + 1, b, sum);
			}
			return 0;
		}
	}
}
