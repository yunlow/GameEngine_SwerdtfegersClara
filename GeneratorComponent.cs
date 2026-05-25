using GameEngine_SwerdtfegersLucas.Events;
using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class GeneratorComponent : Component
    {
        private int _energy = 0;
        private float _generationTimer = 0f;
        private float _generationInterval = 5f;
        private int _energyPerProduction = 10;

        private EventManager _eventManager;

        public GeneratorComponent(GameObject game_object, EventManager event_manager)
            : base(game_object)
        {
            _eventManager = event_manager;
        }

        public override void Update(float elapsed_time)
        {
            
        }

        public int ReturnEnergy()
        {
            return _energy;
        }

        public void ConsumeEnergy(int amount)
        {
            _energy -= amount;
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _generationTimer += fixed_elapsed_time;

            if (_generationTimer >= _generationInterval)
            {
                _energy += _energyPerProduction;
                Console.WriteLine($"[Generator] Generated energy: +{_energyPerProduction} (Total: {_energy})");
                
                _generationTimer = 0f;
            }
        }
        

        public override Component Clone(GameObject parent_game_object)
        {
            return new GeneratorComponent(parent_game_object, _eventManager);
        }
    }
}