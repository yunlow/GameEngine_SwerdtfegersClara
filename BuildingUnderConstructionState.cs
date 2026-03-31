using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class BuildingUnderConstructionState : IState
    {
        private float _constructionTimeLeft;
        private Building _building;
        private StateMachine _stateMachine;
        public BuildingUnderConstructionState(StateMachine state_machine, Building building, int construction_time)
        {
            _constructionTimeLeft = construction_time;
            _building = building;
            _stateMachine = state_machine;
        }
        public void Enter()
        {
            Console.WriteLine("Building is under construction!");
        }
        public void Update(float elapsed_time)
        {
            if (_constructionTimeLeft <= 0)
            {
                _stateMachine.ChangeState(new BuildingOperationalState(_stateMachine, _building));
            }
        }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            _constructionTimeLeft -= fixed_elapsed_time;
        }
        public void ProcessInput(ConsoleKeyInfo input)
        {
           
        }
        public void Render()
        {
            Console.SetCursorPosition((int)_building.GetPosition().GetX(), (int)_building.GetPosition().GetY());
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{_building.GetRenderGraphic()}[%{_constructionTimeLeft}%]");
            Console.ResetColor();

        }
        public void Exit()
        {

        }
    }
}
