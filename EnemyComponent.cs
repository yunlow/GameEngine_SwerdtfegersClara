using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class EnemyComponent : Component
    {
        private int 
_health;
        public EnemyComponent(GameObject game_object)
            : base(game_object)
        {
        }

        public override void Update(float elapsed_time)
        {
            if (_health <= 0)
            {
                _gameObject.SetActive(false);
            }
        }

        

        public override Component Clone(GameObject parent_game_object)
        {
            return new EnemyComponent(parent_game_object);
        }
    }
}