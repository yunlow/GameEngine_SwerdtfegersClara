using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class BuildingOperationalState : IState
    {
        private float _totalTime = 30f;
        private StateMachine _stateMachine;
        private GameObject _building;

        public BuildingOperationalState(StateMachine state_machine, GameObject building)
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
           
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            _totalTime -= fixed_elapsed_time;

            if (_totalTime <= 0)
            {
                _stateMachine.ChangeState(new BuildingClosedState(_stateMachine, _building));
            }
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
        }
        public void Render() { }

    }
}