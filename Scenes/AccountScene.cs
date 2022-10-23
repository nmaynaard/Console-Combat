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

        public string username { get; private set; }
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
            if (username.Length <= 1)
            {
                WriteLine("Username must be at least 2 characters!");
                ReadKey(true);
                Register();
            }
            Write("Password:");
            password = ReadLine();
            if (password.Length <= 5)
            {
                WriteLine("Password must be at least 6 characters!");
                ReadKey(true);
                Register();
            }

            using (writer = new StreamWriter(File.Create(username + ".txt")))
            {
                writer.WriteLine(username);
                writer.WriteLine(password);
                writer.Close();
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Account Created");
            ResetColor();
            ReadKey(true);
            MyGame.townScene.Run();
        }

        public void Login()
        {
            Clear();
            Write("Username:");
            username = ReadLine();
            Write("Password:");
            password = ReadLine();

            using (StreamReader reader = new StreamReader(File.Open(username + ".txt", FileMode.Open)))
            {
                username1 = reader.ReadLine();
                password1 = reader.ReadLine();
                reader.Close();

                if ((username == username1) && (password == password1))
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("Login Successful");
                    ReadKey(true);
                    ResetColor();
                    MyGame.townScene.Run();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Login Failed");
                    ReadKey(true);
                    ResetColor();
                    MyGame.titleScene.Run();
                }
            }

        }
    }
}