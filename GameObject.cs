using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class GameObject : IPrototype<GameObject>
    {
        
        private List<Component> _componentTable = new List<Component>();
        private string _name;
        private bool _isActive = true;
        private GameEngine game_engine;


        public GameObject(GameEngine game_engine, string name)
        {
            
           
            _name = name;
            

        }

        public void OnEnable()
        {
            SetActive(true);
        }

        public void OnDisable()
        {
            SetActive(false);
        }
        public void SetActive(bool is_active)
        {
            _isActive = is_active;

            foreach (Component component in _componentTable)
            {
                component.SetActive(is_active);
            }
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

        public GameObject Clone()
        {
            GameObject clone = new GameObject(game_engine, _name + "_Clone");
          
            foreach (Component component in _componentTable)
            {
                Component cloned_component = component.Clone(clone);
                clone.AddComponent(cloned_component);
            }
            
            return clone;
        }
    }
}
