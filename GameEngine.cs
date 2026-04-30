using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameEngine_SwerdtfegersLucas
{
    public class GameEngine
    {
        private bool _shouldQuit = false;

        private readonly Stopwatch _stopwatch =
            new Stopwatch();

        private List<GameObject> _gameObjectTable =
            new List<GameObject>();

        private List<GameObject> _gameObjectToAddTable =
            new List<GameObject>();

        private List<GameObject> _gameObjectToRemoveTable =
            new List<GameObject>();

        private EventManager _eventManager;

        private StateMachine _gameFlowStateMachine =
            new StateMachine(_eventManager);

        private GameObject _playerGameObject;
        private GameObject _levelGameObject;

        private InputComponent _inputComponent;

        private int _width;
        private int _height;

        private EntityDatabase _entityDatabase;
        private UiManager _uiManager;

        private IndustrialProductionAchievementManager _industrialProductionAchievementManager;

        public GameEngine(EventManager event_manager)
        {
            Console.CursorVisible = false;

            _stopwatch.Start();

            _width = Console.WindowWidth;
            _height = Console.WindowHeight;

            _entityDatabase = new EntityDatabase();

            _gameFlowStateMachine.SetInitialState(
                new MainMenuState(this)
            );

            _eventManager = event_manager;

            _industrialProductionAchievementManager =
                new IndustrialProductionAchievementManager(_eventManager);

            _uiManager = new UiManager(_eventManager);
        }

        public void StartGame()
        {
            _gameObjectTable.Clear();
            _gameObjectToAddTable.Clear();



            _width = Console.WindowWidth;
            _height = Console.WindowHeight;

            _levelGameObject =
                new GameObject(this, "Level");

            LevelComponent levelComponent =
                new LevelComponent(
                    _levelGameObject,
                    this,
                    _entityDatabase,
                    _width,
                    _height
                );

            _levelGameObject.AddComponent(
                levelComponent
            );

            _playerGameObject =
                new GameObject(this, "Player");

            PositionComponent position =
                new PositionComponent(
                    new Vector2(
                        _width / 2,
                        _height / 2
                    ),
                    _playerGameObject
                );

            _playerGameObject.AddComponent(position);

            RenderComponent render =
                new RenderComponent(
                    _playerGameObject,
                    "@",
                    position,
                    ConsoleColor.Green
                );

            _playerGameObject.AddComponent(render);

            MovementComponent movement =
                new MovementComponent(
                    _playerGameObject,
                    20f,
                    position,
                    levelComponent
                );

            _playerGameObject.AddComponent(
                movement
            );

            InputComponent input =
                new InputComponent(
                    _playerGameObject,
                    this
                );

            _playerGameObject.AddComponent(
                input
            );
            AddGameObject(_playerGameObject);
            _gameFlowStateMachine.ChangeState(
                new IngameState(_gameFlowStateMachine, this)
            );
        }

        public void Run()
        {


            const float FIXED_FRAME_TIME =
                20 / 1000.0f;

            float lag = 0.0f;

            float last_time =
                GetCurrentTime();

            while (!_shouldQuit)
            {
                float loop_start_time =
                    GetCurrentTime();

                float elapsed_time =
                    loop_start_time
                    - last_time;

                lag += elapsed_time;

                ProcessInput();

                while (lag >= FIXED_FRAME_TIME)
                {
                    FixedUpdate(
                        FIXED_FRAME_TIME
                    );

                    lag -= FIXED_FRAME_TIME;
                }

                Update(elapsed_time);

                Render();

                UpdateGameObjectTable();

                last_time = loop_start_time;
            }
        }

        public void RegisterInputComponent(
            InputComponent input_component
        )
        {
            _inputComponent =
                input_component;
        }

        public void ProcessInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo player_command =
                    Console.ReadKey(true);

                _gameFlowStateMachine
                    .ProcessInput(
                        player_command
                    );

                if (_inputComponent != null)
                {
                    _inputComponent
                        .HandleInput(
                            player_command
                        );
                }
            }
        }

        public void FixedUpdate(
            float fixed_elapsed_time
        )
        {
            foreach (
                GameObject game_object
                in _gameObjectTable
            )
            {
                game_object.FixedUpdate(
                    fixed_elapsed_time
                );
            }

            _gameFlowStateMachine
                .FixedUpdate(
                    fixed_elapsed_time
                );
        }

        public void Update(float elapsed_time)
        {
            _gameFlowStateMachine
                .Update(elapsed_time);

            foreach (
                GameObject game_object
                in _gameObjectTable
            )
            {
                game_object.Update(
                    elapsed_time
                );
            }
        }

        public void Render()
        {
            Console.Clear();

            _uiManager.Render();

            _gameFlowStateMachine.Render();


        }

        public float GetCurrentTime()
        {
            return
                _stopwatch
                .ElapsedMilliseconds
                / 1000.0f;
        }

        public bool ShouldQuit()
        {
            return _shouldQuit;
        }

        public void Quit()
        {
            _shouldQuit = true;
        }

        public void AddGameObject(
            GameObject game_object
        )
        {
            if (
                !_gameObjectToAddTable
                    .Contains(game_object)
                &&
                !_gameObjectTable
                    .Contains(game_object)
            )
            {
                _gameObjectToAddTable
                    .Add(game_object);
            }
        }

        public void RemoveGameObject(
            GameObject game_object
        )
        {
            _gameObjectToRemoveTable
                .Add(game_object);
        }

        private void UpdateGameObjectTable()
        {
            foreach (
                GameObject game_object
                in _gameObjectToAddTable
            )
            {
                _gameObjectTable
                    .Add(game_object);
            }

            _gameObjectToAddTable.Clear();

            foreach (
                GameObject game_object
                in _gameObjectToRemoveTable
            )
            {
                _gameObjectTable
                    .Remove(game_object);
            }

            _gameObjectToRemoveTable.Clear();
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }
    }
}