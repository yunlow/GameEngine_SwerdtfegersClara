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

        private List<GameObject> _gameObjectTable = new List<GameObject>();
       
        public GameEngine()

        {
            Console.CursorVisible = false;
            _stopwatch.Start();

            Player player = new Player();
            _gameObjectTable.Add(player);

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
            foreach(GameObject player in _gameObjectTable)
            {
                player.FixedUpdate(fixed_elapsed_time);
            }


        }
        
            public void Update(float elapsed_time)
        {
            for(int game_object_index = 0; game_object_index < _gameObjectTable.Count; game_object_index++)
            {
                _gameObjectTable[game_object_index].Update(elapsed_time);
            }

           
        }

        

        public void Render()
        {
            
            foreach(GameObject player in _gameObjectTable)
            {
                player.Render();
            }

        }

        public float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
