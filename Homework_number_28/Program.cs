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
            string[] userDetails = new string[0];
            string[] positions = new string[0];
            string userInput;
            string userDossier;
            string position;

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
                        Console.WriteLine("Укажите Ф.И.О для добавления в базу даных: ");
                        userDossier = Console.ReadLine();

                        Console.WriteLine("Укажите должность для добавления в базу даных: ");
                        position = Console.ReadLine();

                        AddDossier(userDossier, position, ref userDetails, ref positions);

                        Console.WriteLine("Данные пользователя успешно добавлены!");
                        break;

                    case CommandPrint:
                        PrintDossiers(userDetails, positions);
                        break;

                    case CommandDelete:
                        Console.WriteLine("Укажите Ф.И.О для удаление из базы данных: ");
                        userDossier = Console.ReadLine();

                        DeleteFromDatabase(ref userDetails, ref positions, userDossier);
                        break;

                    case CommandLastNameSearch:
                        string surname;

                        Console.WriteLine("Укажите фамилию для поиска в базе: ");
                        surname = Console.ReadLine();

                        FindBySurname(userDetails, positions, surname);
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

        private static void AddDossier(string userDetail, string position, ref string[] userDetails, ref string[] positions)
        {
            string[] tempUserDetails = new string[userDetails.Length + 1];
            string[] tempPositions = new string[userDetails.Length + 1];

            for (int i = 0; i < userDetails.Length; i++)
            {
                tempUserDetails[i] = userDetails[i];
                tempPositions[i] = positions[i];
            }

            userDetails = tempUserDetails;
            positions = tempPositions;

            userDetails[userDetails.Length - 1] = userDetail;
            positions[positions.Length - 1] = position;
        }

        private static void PrintDossiers(string[] userDetails, string[] positions)
        {
            if (userDetails.Length > 0)
            {
                for (int i = 0; i < userDetails.Length; i++)
                {
                    Console.WriteLine($"№{i}) {userDetails[i]} - {positions[i]}");
                }
            }
            else
            {
                Console.WriteLine("К сожалению ни одного элемента в базе нет ");
            }
        }

        private static void PrintDossiers(string[] userDetails, string[] positions, int indexDossier)
        {
            if (userDetails.Length >= indexDossier)
            {
                for (int i = 0; i < userDetails.Length; i++)
                {
                    if (i == indexDossier)
                    {
                        Console.WriteLine($"№{i}) {userDetails[i]} - {positions[i]}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("К сожалению ни одного элемента в базе нет ");
            }
        }

        private static void DeleteFromDatabase(ref string[] userDetails, ref string[] positions, string userDetail)
        {
            bool isDelete = false;
            string[] tempUserDetails = new string[userDetails.Length - 1];
            string[] tempPositions = new string[userDetails.Length - 1];

            for (int i = 0; i < userDetails.Length; i++)
            {
                if (userDetails[i].ToLower() != userDetail.ToLower() && isDelete == false)
                {
                    tempUserDetails[i] = userDetails[i];
                    tempPositions[i] = positions[i];
                }
                else if (userDetails[i].ToLower() != userDetail.ToLower() && isDelete == true)
                {
                    tempUserDetails[i - 1] = userDetails[i];
                    tempPositions[i - 1] = positions[i];
                }
                else
                {
                    isDelete = true;
                }
            }

            userDetails = tempUserDetails;
            positions = tempPositions;

            if (isDelete == true)
            {
                Console.WriteLine("Пользователь успешно удалён!");
            }
            else
            {
                Console.WriteLine("Такого пользователя нет");
            }
        }

        private static void FindBySurname(string[] userDetails, string[] positions, string surname)
        {
            bool isFound = false;
            char separator = ' ';
            int maxNumberWordsLine = 3;
            int sequenceNumberSurname = 0;

            for (int i = 0; i < userDetails.Length; i++)
            {
                string[] user = userDetails[i].Split(separator);

                if (user.Length == maxNumberWordsLine)
                {
                    if (user[sequenceNumberSurname] == surname)
                    {
                        PrintDossiers(userDetails, positions, i);
                        isFound = true;
                        break;
                    }
                }
            }

            if (isFound == false)
            {
                Console.WriteLine($"Пользователя с фамилией {surname} нет в списке");
            }
        }
    }
}
