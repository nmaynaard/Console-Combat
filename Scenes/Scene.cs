using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace consoleCombat.Scenes
{
    class Scene
    {

        public Game MyGame;
        public Scene(Game game)
        {
            MyGame = game;
        }

        virtual public void Run()
        {

        }
    }
}
