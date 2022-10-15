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
            for (int i = 0; i < MyGame.enemies.Count; i += 1)
            {
                MyGame.player._characterName = MyGame.accountScene.username;
                MyGame.CurrentEnemy = MyGame.enemies[i];
                Battle();
                if (MyGame.player._isDead)
                {
                    WriteLine("You Died");
                    ReadKey(true);
                    break;
                }
                else
                {
                    WriteLine("You Survived");
                    ReadKey(true);
                }
            }
            MyGame.titleScene.Run();
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
                    break;
                }
                MyGame.CurrentEnemy.Attack(MyGame.player);
                WriteLine();
            }
        }
    }
}