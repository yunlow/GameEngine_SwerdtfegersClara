using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public abstract class GameObject
    {
        public GameObject(GameObject game_object) { }
        public abstract void Update(float elapsed_time);
        public abstract void FixedUpdate(float fixed_elapsed_time);

        public abstract void Render();
        public abstract void HandleInput(ConsoleKey player_command);
    }
}
