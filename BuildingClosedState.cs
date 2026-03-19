using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingClosedState : IState
    {
        private float TimeBeforeOpening = 20f;
        private StateMachine _stateMachine;
        public BuildingClosedState(StateMachine stateMachine)
        {
            _stateMachine = new StateMachine();
        }
        public void Enter()
        {
            Console.WriteLine("Building is closed!");
        }
        public void Exit() { }
        public void Update(float elapsed_time)
        {
           TimeBeforeOpening += elapsed_time;
            if (TimeBeforeOpening <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine));
            }
            TimeBeforeOpening = 20f;
        }
        public void FixedUpdate(float fixed_elapsed_time) { }
        public void ProcessInput(ConsoleKeyInfo input) { }
        public void Render()
        {
            Console.WriteLine("B" + TimeBeforeOpening);
        }
    }
}
