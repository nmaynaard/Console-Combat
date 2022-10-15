using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using consoleCombat.Helpers;
using consoleCombat.Scenes;


namespace consoleCombat.Characters
{
    public class Player : Character
    {
        public string username;
        private int balance;
        private int experience;
        private int experienceToNextLevel;
        private int level;

        public Player(string characterName, int health, ConsoleColor color)
             : base(characterName, health, color)
        {

        }

        private void Punch(Character otherCharacter)
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"{_characterName} Punches {otherCharacter._characterName} and");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                WriteLine(" hits for 4 damage");
                otherCharacter.TakeDamage(4);
            }
            else
            {
                WriteLine(" misses...");
            }

        }

        private void Kick(Character otherCharacter)
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"{_characterName} kicks {otherCharacter._characterName} and");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                WriteLine(" hits for 4 damage");
                otherCharacter.TakeDamage(4);
                HealthBar();
            }
            else
            {
                WriteLine(" misses...");
            }
        }

        public override void Attack(Character otherCharacter)
        {
            ForegroundColor = _color;
            ReadKey(true);
            string prompt = "Abilities:";
            string[] options = { "Punch", "Kick" };
            Menu createAbilityMenu = new Menu(prompt, options);
            int selectedIndex = createAbilityMenu.Run();
            otherCharacter.HealthBar();

            switch (selectedIndex)
            {
                case 0:
                    Clear();
                    Punch(otherCharacter);
                    break;
                case 1:
                    Clear();
                    Kick(otherCharacter);
                    break;
            }
            //Punch(otherCharacter);
            //Kick(otherCharacter);
            ResetColor();
        }
    }

}
