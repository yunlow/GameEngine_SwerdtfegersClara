using GameEngine_SwerdtfegersLucas.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class IndustrialProductionAchievementManager
    {
        private EventManager _eventManager;
        private int _totalResourcesProduced = 0;
        private bool _firstUnlocked = false;
        private bool _tenUnlocked = false;
        private bool _fiftyUnlocked = false;

        public IndustrialProductionAchievementManager(EventManager event_manager)
        {
            _eventManager = event_manager;

            _eventManager.RegisterToEvent<RessourceProducedEvent>(OnResourceProduced);
              
           
        }

        private void OnResourceProduced(GameEvent game_event)
        {
            _totalResourcesProduced++;

            if (!_firstUnlocked && _totalResourcesProduced >= 1)
            {
                _firstUnlocked = true;
                UnlockAchievement("First resource produced: Great!");
            }

            if (!_tenUnlocked && _totalResourcesProduced >= 10)
            {
                _tenUnlocked = true;
                UnlockAchievement("10 resources produced: Productivist!");
            }

            if (!_fiftyUnlocked && _totalResourcesProduced >= 50)
            {
                _fiftyUnlocked = true;
                UnlockAchievement("50 resources produced: Industrialist!");
            }
        }

        private void UnlockAchievement(string message)
        {
            Console.WriteLine($"[Achievement] {message}");
            _eventManager.TriggerEvent(new AchievementGameEvent());
        }
    }


}

