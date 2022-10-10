using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consoleCombat.Helpers;

namespace consoleCombat.Scenes
{
    class CharacterCreationScene : Scene
    {
        public CharacterCreationScene(Game game) : base(game)
        {
        }

        public override void Run()
        {

            string prompt = "CHARACTER CREATION";
            string[] options = { "   New Character", "   Load Character", "   Back" };
            Menu createCharacterMenu = new Menu(prompt, options);
            int selectedIndex = createCharacterMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }
        }
    }






}