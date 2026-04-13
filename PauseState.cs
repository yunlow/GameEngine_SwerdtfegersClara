using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class PauseState : IState
    {
        private StateMachine _stateMachine;
        private GameEngine _gameEngine;

        public PauseState(
            StateMachine state_machine,
            GameEngine game_engine
        )
        {
            _stateMachine = state_machine;
            _gameEngine = game_engine;
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
                    new IngameState(_stateMachine, _gameEngine)
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