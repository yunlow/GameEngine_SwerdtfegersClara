using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class PositionComponent : Component
    {
        private Vector2 _position;

        public PositionComponent(Vector2 position, GameObject game_object) : base(game_object)
        {
            _position = position;
            _gameObject = game_object;
        }
        public Vector2 GetPosition()
        {
            return _position;
        }
        public void SetPosition(Vector2 position)
        { 
        _position = position;
        }
        public override Component Clone(GameObject parent_game_object)
        {
            Vector2 cloned_position = new Vector2(
               _position.GetX(),
               _position.GetY());
            return new PositionComponent(cloned_position, parent_game_object);
        }
    }
}
