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
        public string _characterName { get; set; }
        public int _health { get; protected set; }
        public int _maxHealth { get; protected set; }
        public ConsoleColor _color { get; protected set; }
        private Item _currentItem { get; set; }
        public int _attack { get; protected set; }
        public int _defense { get; protected set; }
        public bool _isDead { get => _health <= 0; }
        public bool _isAlive { get => _health > 0; }
        public int experience { get; private set; }
        private int experienceToNextLevel;
        public int _level { get; set; }
        public Random randGenerator;

        /* 
            Add level and experience to character class
            make fight choose a random enemy from the enemy list 
            make the enemies difficulty change based on its level
            make the enemies level random
            make experience gain be based off of the enemies level
            make the ability to capture an enemy 

        */

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

        public void ResetHealth()
        {
            _health = _maxHealth;
            randGenerator = new Random();
            _level = randGenerator.Next(1, 50);
        }

        public void PickUpItem(Item item)
        {
            _currentItem = item;
        }

        public virtual void Attack(Character otherCharacter)
        {

        }

        public void Heal()
        {
            randGenerator = new Random();
            ForegroundColor = _color;
            Write($"Lv. {_level} {_characterName} Heals and ");
            int randPercent = randGenerator.Next(1, 101);
            if (randPercent <= 40)
            {
                WriteLine("is successful...");
                _health = _maxHealth;
            }
            else
            {
                WriteLine("is unsuccessful...");
            }

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
            WriteLine($"Lv. {_level} {_characterName}'s Health");
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