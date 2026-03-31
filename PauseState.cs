using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class PauseState : IState
    {
        private StateMachine _stateMachine;
        private GameEngine _gameEngine;
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
            Console.WriteLine("Press Enter to resume the game or Q to access the Main Menu.");
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
                Enter();
            }
            else if (input.Key == ConsoleKey.Q)
            {
                _stateMachine.ChangeState(new MainMenuState(_gameEngine));
            }
        }
    }
}
