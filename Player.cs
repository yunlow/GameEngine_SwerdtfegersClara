using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class Player
    {
        private Vector2 _position;
        private string _renderGraphic = "@";
        private float speed = 3f;

        public void Render()
        {
            Console.Clear();
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write(_renderGraphic);
        }

        public void SetDirection(Vector2 new_direction)
        {

        }

        public Vector2 GetPosition()
        {
            return _position;
        }
    }
}
