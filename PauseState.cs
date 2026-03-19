using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class PauseState : IState
    {
        public void Enter()
        {
            Console.WriteLine("Entering Pause Mode!");
        }
        public void Exit()
        { Console.WriteLine("Exiting Pause Mode!"); }
        public void Render()
        {
            Console.WriteLine("Press Enter to resume the game or Q to access the Main Menu.");
        }
        public void Update(float elapsed_time)
        { }
        public void FixedUpdate(float fixed_elapsed_time)
        { }
        public void ProcessInput(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Enter)
            {
                Enter();
            }
            else if (input.Key == ConsoleKey.Q)
            {
                Console.WriteLine("Accessing Main Menu!");
            }
        }
    }
}
