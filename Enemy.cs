using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Enemy : GameObject
    {
        private Vector2 _position;
        private Vector2 _direction = new Vector2(0, 0);
        private float _speed = 5f;

        private Level _level;
        private Random _random = new Random();

        private float _directionTimer = 0f;
        private float _directionChangeInterval = 3f;

        public Enemy(GameEngine game_engine, Level level, Vector2 start_position)
        {
            _level = level;
            _position = start_position;

            ChangeDirectionRandom();

            game_engine.AddGameObject(this);
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _directionTimer += fixed_elapsed_time;

            if (_directionTimer >= _directionChangeInterval)
            {
                ChangeDirectionRandom();
                _directionTimer = 0f;
            }

            float newX = _position.GetX() + _direction.GetX() * _speed * fixed_elapsed_time;
            float newY = _position.GetY() + _direction.GetY() * _speed * fixed_elapsed_time;


            if (newX < 0 || newX >= _level.Width)
                _direction.SetX(-_direction.GetX());
            else
                _position.SetX(newX);

            if (newY < 0 || newY >= _level.Height)
                _direction.SetY(-_direction.GetY());
            else
                _position.SetY(newY);
        }
        public override void Update(float deltaTime) { }

        public override void Render()
        {
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write("E");
        }

        public override void HandleInput(ConsoleKey handle_input) { }

        private void ChangeDirectionRandom()
        {
            int direction = _random.Next(4);

            switch (direction)
            {
                case 0: _direction = new Vector2(-1, 0); break;
                case 1: _direction = new Vector2(1, 0); break;
                case 2: _direction = new Vector2(0, -1); break;
                case 3: _direction = new Vector2(0, 1); break;
            }
        }
    }
}
        

    
