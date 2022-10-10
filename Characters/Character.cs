using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using consoleCombat.Items;

namespace consoleCombat.Characters
{
    public class Character
    {
        protected string _characterName;
        protected int _health;
        protected ConsoleColor _color;
        private Item _currentItem;
        protected int _attack;
        protected int _defense;
        protected bool _isDead;

        public Character(string characterName, int health, ConsoleColor color)
        {
            _characterName = characterName;
            _health = health;
            _color = color;
        }

        public void DisplayInfo()
        {
            BackgroundColor = _color;
            Write(_characterName);
            ResetColor();
            WriteLine($" HP: {_health}");
        }

        public void PickUpItem(Item item)
        {
            _currentItem = item;
        }
    }
}