using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    
    public class IngameState : IState
    {
        
        private StateMachine _stateMachine;
        private GameEngine _engine;

        public IngameState(GameEngine _gameEngine)
        {
            _engine = _gameEngine;
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
                _stateMachine.ChangeState(new PauseState());
            }
        }
        public void Render()
        {
            Console.WriteLine("Ingame State: Press Esc to pause");
            Console.WriteLine("========================================================");
        }
    }
}
