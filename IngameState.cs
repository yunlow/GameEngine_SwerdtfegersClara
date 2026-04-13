using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class IngameState : IState
    {
        private StateMachine _stateMachine;
        private GameEngine _engine;

        public IngameState(
            StateMachine state_machine,
            GameEngine engine
        )
        {
            _stateMachine = state_machine;
            _engine = engine;
        }

        public void Enter()
        {
            Console.WriteLine("Back to the game!");
        }

        public void Exit()
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
            if (input.Key == ConsoleKey.Escape)
            {
                _stateMachine.ChangeState(
                    new PauseState(
                        _stateMachine,
                        _engine
                    )
                );
            }
        }

        public void Render()
        {
            Console.WriteLine(
                "Ingame State: Press Esc to pause"
            );

            Console.WriteLine(
                "========================================================"
            );
        }
    }
}