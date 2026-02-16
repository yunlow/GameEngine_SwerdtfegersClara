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
            Vector2 player_position = new Vector2(0, 0);
            switch (Console.ReadKey(true).Key)

            {
                case ConsoleKey.LeftArrow:
                    player_position.SetX(-1);

                    break;



                case ConsoleKey.RightArrow:
                    player_position.SetX(1);

                    break;




                case ConsoleKey.UpArrow:
                    player_position.SetY(-1);

                    break;




                case ConsoleKey.DownArrow:
                    player_position.SetY(1);

                    break;
            }


            
        }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            Vector2 player_position = _player.GetPosition();
            Vector2 player_direction = _player.GetDirection();

            float speed = _player.GetSpeed();

            Vector2 new_position = new Vector2(player_position.GetX() + player_direction.GetX() * speed * fixed_elapsed_time,

                player_position.GetY() + player_direction.GetY() * speed * fixed_elapsed_time
);

            _player.SetPosition(new_position);


        }
        public void Update(float elapsed_time)
        {

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
