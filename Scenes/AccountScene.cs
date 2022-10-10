using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace consoleCombat.Scenes
{
    class AccountScene : Scene
    {
        public AccountScene(Game game) : base(game)
        {
        }

        private string username;
        private string password;
        private string username1;
        private string password1;
        StreamWriter writer;
        StreamReader reader;

        public void Register()
        {
            Clear();
            Write("Username:");
            username = ReadLine();
            Write("Password:");
            password = ReadLine();

            using (StreamWriter writer = new StreamWriter(File.Create("Login.txt")))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
                writer.Close();
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Account Created");
            ResetColor();

        }

        public void Login()
        {
            Clear();
            Write("Username:");
            username = ReadLine();
            Write("Password:");
            password = ReadLine();

            using (StreamReader reader = new StreamReader(File.Open("Login.txt", FileMode.Open)))
            {
                username1 = reader.ReadLine();
                password1 = reader.ReadLine();
                reader.Close();

                if ((username == username1) && (password == password1))
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Login Successful");
                    Console.ReadKey(true);
                    ResetColor();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Login Failed");
                    Console.ReadKey(true);
                    ResetColor();
                    Login();
                }
            }

        }
    }
}