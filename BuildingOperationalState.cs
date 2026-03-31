using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingOperationalState : IState
    {
        private float _totalTime = 30f;
        private StateMachine _stateMachine;
        private Building _building;
        public BuildingOperationalState(StateMachine state_machine, Building building)
        {
            _stateMachine = state_machine;
            _building = building;
        }
        public void Enter()
        {
            Console.WriteLine("Building is now operational!");
        }
        public void Exit() 
        { 

        }

        public void Update(float elapsed_time)
        {
            _totalTime += elapsed_time;
            if (_totalTime <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine, _building));
            }
        }
        public void FixedUpdate(float fixed_elapsed_time)
        {
        }
        public void ProcessInput(ConsoleKeyInfo input) 
        {
        
        }
        public void Render()
        {
            Console.SetCursorPosition((int)_building.GetPosition().GetX(), (int)_building.GetPosition().GetY());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{_building.GetRenderGraphic()}[{_totalTime:F1}]");
            Console.ResetColor();

        }
    }
}
