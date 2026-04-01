using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class PositionComponent : Component
    {
        private Vector2 _position;
        private GameObject _gameObject;
        public PositionComponent(Vector2 position, GameObject game_object)
        { 
        _position = position;
        _gameObject = game_object;
        }
    }
}
