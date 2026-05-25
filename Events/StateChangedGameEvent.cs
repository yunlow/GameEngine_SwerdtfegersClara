using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas.Events
{
    public class StateChangedGameEvent : GameEvent
    {
        private IState _currentState;
        private IState _nextState;
        public StateChangedGameEvent(IState current_state, IState next_state)
        {
            _currentState = current_state;
            _nextState = next_state;
        }

        public IState GetCurrentState()
        {
            return _currentState;
        }

        public IState GetNextState()
        {
            return _nextState;
        }
    }
}
