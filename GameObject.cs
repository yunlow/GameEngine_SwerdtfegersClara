using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public abstract class GameObject
    {
        private GameEngine _gameEngine;
      public GameObject(GameEngine game_engine)
        { 
            _gameEngine = game_engine;
            game_engine.AddGameObject(this);
        }
        
        public abstract void Update(float elapsed_time);
        public abstract void FixedUpdate(float fixed_elapsed_time);

        public abstract void Render();
        public abstract void HandleInput(ConsoleKey player_command);

        public abstract void SetActive(bool is_active);
    }
}
