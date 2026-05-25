using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas.Events
{
    public class EventManager
    {
        private Dictionary<Type, List<Action<GameEvent>>> _eventTypeTable = new Dictionary<Type, List<Action<GameEvent>>>();

        public void RegisterToEvent<TYPE>(Action<GameEvent> action)
        {
            Type event_type = typeof(TYPE);

            if (!_eventTypeTable.ContainsKey(event_type))
            {
                _eventTypeTable[event_type] = new List<Action<GameEvent>>();
            }
            _eventTypeTable[event_type].Add(action);
        }

        public void TriggerEvent(GameEvent game_event)
        {
            Type event_type = game_event.GetType();

            if (_eventTypeTable.ContainsKey(event_type))
            {
                foreach (Action<GameEvent> action in _eventTypeTable[event_type])
                {
                    action(game_event);
                }
            }
        }
    }
}
