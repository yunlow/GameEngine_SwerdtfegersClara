using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    internal class GameEngine
    {
        private bool _shouldQuit = false;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        public void Run()
        {
            float last_time = GetCurrentTime();
            while (!_shouldQuit)
            {
                float loop_start_time = GetCurrentTime();
                float elapsed_time = loop_start_time - last_time;
                ProcessInput();
                Update(elapsed_time); // ICI
                Render();
                last_time = loop_start_time;

            }
        }

        public void ProcessInput()
        {
           
        }

        public void Update(float elapsed_time)
        {

        }

        public void Render()
        {

        }

        public float GetCurrentTime()
        {
            return _stopwatch.ElapsedMilliseconds / 1000.0f;
        }
    }
}
