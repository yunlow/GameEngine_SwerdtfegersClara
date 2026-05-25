using GameEngine_SwerdtfegersLucas.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class MovementAchievementManager
    {
        private EventManager _eventManager;
        public MovementAchievementManager(EventManager event_manager)
        { 
        _eventManager = event_manager;

            _eventManager.RegisterToEvent<PlayerMovedGameEvent>(OnPlayerMoved);
        }

        private void OnPlayerMoved(GameEvent game_event)
        { }
    }
}
