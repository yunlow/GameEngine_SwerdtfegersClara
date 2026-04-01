using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    

    public class RenderComponent : Component
    {
        private GameObject _gameObject;
        private string _render;
        private PositionComponent _positionComponent;
        public RenderComponent(GameObject game_object, string render, PositionComponent position_component) 
        {
            _gameObject = game_object;
            _render = render;
            _positionComponent = position_component;

            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(_render);
            Console.ResetColor();
        }

        
    }
}
