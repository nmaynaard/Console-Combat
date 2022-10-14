using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;



namespace consoleCombat.Characters
{
    public class Squirtle : Character
    {
        public Squirtle(string characterName, int health, ConsoleColor color)
             : base(characterName, health, color)
        {

        }
        public override void Attack(Character otherCharacter)
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"{_characterName} attacks {otherCharacter._characterName} and");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 50)
            {
                WriteLine(" hits for 4 damage");
                otherCharacter.TakeDamage(4);
            }
            else
            {
                WriteLine(" misses...");
            }
            ResetColor();
        }

    }

}
