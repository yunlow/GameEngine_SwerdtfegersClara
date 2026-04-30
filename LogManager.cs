using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine_SwerdtfegersLucas
{
    public class LogManager : EventManager
    {
        private const string LOG_FILE = "game_log.txt";
        public void WriteLog(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\n");
            System.IO.File.AppendAllText(LOG_FILE, $"[{timestamp}] {message}\n");
        }

    }
}
