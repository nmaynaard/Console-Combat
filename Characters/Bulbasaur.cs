using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;



namespace consoleCombat.Characters
{
    public class Bulbasaur : Character
    {
        public Bulbasaur(string characterName, int health, ConsoleColor color)
             : base(characterName, health, color)
        {

        }

        public override void Attack(Character otherCharacter)
        {
            ForegroundColor = _color;
            WriteLine($"{_characterName} attacks {otherCharacter._characterName}");
            ResetColor();
        }
    }

}
