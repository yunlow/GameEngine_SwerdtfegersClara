using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Emit;
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

        private IState _currentState;
        private GameEngine _gameEngine;

        private GameObject _playerGameObject;
        private GameObject _levelGameObject;

        private InputComponent _inputComponent;
        public GameEngine()

        {
            Console.CursorVisible = false;
            _stopwatch.Start();

            

            _gameFlowStateMachine.SetInitialState(new MainMenuState(this));
            
        }
        public void StartGame()
        {
            
            _gameObjectTable.Clear();
            _gameObjectToAddTable.Clear();

            _levelGameObject = new GameObject(_gameEngine, "name");
            LevelComponent level_component = new LevelComponent(_levelGameObject, _gameEngine);
            _levelGameObject.AddComponent(level_component);

            _playerGameObject = new GameObject(_gameEngine, "Player");
            PositionComponent position_component = new PositionComponent(new Vector2(5, 5), _playerGameObject);
            _playerGameObject.AddComponent(position_component);

            _playerGameObject.AddComponent(new RenderComponent(_playerGameObject, "@", position_component));
            _playerGameObject.AddComponent(new MovementComponent(_playerGameObject, 50,
position_component, level_component));
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

        public void RegisterInputComponent(InputComponent input_component)
        {
            
        }

        public void ProcessInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo player_command = Console.ReadKey(true);
                _gameFlowStateMachine.ProcessInput(player_command);
               
                if (_inputComponent != null)
                {
                    _inputComponent.HandleInput(player_command);
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

        public virtual void SetActive(bool is_active) 
        {
        
        }
        public void Update(float elapsed_time)
        {
            _gameFlowStateMachine.Update(elapsed_time);
            for (int game_object_index = 0; game_object_index < _gameObjectTable.Count; game_object_index++)
            {
                _gameObjectTable[game_object_index].Update(elapsed_time);
            }

           
        }

        public bool ShouldQuit()
        { 
            return _shouldQuit;
        }
        public void Quit()
        { 
            _shouldQuit = true;
        }
        


        public void Render()
        {
            Console.Clear();
            _gameFlowStateMachine.Render();
            foreach (GameObject game_object in _gameObjectTable)
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
            if (!_gameObjectToAddTable.Contains(game_object) && !_gameObjectTable.Contains(game_object))
            {
                _gameObjectToAddTable.Add(game_object);
            }
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
