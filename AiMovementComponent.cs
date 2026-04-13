using System;

namespace GameEngine_SwerdtfegersLucas
{
    public class AiMovementComponent : Component
    {
        private Vector2 _direction = new Vector2(0, 0);
        private float _speed = 5f;

        private float _directionTimer = 0f;
        private float _directionChangeInterval = 3f;

        private Random _random = new Random();

        private PositionComponent _positionComponent;
        private LevelComponent _level;

        public AiMovementComponent(
            GameObject game_object,
            PositionComponent position_component,
            LevelComponent level
        ) : base(game_object)
        {
            _positionComponent = position_component;
            _level = level;
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            _directionTimer += fixed_elapsed_time;

            if (_directionTimer >= _directionChangeInterval)
            {
                ChangeDirectionRandom();
                _directionTimer = 0f;
            }

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

            if (newX >= 0 && newX < _level.Width)
                position.SetX(newX);
            else
                _direction.SetX(-_direction.GetX());

            if (newY >= 0 && newY < _level.Height)
                position.SetY(newY);
            else
                _direction.SetY(-_direction.GetY());
        }

        private void ChangeDirectionRandom()
        {
            int direction = _random.Next(4);

            switch (direction)
            {
                case 0: _direction = new Vector2(-1, 0); break;
                case 1: _direction = new Vector2(1, 0); break;
                case 2: _direction = new Vector2(0, -1); break;
                case 3: _direction = new Vector2(0, 1); break;
            }
        }
        public override Component Clone(GameObject parent_game_object)
        {
            return new AiMovementComponent(
                parent_game_object,
                _positionComponent,
                _level
            );
        }
    }
}
//git2