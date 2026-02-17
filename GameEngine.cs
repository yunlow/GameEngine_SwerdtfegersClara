using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class GameEngine
    {
        private bool _shouldQuit = false;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private Player _player;

        public GameEngine()

        {
            _player = new Player();
            _stopwatch.Start();
        }
        public void Run()
        {
            const float FIXED_FRAME_TIME = 20 / 1000.0f;
            float lag = 0.0f;
            float last_time = GetCurrentTime();
            while (!_shouldQuit)
            {
                float loop_start_time = GetCurrentTime();
                float elapsed_time = loop_start_time - last_time;
                lag += elapsed_time;
                ProcessInput();
                while (lag >= FIXED_FRAME_TIME)
                {
                    FixedUpdate(FIXED_FRAME_TIME);
                    lag -= FIXED_FRAME_TIME;
                }
                Update(elapsed_time);
                Render();
                last_time = loop_start_time;
            }
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                Vector2 new_direction = new Vector2(0, 0);

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        new_direction.SetY(-1); 
                        break;
                    case ConsoleKey.DownArrow:
                        new_direction.SetY(1); 
                        break;
                    case ConsoleKey.LeftArrow:
                        new_direction.SetX(-1); 
                        break;
                    case ConsoleKey.RightArrow:
                        new_direction.SetX(1);  
                        break;
                    
                }
                _player.SetDirection(new_direction);


            }
            }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            Vector2 player_position = _player.GetPosition();
            Vector2 player_direction = _player.GetDirection();

            float _playerSpeed = _player.GetSpeed();

            Vector2 new_position = new Vector2();

            new_position.SetX(player_position.GetX() + player_direction.GetX() * fixed_elapsed_time * _playerSpeed);
            new_position.SetY(player_position.GetY() + player_direction.GetY() * fixed_elapsed_time * _playerSpeed);

            _player.SetPosition(new_position);


        }
        public void Update(float elapsed_time)

        {
            Vector2 pos = _player.GetPosition();
            pos.SetX(Math.Clamp(pos.GetX(), 0, Console.WindowHeight - 1));
            pos.SetY(Math.Clamp(pos.GetY(), 0, Console.WindowWidth - 1));

            _player.SetPosition(pos);

        }

        public void Render()
        {
            _player.Render();

        }

        public float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
