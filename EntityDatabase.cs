using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class EntityDatabase
    {
        private Dictionary<string, GameObject> _prototypeTable = new Dictionary<string, GameObject>();
        public void RegisterEntity(string name, GameObject prototype)
        {
            _prototypeTable[name] = prototype;
        }
        public GameObject CreateEntity(string name)
        {
            if (_prototypeTable.ContainsKey(name))
            {
                return _prototypeTable[name].Clone();
            }
            else
            {
                throw new Exception($"Entity '{name}' not found in database.");
            }
        }
    }
}
