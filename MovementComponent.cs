using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class MovementComponent : Component
    {
        private float _speed;
        private Vector2 _direction;
        private PositionComponent _positionComponent;
        private LevelComponent _levelComponent;

        public MovementComponent(
            GameObject game_object,
            float speed,
            PositionComponent position_component,
            LevelComponent level_component
        ) : base(game_object)
        {
            _speed = speed;
            _positionComponent = position_component;
            _levelComponent = level_component;
            _direction = new Vector2(0, 0);
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            Vector2 position = _positionComponent.GetPosition();

            float newX =
                position.GetX()
                + _direction.GetX()
                * _speed
                * fixed_elapsed_time;

            float newY =
                position.GetY()
                + _direction.GetY()
                * _speed
                * fixed_elapsed_time;

            if (newX >= 0 && newX < _levelComponent.Width)
                position.SetX(newX);

            if (newY >= 0 && newY < _levelComponent.Height)
                position.SetY(newY);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public override Component Clone(GameObject parent_game_object)
        {
            return new MovementComponent(
                parent_game_object,
                _speed,
                _positionComponent,
                _levelComponent
            );
        }
    }
}