using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class StateMachine
    {
        private IState _currentState;

        private EventManager _eventManager;

        public StateMachine(EventManager event_manager)
        {
            _eventManager = event_manager;

            _eventManager.RegisterToEvent(EventType.StateChangedGameEvent, () => Console.WriteLine("State changed"));
        }
        public void Update(float elapsed_time)
        {
            if (_currentState != null)
            {
                _currentState.Update(elapsed_time);
            }
        }

        public void FixedUpdate(float fixed_elapsed_time)
        {
            if (_currentState != null)
            {
                _currentState.FixedUpdate(fixed_elapsed_time);
            }
        }

        public void ProcessInput(ConsoleKeyInfo input)
        {
            if (_currentState != null)
            {
                _currentState.ProcessInput(input);
            }
        }
        public void Render()
        {
            if (_currentState != null)
            {
                _currentState.Render();
            }
        }
        public void SetInitialState(IState initial_state)
        {
            _currentState = initial_state;
            _currentState.Enter();
        }
        public void ChangeState(IState new_state) 
        { 
            _eventManager.TriggerEvent(new StateChangedGameEvent(_currentState, new_state));
            _currentState = new_state;

        }

    }
}
