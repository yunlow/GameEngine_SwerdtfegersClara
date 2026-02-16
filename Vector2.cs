using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class Vector2
    {
        private float _x;
        private float _y;

        public Vector2()
        {
            _x = 0;
            _y = 0;
        }
        public Vector2(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float GetX() { return _x; } 
        public void SetX(float x) { _x = x; }
        public float GetY() { return _y; }
        public void SetY(float y) { _y = y; }
                        
        
    }
}
