using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public abstract class Component
    {
        private bool _isActive = true;
        private protected GameObject _gameObject;

        public Component(GameObject game_object)
        {
            _gameObject = game_object;
        }

        public virtual void Update(float elapsed_time)
        {

        }
        public virtual void FixedUpdate(float fixed_elapsed_time)
        {

        }

        public bool GetIsActive()
        {
            
                return _isActive;
            
        }
    }
}
