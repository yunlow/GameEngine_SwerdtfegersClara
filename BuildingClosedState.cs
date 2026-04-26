using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingClosedState : IState
    {
        private float _timeBeforeOpening = 20f;
        private StateMachine _stateMachine;
        private GameObject _building;

        public BuildingClosedState(
            StateMachine state_machine,
            GameObject building
        )
        {
            _stateMachine = state_machine;
            _building = building;
        }

        public void Enter()
        {
            Console.WriteLine("Building is closed!");
            _timeBeforeOpening = 20f;
        }

        public void Exit()
        {
        }

        public void Update(float elapsed_time)
        {
           
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            _timeBeforeOpening -= fixed_elapsed_time;

            if (_timeBeforeOpening <= 0)
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

        public void Render()
        {
            
        }
    }
}