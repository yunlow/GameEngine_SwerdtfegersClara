using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public abstract class GameObject
    {
        public abstract void Update(float elapsed_time);
        public abstract void FixedUpdate(float fixed_elapsed_time);

        public abstract void Render();
    }
}
