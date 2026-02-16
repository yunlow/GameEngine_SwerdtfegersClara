using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Player
    {
        private Vector2 _position = new Vector2(5, 5);
        private Vector2 _direction = new Vector2(0, 0);

        private string _renderGraphic = "@";
        private float speed = 10f;

        public void Render()
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


    }
}
