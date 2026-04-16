using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class GeneratorComponent : Component
    {
        private int _energy = 0;
        private float _generationTimer = 0f;
        private float _generationInterval = 5f;

        public GeneratorComponent(GameObject game_object)
            : base(game_object)
        {
        }

        public override void Update(float elapsed_time)
        {
            
        }

       public override void FixedUpdate(float fixed_elapsed_time)
        {
            _generationTimer += fixed_elapsed_time;

            if (_generationTimer >= _generationInterval)
            {

                _generationTimer = 0f;
            }
        }
        

        public override Component Clone(GameObject parent_game_object)
        {
            return new GeneratorComponent(parent_game_object);
        }
    }
}