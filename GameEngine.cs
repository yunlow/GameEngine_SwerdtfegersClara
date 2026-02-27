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
        private Player player;

        public GameEngine()

        {
            Console.CursorVisible = false;
            player = new Player();
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
                        new_direction.SetX(-1); 
                        break;
                    case ConsoleKey.DownArrow:
                        new_direction.SetX(1); 
                        break;
                    case ConsoleKey.LeftArrow:
                        new_direction.SetY(-1); 
                        break;
                    case ConsoleKey.RightArrow:
                        new_direction.SetY(1);  
                        break;
                    
                }
                player.SetDirection(new_direction);


            }
            }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            Vector2 player_position = player.GetPosition();
            Vector2 player_direction = player.GetDirection();

            float player_speed = player.GetSpeed();

            Vector2 new_position = new Vector2();

            new_position.SetX(player_position.GetX() + player_direction.GetX() * fixed_elapsed_time * player_speed);
            new_position.SetY(player_position.GetY() + player_direction.GetY() * fixed_elapsed_time * player_speed);

            player.SetPosition(new_position);


        }
        
            public void Update(float elapsed_time)
        {
            Vector2 position = player.GetPosition();
            Vector2 direction = player.GetDirection();

            float new_x = position.GetX() + direction.GetX();
            float new_y = position.GetY() + direction.GetY();

            if (new_x < 0 || new_x >= Console.WindowHeight)
            {
                new_x = Math.Clamp(new_x, 0, Console.WindowHeight - 1);
            }
            if (new_y < 0 || new_y >= Console.WindowWidth)
            {
                new_y = Math.Clamp(new_y, 0, Console.WindowWidth - 1);
            }

            position.SetX(new_x);
            position.SetY(new_y);
            player.SetPosition(position);

            player.SetDirection(new Vector2(0, 0));
        }

        

        public void Render()
        {
            player.Render();

        }

        public float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
