using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class FactoryComponent : Component
    {
        private float _productionTimer = 0f;
        private float _productionInterval = 10f;
        private int _energy;
        private int _energyCost = 5;
        private int _ressources = 0;

        private EventManager _eventManager;

        public FactoryComponent(GameObject game_object, EventManager event_manager)
            : base(game_object)
        {
            _eventManager = event_manager;
        }


        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _productionTimer += fixed_elapsed_time;

            if (_productionTimer >= _productionInterval)
            {
                Produce();
                _productionTimer = 0f;
            }
        }
        private void Produce()
        {
            GeneratorComponent generator = _gameObject.GetComponent<GeneratorComponent>();

            if (generator != null && generator.ReturnEnergy() >= _energyCost)
            {
                generator.ConsumeEnergy(_energyCost);  // voir ci-dessous
                _ressources++;
                Console.WriteLine($"[Factory] Production ! Ressources totales : {_ressources}");
            }
            else
            {
                Console.WriteLine("[Factory] Pas assez d'énergie pour produire.");
            }
        }

        public override Component Clone(GameObject parent_game_object)
        {
            return new FactoryComponent(parent_game_object, _eventManager);
        }
    }
}