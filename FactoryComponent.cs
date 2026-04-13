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
            _productionTimer += elapsed_time;

            if (_productionTimer >= _productionInterval)
            {
                Produce();
                _productionTimer = 0f;
            }
        }

        private void Produce()
        {
            Console.WriteLine("Factory produced resources!");
        }

        public override Component Clone(GameObject parent_game_object)
        {
            return new FactoryComponent(parent_game_object);
        }
    }
}