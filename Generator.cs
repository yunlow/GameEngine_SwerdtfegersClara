using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class Generator : Building
    {

        private Vector2 _position = new Vector2(0,0);

        private float _productionInterval;
        private float _productionTimer = 0f;

        private string _renderGraphic = "G";
        private int _productionCount = 0;

        public Generator(float productionInterval, GameEngine gameEngine)
            : base(gameEngine)
        {
            _productionInterval = productionInterval;
            
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            base.FixedUpdate(fixed_elapsed_time);

            _productionTimer += fixed_elapsed_time;

            if (_productionTimer >= _productionInterval)
            {
                _productionCount++;
                _productionTimer = 0f;
            }
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write($"G[{_productionCount}]");
          
        }
    }
}

