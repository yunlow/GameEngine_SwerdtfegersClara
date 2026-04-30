using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class EventManager
    {
        private Dictionary<EventType, List<Action>> _eventTypeTable = new Dictionary<EventType, List<Action>>();

        public void RegisterToEvent(EventType event_type, Action action)
        {
            if (!_eventTypeTable.ContainsKey(event_type))
            {
                _eventTypeTable[event_type] = new List<Action>();
            }
            _eventTypeTable[event_type].Add(action);
        }

        public void TriggerEvent(EventType event_type)
        {
            if (_eventTypeTable.ContainsKey(event_type))
            {
                foreach (Action action in _eventTypeTable[event_type])
                {
                    action();
                }
            }
        }
    }
}
