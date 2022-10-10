using System;
using static System.Console;
using consoleCombat.Scenes;
using consoleCombat.Characters;
using consoleCombat.Items;

namespace consoleCombat // Note: actual namespace depends on the project name.
{
    class Game
    {

        public TitleScene titleScene;
        public AccountScene accountScene;
        public CharacterCreationScene characterCreationScene;
        public Player player;
        public Bulbasaur bulbasaur;
        public Charmander charmander;
        public Squirtle squirtle;
        private Item pokeball;

        public Game()
        {
            titleScene = new TitleScene(this);
            accountScene = new AccountScene(this);
            characterCreationScene = new CharacterCreationScene(this);
            player = new Player("Nathan", 20, ConsoleColor.Magenta);
            bulbasaur = new Bulbasaur("Bulbasaur", 10, ConsoleColor.DarkYellow);
            charmander = new Charmander("Charmander", 10, ConsoleColor.Red);
            squirtle = new Squirtle("Squirtle", 10, ConsoleColor.Cyan);
            pokeball = new Item("Pokeball", 10);
        }
        public void Start()
        {
            titleScene.Run();
        }

        public void Test()
        {
            Clear();
            player.PickUpItem(pokeball);
            player.DisplayInfo();
            bulbasaur.DisplayInfo();
            charmander.DisplayInfo();
            squirtle.DisplayInfo();
            ReadKey(true);
        }
    }

}