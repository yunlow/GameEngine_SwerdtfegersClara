using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Player : GameObject
    {
        private Vector2 _position = new Vector2(5, 5);
        private Vector2 _direction = new Vector2(0, 0);

        private string _renderGraphic = "@";
        private float speed = 10f;

        public override void Render()
        {
            Console.Clear();
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write(_renderGraphic);
        }

        public void SetDirection(Vector2 new_direction)
        {
            _direction = new_direction;
        }

        public Vector2 GetDirection()

        {
            return _direction;
    }



        public Vector2 GetPosition()
        {
            return _position;
        }

        public void SetPosition(Vector2 new_position)

        {
         _position = new_position;
         }

        public float GetSpeed()

        {
           return speed;
        }

        public override void FixedUpdate(float fixedDeltaTime)
        {
           
            float newX = _position.GetX() + _direction.GetX() * fixedDeltaTime * speed;
            float newY = _position.GetY() + _direction.GetY() * fixedDeltaTime * speed;

            _position.SetX(newX);
            _position.SetY(newY);
        }

        public override void Update(float deltaTime)
        {
             
            float x = Math.Clamp(_position.GetX(), 0, Console.WindowHeight - 1);
            float y = Math.Clamp(_position.GetY(), 0, Console.WindowWidth - 1);

            _position.SetX(x);
            _position.SetY(y);

            
            _direction = new Vector2(0, 0);
        }

        


    }
}
