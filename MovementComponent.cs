using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class MovementComponent : Component
    {
        private float _speed;
        private Vector2 _direction;
        private PositionComponent _positionComponent;
        private LevelComponent _levelComponent;
        private GameObject _gameObject;
        public MovementComponent(GameObject game_object, float speed, PositionComponent position_component, LevelComponent level_component)
        {
            _speed = speed;
            _gameObject = game_object;
            _positionComponent = position_component;
            _levelComponent = level_component;
        }
    }
}
