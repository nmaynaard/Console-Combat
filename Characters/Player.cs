using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace consoleCombat.Characters
{
    public class Player : Character
    {
        public Player(string characterName, int health, ConsoleColor color)
             : base(characterName, health, color)
        {

        }
    }

}
