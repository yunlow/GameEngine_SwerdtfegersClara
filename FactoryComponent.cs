using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class FactoryComponent : Component
    {
        private float _productionTimer = 0f;
        private float _productionInterval = 10f;

        public FactoryComponent(GameObject game_object)
            : base(game_object)
        {
        }

        public override void Update(float elapsed_time)
        {
            
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
            FactoryComponent component = _gameObject.GetComponent<FactoryComponent>();

            if (component != null)
            {
                component.Produce();
            }
        }

        public override Component Clone(GameObject parent_game_object)
        {
            return new FactoryComponent(parent_game_object);
        }
    }
}