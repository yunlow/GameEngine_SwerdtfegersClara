using GameEngine_SwerdtfegersLucas.Events;
using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class PauseState : IState
    {
        private StateMachine _stateMachine;
        private GameEngine _gameEngine;
        private EventManager _eventManager;

        public PauseState(
            StateMachine state_machine,
            GameEngine game_engine,
            EventManager event_manager
        )
        {
            _stateMachine = state_machine;
            _gameEngine = game_engine;
            _eventManager = event_manager;

            _eventManager.RegisterToEvent<QuitGameEvent>(OnQuit);
        }

        public string GetName()
        {
            return "PauseState";
        }
        public void Enter()
        {
            Console.WriteLine("Entering Pause Mode!");
        }

        public void Exit()
        {
            Console.WriteLine("Exiting Pause Mode!");
        }

        public void Render()
        {
            Console.WriteLine(
                "Press Enter to resume the game or Q to access the Main Menu."
            );
        }
        public void OnQuit(GameEvent game_event)
        {

            
        }

        public void Update(float elapsed_time)
        {
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Enter)
            {
                _stateMachine.ChangeState(
                    new IngameState(_stateMachine, _gameEngine, _eventManager)
                );
            }

            else if (input.Key == ConsoleKey.Q)
            {
                _stateMachine.ChangeState(
                    new MainMenuState(_gameEngine)
                );
            }
        }
    }
}