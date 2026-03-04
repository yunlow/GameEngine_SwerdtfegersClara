using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class Building : GameObject
    {
        private Vector2 _position = new Vector2(0, 0);
        private float _elapsedTime = 0f;

        private GameEngine _gameEngine;
        private string _renderGraphic = "B";

        public Building(GameEngine game_engine)
        {
            _gameEngine = game_engine;
            game_engine.AddGameObject(this);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _elapsedTime += fixed_elapsed_time;
        }

        public override void Update(float elapsed_time) { }

        public override void HandleInput(ConsoleKey handle_input) { }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write($"{_renderGraphic}[{_elapsedTime:F1}]");
            
        }
    }
}
