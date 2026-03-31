using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class GameObject
    {
        private GameEngine _gameEngine;
        private List<Component> _componentTable = new List<Component>();
        private string _name;
        public GameObject(GameEngine game_engine, string name)
        { 
            _gameEngine = game_engine;
            game_engine.AddGameObject(this);
            _name = name;
        }

        public void AddComponent(Component component)
        {
            _componentTable.Add(component);
        }
        public void Update(float elapsed_time)
        {
            foreach (Component component in _componentTable)
            {
                if (component != null && component.GetIsActive())
                {
                    component.Update(elapsed_time);
                }
            }
        }
        public void FixedUpdate(float fixed_elapsed_time)
        {
            foreach (Component component in _componentTable)
            {
                if (component != null && component.GetIsActive())
                {
                    component.FixedUpdate(fixed_elapsed_time);
                }
            }
        }

        public TYPE GetComponent<TYPE>() where TYPE : Component
        {
            for (int component_index = 0; component_index < _componentTable.Count; component_index++)
            {
                if (_componentTable[component_index] is TYPE selected_component)
                {
                    return selected_component;
                }
            }
            return null;
        }


    }
}
