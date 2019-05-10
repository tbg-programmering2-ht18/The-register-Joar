using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace register
{
    class Program
    {
        static Dictionary<string, string> userPasswDict = new Dictionary<string, string>();
        static Dictionary<string, Animal> userAnimalDict = new Dictionary<string, Animal>();
        static void Main(string[] args)
        {
            userPasswDict.Add("stefan", "123");
            userPasswDict.Add("jimmie", "1337");
            userPasswDict.Add("ulf", "666");
            userPasswDict.Add("jimpasmurf", "7331");

            userAnimalDict.Add("stefan", new Animal("cat", "jonas", "bs", false));
            userAnimalDict.Add("jimmie", new Animal("crocodile", "jens", "argh", false));
            userAnimalDict.Add("ulf", new Animal("dog", "lasse", "woof", false));
            userAnimalDict.Add("jimpasmurf", new Animal("albatross", "kent", "kaa", true));




            bool userLoggedIn = false;
            bool done = false;

            string registredPasswd = "";

            if (!done)
            {
                Console.WriteLine("Enter your Username: ");
                string user = Console.ReadLine();

                bool userExist = userPasswDict.TryGetValue(user, out registredPasswd);
                if (userExist)
                {
                    Console.WriteLine("Enter your Password: ");
                    string passwd = ReadPassword;
                    if (passwd.CompareTo(registredPasswd) == 0)
                    {
                        Console.WriteLine("Welcome {0}! You are now logged in!", user);

                        Animal registredAnimal;
                        bool animalExist = userAnimalDict.TryGetValue(user, out registredAnimal);
                        if (animalExist)
                        {
                            Console.WriteLine("This is your animal:\{0}", registredAnimal.Show());
                        }
                        else
                        {
                            Console.WriteLine("Sorry. There was no animal registred for you.");
                        }
                        Console.WriteLine("Enter any key to log out and exit...");
                        done = true;
                        userLoggedIn = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You entered the wrong password");
                    }

                }
                else
                {
                    Console.WriteLine("The user {0} is not found", user);
                    Console.Write("Try again? (Enter Yes or No): ");
                    string answer = Console.ReadLine();
                    done = (!answer.ToLower().StartsWith("y"));
                }
            }


        }

        private static string ReadPassword()
        {
            string pass = "";
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key == null || key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
                key = Console.ReadKey(true);
            }
            return pass;
            
        }
    }
}
