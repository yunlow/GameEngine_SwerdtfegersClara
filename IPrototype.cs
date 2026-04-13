using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public interface IPrototype<TYPE>
    {
        public TYPE Clone();
    }
}
