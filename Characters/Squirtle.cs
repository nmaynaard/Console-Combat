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
            randGenerator = new Random();
            _level = randGenerator.Next(1, 50);
            if (_level >= 16)
            {
                _characterName = "Wartortle";
            }
            else if (_level >= 32)
            {
                _characterName = "Blastoise";
            }
        }
        public override void Attack(Character otherCharacter)
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"Lv. {_level} {_characterName} attacks {otherCharacter._characterName} and");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 90)
            {
                WriteLine(" hits for 4 damage");
                otherCharacter.TakeDamage(2);
            }
            else
            {
                WriteLine(" misses...");
            }
            ResetColor();
        }

    }

}
