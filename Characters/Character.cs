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
        public string _characterName { get; protected set; }
        public int _health { get; protected set; }
        public int _maxHealth { get; protected set; }
        public ConsoleColor _color { get; protected set; }
        private Item _currentItem { get; set; }
        public int _attack { get; protected set; }
        public int _defense { get; protected set; }
        public bool _isDead { get => _health <= 0; }
        public bool _isAlive { get => _health > 0; }
        public Random randGenerator;


        public Character(string characterName, int health, ConsoleColor color)
        {
            _characterName = characterName;
            _health = health;
            _maxHealth = health;
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

        public virtual void Attack(Character otherCharacter)
        {

        }

        public void TakeDamage(int totalDamage)
        {
            _health -= totalDamage;
            if (_health <= 0)
            {
                _health = 0;
            }
        }

        public void HealthBar()
        {
            ForegroundColor = _color;
            ResetColor();
            WriteLine($" {_characterName}'s Health");
            Write("[");
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < _health; i++)
            {
                Write(" ");
            }
            ResetColor();
            for (int i = _health; i < _maxHealth; i++)
            {
                Write(" ");
            }
            WriteLine($"] ({_health}/{_maxHealth})");
        }

    }
}