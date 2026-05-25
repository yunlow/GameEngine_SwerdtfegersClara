using GameEngine_SwerdtfegersLucas.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class LogManager

    {
        private EventManager _eventManager;

        

        private const string LOG_FILE = "game_log.txt";

        public LogManager(EventManager event_manager)
        {
            _eventManager = event_manager;
            _eventManager.RegisterToEvent<StateChangedGameEvent>(OnStateChanged);
          
        }

        private void OnStateChanged(GameEvent game_event)
        {
            IState current_state;
            IState next_state;

            StateChangedGameEvent state_changed_game_event = game_event as StateChangedGameEvent;
            current_state = state_changed_game_event.GetCurrentState();
            next_state = state_changed_game_event.GetNextState();

            WriteLog("Changement du state: " + current_state.GetName() + " en : " + next_state.GetName());
        }

       
        public void WriteLog(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            System.IO.File.AppendAllText(LOG_FILE, $"[{timestamp}] {message}\n");
        }

    }
}
