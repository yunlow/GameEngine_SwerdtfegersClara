using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public interface IState
    {
        
        public void Enter();
        public void Exit();
        public void Update(float elapsed_time);
        public void FixedUpdate(float fixed_elapsed_time);
        public void ProcessInput(ConsoleKeyInfo input);
        public void Render();
    }
}
