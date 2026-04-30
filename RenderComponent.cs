using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    

    public class RenderComponent : Component
    {
        
        private string _render;
        private PositionComponent _positionComponent;
        private ConsoleColor _color;
        public RenderComponent(GameObject game_object, string render, PositionComponent position_component, ConsoleColor color) : base(game_object)
        {
            _gameObject = game_object;
            _render = render;
            _positionComponent = position_component;
            _color = color;

            RenderManager.Register(this);

        }
           
        public void Render()
        {
            Console.SetCursorPosition(
                (int)_positionComponent.GetPosition().GetX(),
                (int)_positionComponent.GetPosition().GetY()
            );

            Console.ForegroundColor = _color;
            Console.Write(_render);
            Console.ResetColor();
        }
        public override Component Clone(GameObject parent_game_object)
        {
            PositionComponent cloned_position = parent_game_object.GetComponent<PositionComponent>();

            return new RenderComponent(
                parent_game_object,
                _render,
               cloned_position,
                _color
            );
        }
    }
}
