using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingClosedState : IState
    {
        private float _timeBeforeOpening = 20f;
        private StateMachine _stateMachine;
        private Building _building;
        public BuildingClosedState(StateMachine state_machine, Building building)
        {
            _stateMachine = state_machine;
            _building = building;
        }
        public void Enter()
        {
            Console.WriteLine("Building is closed!");
        }
        public void Exit() { }
        public void Update(float elapsed_time)
        {
           _timeBeforeOpening += elapsed_time;
            if (_timeBeforeOpening <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine, _building));
            }
            _timeBeforeOpening = 20f;
        }
        public void FixedUpdate(float fixed_elapsed_time) { }
        public void ProcessInput(ConsoleKeyInfo input) { }
        public void Render()
        {
            Console.SetCursorPosition((int)_building.GetPosition().GetX(), (int)_building.GetPosition().GetY());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{_building.GetRenderGraphic()}[X{_timeBeforeOpening:F1}X]");
            Console.ResetColor();

        }
    }
}
