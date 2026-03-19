using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class GameEngine
    {
        private bool _shouldQuit = false;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        

        private List<GameObject> _gameObjectTable = new List<GameObject>();

        private List<GameObject> _gameObjectToAddTable = new List<GameObject>();
        private List<GameObject> _gameObjectToRemoveTable = new List<GameObject>();

        private StateMachine _gameFlowStateMachine = new StateMachine();
        public GameEngine()

        {
            Console.CursorVisible = false;
            _stopwatch.Start();

            Level level = new Level(this, Console.WindowHeight, Console.WindowWidth);

            Player player = new Player(this, level);
           
            

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
                UpdateGameObjectTable();
                last_time = loop_start_time;
            }
        }

        public void ProcessInput()
        {
            foreach (GameObject game_object in _gameObjectTable)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    game_object.HandleInput(keyInfo.Key);
                }
            }
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            foreach(GameObject game_object in _gameObjectTable)
            {
                game_object.FixedUpdate(fixed_elapsed_time);
            }


        }
        
            public void Update(float elapsed_time)
        {
            for(int game_object_index = 0; game_object_index < _gameObjectTable.Count; game_object_index++)
            {
                _gameObjectTable[game_object_index].Update(elapsed_time);
            }

           
        }

        public bool ShouldQuit()
        { return _shouldQuit; }
        public void Quit()
        { _shouldQuit = true; }
        


        public void Render()
        {
            
            foreach(GameObject game_object in _gameObjectTable)
            {
                game_object.Render();
            }

        }

        public float GetCurrentTime()
        {
            return  _stopwatch.ElapsedMilliseconds / 1000.0f; 
        }

        public void AddGameObject(GameObject game_object)
        {
            _gameObjectToAddTable.Add(game_object);
        }

        public void RemoveGameObject(GameObject game_object)
        {
            _gameObjectToRemoveTable.Add(game_object);
        }

        private void UpdateGameObjectTable()
        {
            
            foreach (GameObject game_object in _gameObjectToAddTable)
            {
                _gameObjectTable.Add(game_object);
            }
            _gameObjectToAddTable.Clear();

           
            foreach (GameObject game_object in _gameObjectToRemoveTable)
            {
                _gameObjectTable.Remove(game_object);
            }
            _gameObjectToRemoveTable.Clear();
        }
    }
}
