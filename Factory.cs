using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class Factory : Building
    {
        private Vector2 _position = new Vector2(0,0);

        private int _inputRequired;
        private int _outputProduced;
        private float _conversionRate;

        private float _conversionInterval = 3f;
        private float _conversionTimer = 0f;

        private string _renderGraphic = "F";

        public int _inputCount;
        public int _outputCount;
        public Factory _factory;

        public Factory(int input_required, int output_produced, float conversion_rate, GameEngine game_engine) : base(game_engine)
            
        {
            _inputRequired = input_required;
            _outputProduced = output_produced;
            _conversionRate = conversion_rate;

            _renderGraphic = "F";
        }
        public override void SetActive(bool is_active)
        { _factory.SetActive(is_active); }

        public void AddInput(int amount)
        {
            _inputCount += amount;
        }

        public override void FixedUpdate(float fixed_elapsed_time)
        {
            base.FixedUpdate(fixed_elapsed_time);

            _conversionTimer += fixed_elapsed_time;

            if (_conversionTimer >= _conversionInterval)
            {
                if (_inputCount >= _inputRequired)
                {
                    _inputCount -= _inputRequired;
                    _outputCount += _outputProduced;
                }

                _conversionTimer = 0f;
            }
        }

        public override void Render()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((int)_position.GetY(), (int)_position.GetX());
            Console.Write($"F[{_inputCount} + {_outputCount}]");
            
        }
    }
}

