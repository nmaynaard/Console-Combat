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
                WriteLine($"Lv. {MyGame.player._level} {MyGame.player._characterName} feints");
                ReadKey(true);
            }
            else
            {
                MyGame.CurrentEnemy.ResetHealth();
                ForegroundColor = MyGame.CurrentEnemy._color;
                WriteLine($"Lv. {MyGame.CurrentEnemy._level} {MyGame.CurrentEnemy._characterName} feints");
                ResetColor();
                MyGame.player.ExperienceGain();
                ReadKey(true);
            }

            MyGame.townScene.Run();
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