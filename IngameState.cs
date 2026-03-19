using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class IngameState : IState
    {
        public void Enter()
        {
            Console.WriteLine("Entering Pause Mode!");
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
                Enter();
            }
        }
        public void Render()
        {
            Console.WriteLine("Press Escape to pause the game.");
        }
    }
}
