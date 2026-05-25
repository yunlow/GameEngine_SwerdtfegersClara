using System;

namespace GameEngine_SwerdtfegersLucas
{
    internal class BuildingUnderConstructionState : IState
    {
        private float _constructionTimeLeft;
        private StateMachine _stateMachine;
        private GameObject _building;

        public BuildingUnderConstructionState(
            StateMachine state_machine,
            GameObject building,
            int construction_time
        )
        {
            _constructionTimeLeft = construction_time;
            _stateMachine = state_machine;
            _building = building;
        }

        public void Enter()
        {
            Console.WriteLine("Building is under construction!");
        }
        public string GetName()
        {
            return "BuildingUnderConstructionState";
        }
        public void Exit()
        {
        }

        public void Update(float elapsed_time)
        {
           
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            _constructionTimeLeft -= fixed_elapsed_time;

            if (_constructionTimeLeft <= 0)
            {
                _stateMachine.ChangeState(
                    new BuildingOperationalState(
                        _stateMachine,
                        _building
                    )
                );
            }
        }
        public void ProcessInput(ConsoleKeyInfo input)
        {
        }
        public void Render() { }

    }
}