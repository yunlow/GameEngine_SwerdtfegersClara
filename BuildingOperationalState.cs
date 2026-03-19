using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingOperationalState : IState
    {
        private float TotalTime = 30f;
        private StateMachine _stateMachine;
        public BuildingOperationalState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Enter()
        {
            Console.WriteLine("Building is now operational!");
        }
        public void Exit() { }
        public void Update(float elapsed_time)
        {
            TotalTime += elapsed_time;
            if (TotalTime <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine));
            }
        }
        public void FixedUpdate(float fixed_elapsed_time) { }
        public void ProcessInput(ConsoleKeyInfo input) { }
        public void Render()
        {
            Console.WriteLine("B" + TotalTime);
        }
    }
}
