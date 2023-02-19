using System;

namespace Zoo
{
    public class Logger
    {
        public event Action<string> Notify;

        public void OnNotify(string message)
        {
            Notify?.Invoke($"[{DateTime.Now:G}] >> " + message);
        }
        
    }
}