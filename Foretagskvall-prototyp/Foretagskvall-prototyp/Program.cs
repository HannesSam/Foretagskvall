using System;
using System.Linq;

namespace Foretagskvall_prototyp
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = GenerateUsers(70);
            foreach (User item in users)
            {
                Console.WriteLine(item.Email);
                Console.WriteLine(item.Picks[0]);
                Console.WriteLine(item.Picks[1]);
                Console.WriteLine(item.Picks[2]);
                Console.WriteLine(item.Picks[3]);
                Console.WriteLine();
            }
            Console.ReadLine();
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
