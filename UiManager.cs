using GameEngine_SwerdtfegersLucas.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class UiManager
    {
        private EventManager _eventManager;

        private string _lastMessage = "";
        private ConsoleColor _lastColor = ConsoleColor.White;


        public UiManager(EventManager event_manager)
        {
            _eventManager = event_manager;
            _eventManager.RegisterToEvent<StateChangedGameEvent>(OnStateChanged);
            _eventManager.RegisterToEvent<AchievementGameEvent>(OnAchievement);
        }

        private void OnAchievement(GameEvent game_event)
        {
            
        }

        private void OnStateChanged(GameEvent game_event)
        {
            
        }

        public void Render()
        {
            
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = _lastColor;

            
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);

            Console.WriteLine(_lastMessage);

            Console.ResetColor();
        }
    }
}
