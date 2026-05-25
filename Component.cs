using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public abstract class Component : ICloneable
    {
        private bool _isActive = true;
        protected GameObject _gameObject;

       

        public Component(GameObject game_object)
        {
            _gameObject = game_object;
        }

        public string GetParentName()
        {
            return _gameObject.GetName();
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
        public void OnEnable()
        {
            SetActive(true);
        }

        public void OnDisable()
        {
            SetActive(false);
        }
        public void SetActive(bool is_active)
        {
            _isActive = is_active;
        }
        public void SetGameObject(GameObject game_object)
        {
            _gameObject = game_object;
        }
        public abstract Component Clone(GameObject parent_game_object);

        public object Clone()
        {
           return Clone(_gameObject);
        }
    }
}
