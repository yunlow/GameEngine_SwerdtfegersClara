using GameEngine_SwerdtfegersLucas.Events;
using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class IngameState : IState
    {
        private StateMachine _stateMachine;
        private GameEngine _engine;
        private EventManager _eventManager;
        public IngameState(
            StateMachine state_machine,
            GameEngine engine,
            EventManager event_manager
        )
        {
            _stateMachine = state_machine;
            _engine = engine;
            _eventManager = event_manager;
        }

        public string GetName()
        {
            return "IngameState";
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
                        _engine,
                        _eventManager
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