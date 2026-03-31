using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class MainMenuState : IState
    {

       
        private GameEngine _engine;

        public MainMenuState(GameEngine _gameEngine)
        {
            _engine = _gameEngine;
        }
        public void Enter()
        {
            Console.Clear();
            Console.WriteLine("Entering game!");
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
                _engine.Quit();
            }

            if (input.Key == ConsoleKey.Enter)
            {
                _engine.StartGame();

            }
        }

        public void Render()
        {
            Console.WriteLine("Press Enter to start the game or Escape to quit.");
        }
    }
}
