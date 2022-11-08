using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace SimpleClassConlsole
{
    internal class Company
    {
        public string NameCompany; // назва компанії
        public string PositionWorker; // посада працівника
        public int SalaryWorker; // зарплата працівника
        public Company(string nameCompany, string positionWorker, int salaryWorker)
        {
            NameCompany = nameCompany;
            PositionWorker = positionWorker;
            SalaryWorker = salaryWorker;
        }
        public void SetNameCompany(string nameCompany) // конструктор з параметром
        {
            {
                if (nameCompany.Length > 0)
                    NameCompany = nameCompany;
            }
        }
        public void SetPositionWorker(string positionWorker) // конструктор з параметром
        {
            {
                if (positionWorker.Length > 0)
                    PositionWorker = positionWorker;
            }
        }
        public void SetSalaryWorker(int salaryWorker) // конструктор з параметром
        {
            if (salaryWorker > 1 && salaryWorker < 10000)
                SalaryWorker = salaryWorker;
        }
        public string GetNameCompany()
        {
            return NameCompany;
        }
        public string GetPositionWorker()
        {
            return PositionWorker;
        }
        public int GetSalaryWorker()
        {
            return SalaryWorker;
        }
        public Company() // конструктор по замовчуванню
        {
        }
    }
    internal class Worker
    {
        public string NameWorker; // прізвище працівника
        public int Year; // рік початку роботи
        public int Month; // місяць початку роботи
        public Company WorkPlace = new Company();
        public Worker(string nameWorker, int year, int month)
        {
            NameWorker = nameWorker;
            Year = year;
            Month = month;
        }

        public Worker() // конструктор по замовчуванню
        {
        }

        public void SetNameWorker(string nameWorker) // конструктор з параметром
        {
            if (nameWorker.Length > 0)
                NameWorker = nameWorker;
        }
        public void SetYear(int year) // конструктор з параметром
        {
            if (year > 2000 && year < 2100)
                Year = year;
        }
        public void SetMonth(int month) // конструктор з параметром
        {
            if (month > 1 && month < 12)
                Month = month;
        }
        public string GetNameWorker()
        {
            return NameWorker;
        }
        public int GetYear()
        {
            return Year;
        }
        public int GetMonth()
        {
            return Month;
        }
    }
    class Program
    {
        static void CheckInt(out int x, int max = 200, int min = 0) // конструктор з параметром
        {
            bool ok;
            do
            {
                ok = int.TryParse(ReadLine(), out x);
                if (!ok || x < min || x > max)
                    WriteLine("Некоректне введення, повторіть спробу.");
            } while (!ok || x < min || x > max);
        }
        static Worker[] ReadWorkersArray() // створення масиву працівників
        {
            Worker[] array;
            Write("К-сть працівників N = ");
            int n; CheckInt(out n, 200, 1);
            array = new Worker[n];
            for (int i = 0; i < n; i++)
            {
                WriteLine($"\tПрацівник № {i}");
                WriteLine("Прізвище працівника:");
                array[i] = new Worker();
                array[i].NameWorker = ReadLine();
                WriteLine("Рік початку роботи від 2000 до 2100:");
                CheckInt(out array[i].Year, 2100, 2000);
                WriteLine("Місяць початку роботи від 1 до 12:");
                CheckInt(out array[i].Month, 12, 1);
                WriteLine("Назва компанії:");
                array[i].WorkPlace.NameCompany = ReadLine();
                WriteLine("Посада працівника:");
                array[i].WorkPlace.PositionWorker = ReadLine();
                WriteLine("Зарплата працівника від 1 до 10000:");
                CheckInt(out array[i].WorkPlace.SalaryWorker, 10000, 1);
            }
            return array;
        }
        static void PrintWorker(Worker x) // конструктор з параметром
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("\n******************************************************************************************************\n");
            WriteLine($"Працівник:     {x.NameWorker,15}");
            WriteLine($"Рік та місяць початку роботи:     {x.Year}.{x.Month}");
            WriteLine($"Компанія:               {x.WorkPlace.NameCompany,15}");
            WriteLine($"Посада працівника:      {x.WorkPlace.PositionWorker,15}");
            WriteLine($"Зарплата працівника:    {x.WorkPlace.SalaryWorker,15}");
            WriteLine("******************************************************************************************************");
            ResetColor();
        }
        static void PrintWorkers(Worker[] array) // конструктор з параметром
        {
            for (int i = 0; i < array.Length; i++)
            {
                ForegroundColor = ConsoleColor.Yellow;
                Write($"Працівник № {i}");
                ResetColor();
                PrintWorker(array[i]);
            }
        }
        static int PrintMenu() // конструктор виводу
        {
            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Red;
            WriteLine("МЕНЮ");
            ResetColor();
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Ввести масив працівників - 1");
            WriteLine("Вивести масив працівників - 2");
            WriteLine("Вийти - 0");
            ResetColor();
            int x; CheckInt(out x, 4);
            return x;
        }

        static void Main(string[] args) // головне меню
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;
            Title = "Лабораторна робота №6";
            SetWindowSize(100, 25);
            WriteLine("Введіть масив працівників:");
            int check;
            Worker[] array;
            array = ReadWorkersArray();
            do
            {
                check = PrintMenu();
                switch (check)
                {
                    case 1:
                        Clear();
                        array = ReadWorkersArray();
                        break;
                    case 2:
                        ForegroundColor = ConsoleColor.Magenta;
                        WriteLine("Вивести усіх працівників - 1");
                        WriteLine("Вивести одного працівника - 2");
                        WriteLine("Вихід - 0");
                        ResetColor();
                        CheckInt(out check, 2);
                        switch (check)
                        {
                            case 1:
                                Clear();
                                PrintWorkers(array);
                                break;
                            case 2:
                                WriteLine("Номер");
                                int x; CheckInt(out x, array.Length - 1);
                                Clear();
                                PrintWorker(array[x]);
                                break;
                            case 0:
                                break;
                        }
                        break;
                }
            } while (check != 0);
        }
    }
}