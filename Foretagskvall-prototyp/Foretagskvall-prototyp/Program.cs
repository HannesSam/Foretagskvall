using System;
using System.Collections.Generic;
using System.Linq;
using HungarianAlgorithm;
using HungarianAlgorithm.Extensions;

namespace Foretagskvall_prototyp
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsers = 100;
            int[,] costs = new int[100, 100];
            User[] users = GenerateUsers(numberOfUsers);
         
            for (int i = 0; i < numberOfUsers; i++)
            {

                Console.WriteLine(i);
                Console.WriteLine(users[i].Email);
                Console.WriteLine(users[i].Picks[0]);
                Console.WriteLine(users[i].Picks[1]);
                Console.WriteLine(users[i].Picks[2]);
                Console.WriteLine(users[i].Picks[3]);
                Console.WriteLine();

                for (int y = 0; y < 20; y++)
                {
                    costs[i, y] = GetValue((users[i].Picks[0]));
                }

                for (int y = 20; y < 40; y++)
                {
                    costs[i, y] = GetValue((users[i].Picks[1]));
                }

                for (int y = 40; y < 60; y++)
                {
                    costs[i, y] = GetValue((users[i].Picks[2]));
                }

                for (int y = 60; y < 81; y++)
                {
                    costs[i, 3] = GetValue((users[i].Picks[3]));
                }
            }
            
            //int[,] squared = costs.SquareArray(costs);
            int[] result = HungarianAlgorithm.HungarianAlgorithm.FindAssignments(costs);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int GetValue(int pick)
        {
            int value = 0;
            switch (pick)
            {
                case 1:
                    value = 0;
                    break;
                case 2:
                    value = 10;
                    break;
                case 3:
                    value = 50;
                    break;
                case 4:
                    value = 100;
                    break;
                default:
                    break;
            }
            return value;
        }

        static User[] GenerateUsers(int numberOfUsers)
        {
            User[] users = new User[numberOfUsers];
            for (int i = 0; i < numberOfUsers; i++)
            {
                Random rnd = new Random();
                int[] picks = Enumerable.Range(1, 4).OrderBy(c => rnd.Next()).ToArray();
                string email = EmailAddress(10);
                User user = new User(email, picks);
                users[i] = user;
            }
            return users;
        }

        static string EmailAddress(int numberOfCharacters) // pass the number of characters for your email to be generated before '@'
        {
            var characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            var emailAddress = new string(Enumerable.Repeat(characters, numberOfCharacters).Select(s => s[random.Next(s.Length)]).ToArray());
            emailAddress = emailAddress + "@test123.com";
            return emailAddress;
        }
    }
}
