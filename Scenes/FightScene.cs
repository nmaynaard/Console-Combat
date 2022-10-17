using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleCombat.Helpers;
using consoleCombat;
using consoleCombat.Characters;
using static System.Console;

namespace consoleCombat.Scenes
{
    class FightScene : Scene
    {
        public FightScene(Game game) : base(game)
        {
        }

        public override void Run()
        {
            int i;
            Random rand = new Random();
            i = rand.Next(0, MyGame.enemies.Count);
            MyGame.player._characterName = MyGame.accountScene.username;
            MyGame.CurrentEnemy = MyGame.enemies[i];
            Battle();
            if (MyGame.player._isDead)
            {
                MyGame.CurrentEnemy.ResetHealth();
                WriteLine($"{MyGame.player._characterName} died");
                ReadKey(true);
            }
            else
            {
                MyGame.CurrentEnemy.ResetHealth();
                ForegroundColor = MyGame.CurrentEnemy._color;
                WriteLine($"{MyGame.CurrentEnemy._characterName} died");
                ResetColor();
                MyGame.player.ExperienceGain();
                ReadKey(true);
            }

            MyGame.mainGameScene.Run();
        }

        public void Battle()
        {
            Clear();
            while (MyGame.player._isAlive && MyGame.CurrentEnemy._isAlive)
            {
                MyGame.player.HealthBar();
                WriteLine();
                MyGame.CurrentEnemy.HealthBar();
                WriteLine();
                ForegroundColor = MyGame.player._color;
                WriteLine("Hit Any Key To Select Ability");
                MyGame.player.Attack(MyGame.CurrentEnemy);
                if (MyGame.player._isDead || MyGame.CurrentEnemy._isDead)
                {
                    return;
                }
                MyGame.CurrentEnemy.Attack(MyGame.player);
                WriteLine();
            }
        }
    }
}