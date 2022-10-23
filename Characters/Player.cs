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
        public int experience { get; private set; }
        private int experienceToNextLevel;
        public int level { get; private set; }
        public int gold { get; private set; }

        public Player(string characterName, int health, ConsoleColor color)
             : base(characterName, health, color)
        {
            level = 0;
            experience = 0;
            gold = 0;
        }
        public void ExperienceGain()
        {
            experience += 500;
            gold += 100;
            WriteLine("You Gained 500 Experience and 100 Gold");
        }
        private void Punch(Character otherCharacter)
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"Lv. {_level} {_characterName} Punches {otherCharacter._characterName} and");
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
            Write($"Lv. {_level} {_characterName} kicks {otherCharacter._characterName} and");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                WriteLine(" hits for 4 damage");
                otherCharacter.TakeDamage(4);
                ReadKey(true);
            }
            else
            {
                WriteLine(" misses...");
                ReadKey(true);
            }
        }

        public override void Attack(Character otherCharacter)
        {
            ForegroundColor = _color;
            ReadKey(true);
            string prompt = "Abilities:";
            string[] options = { "Punch", "Kick", "Heal" };
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
                case 2:
                    Clear();
                    Heal();
                    break;
            }
            ResetColor();
        }
    }

}
