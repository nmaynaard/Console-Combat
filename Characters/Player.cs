using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;


namespace consoleCombat.Characters
{
    public class Player : Character
    {

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
                otherCharacter.TakeDamage(10);
            }
            else
            {
                WriteLine(" misses...");
            }
        }

        public override void Attack(Character otherCharacter)
        {
            ForegroundColor = _color;
            WriteLine($@"You're fighting with {otherCharacter._characterName} and can:
            1) Punch
            2) Kick
            ");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                Punch(otherCharacter);

            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                Kick(otherCharacter);
            }
            else
            {
                Clear();
                WriteLine("Incorrect Syntax");
                WriteLine($@"Example: Press 1/2");
                Attack(otherCharacter);
            }
            ResetColor();
        }
    }

}
