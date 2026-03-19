using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class BuildingUnderConstructionState : IState
    {
        private float ConstructionTimeLeft;
        private Building _building;
        private StateMachine _stateMachine;
        public BuildingUnderConstructionState(Building building, int construction_time)
            {
            ConstructionTimeLeft = construction_time;
            _building = building;
        }
        public void Enter()
        {
            Console.WriteLine("Building is under construction!");
        }
        public void Update(float elapsed_time)
        {
            

            if (ConstructionTimeLeft <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine));
            }
        }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            ConstructionTimeLeft -= fixed_elapsed_time;
        }
        public void ProcessInput(ConsoleKeyInfo input)
        {
           
        }
        public void Render()
        {
            Console.WriteLine("B" + ConstructionTimeLeft);
        }
        public void Exit()
        {

        }
    }
}
