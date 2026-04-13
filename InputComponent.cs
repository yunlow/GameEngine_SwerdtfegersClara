using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class InputComponent : Component
    {
        private GameEngine _gameEngine;
        public InputComponent(GameObject game_object, GameEngine game_engine)  : base(game_object)
       {
            _gameEngine = game_engine;
            _gameEngine.RegisterInputComponent(this);
        }
        public void HandleInput(ConsoleKeyInfo player_command) 
        {
            
        }
        public override Component Clone(GameObject parent_game_object)
        {
            throw new NotImplementedException();
        }
    }
}
