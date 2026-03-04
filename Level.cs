using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Level : GameObject
    {
        private int _width;
        private int _height;
        public Level(GameEngine game_engine, int width, int height)
        {
            _width = width;
            _height = height;

            game_engine.AddGameObject(this);

        }

        public int Width
        { get { return _width; } }
        public int Height
        { get { return _height; } }
        public override void Update(float elapsed_time) { }

        public override void FixedUpdate(float fixed_elapsed_time) { }

        public override void Render() { }

        public override void HandleInput(ConsoleKey player_command) { }

    }
}
