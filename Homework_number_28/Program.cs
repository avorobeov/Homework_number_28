using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_number_28
{
    class Program
    {
        static void Main(string[] args)
        {
            const string СommandAddUser = "Add";
            const string CommandPrint = "Print";
            const string CommandDelete = "Delete";
            const string CommandLastNameSearch = "Last name search";
            const string CommandExit = "Exit";

            bool isExit = false;
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine("Меню\n" +
                            "\nДоступные команды\n\n" +
                            $"1) Добавить досье для использования команды ведите {СommandAddUser}\n\n" +
                            $"2) Вывод досье для использования команды ведите {CommandPrint}\n\n" +
                            $"3) Удалить досье для использования команды ведите {CommandDelete}\n\n" +
                            $"4) Поиск по фамилии для использования команды ведите {CommandLastNameSearch}\n\n" +
                            $"5) Выход для использования команды ведите {CommandExit}\n\n" +
                            $"Укажите команду: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case СommandAddUser:
                        AddDossier(ref fullNames, ref positions);
                        break;

                    case CommandPrint:
                        PrintDossiers(fullNames, positions);
                        break;

                    case CommandDelete:
                        DeleteFromDatabase(ref fullNames, ref positions);
                        break;

                    case CommandLastNameSearch:
                        FindBySurname(fullNames, positions);
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }
            }
        }

        private static void AddDossier(ref string[] fullNames, ref string[] positions)
        {
            Console.WriteLine("Укажите Ф.И.О для добавления в базу даных: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Укажите должность для добавления в базу даных: ");
            string position = Console.ReadLine();

            fullNames = ExpandArray(fullNames, fullName);
            positions = ExpandArray(positions, position);

            Console.WriteLine("Данные пользователя успешно добавлены!");
        }

        private static void PrintDossiers(string[] fullNames, string[] positions)
        {
            if (fullNames.Length > 0)
            {
                for (int i = 0; i < fullNames.Length; i++)
                {
                    Console.WriteLine($"№{i}) {fullNames[i]} - {positions[i]}");
                }
            }
            else
            {
                Console.WriteLine("К сожалению ни одного элемента в базе нет ");
            }
        }

        private static void DeleteFromDatabase(ref string[] fullNames, ref string[] positions)
        {
            Console.WriteLine("Укажите индекс досье для удаления из базы данных: ");
            int indexDossier = Convert.ToInt32(Console.ReadLine());

            if (indexDossier < fullNames.Length && indexDossier < positions.Length)
            {
                fullNames = ReducingArray(fullNames, indexDossier);
                positions = ReducingArray(positions, indexDossier);

                Console.WriteLine("Пользователь успешно удалён!");
            }
            else
            {
                Console.WriteLine("Пользователя под таким индексом нет");
            }
        }

        private static void FindBySurname(string[] fullNames, string[] positions)
        {
            bool isFound = false;
            char separator = ' ';
            int maxNumberWordsLine = 3;
            int sequenceNumberSurname = 0;
            string surname;

            Console.WriteLine("Укажите фамилию для поиска в базе: ");
            surname = Console.ReadLine();

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] user = fullNames[i].Split(separator);

                if (user.Length == maxNumberWordsLine)
                {
                    if (user[sequenceNumberSurname] == surname)
                    {
                        Console.WriteLine($"№{i}) {fullNames[i]} - {positions[i]}");
                        isFound = true;
                    }
                }
            }

            if (isFound == false)
            {
                Console.WriteLine($"Пользователя с фамилией {surname} нет в списке");
            }
        }

        private static string[] ExpandArray(string[] array, string value)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array[array.Length - 1] = value;

            return tempArray;
        }

        private static string[] ReducingArray(string[] array, int indexDossier)
        {
            string[] tempArray = new string[array.Length - 1];
            int lastIndex = array.Length - 1;

            for (int i = 0; i < indexDossier; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = indexDossier; i < lastIndex; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
            return array;
        }
    }
}
