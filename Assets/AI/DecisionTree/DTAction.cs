using System;

namespace Utils.AI
{
    public class DTAction : IDTNode
    {
        Action action;

        public DTAction(Action action)
        {
            this.action = action;
        }

        public void Run()
        {
            action();
        }
    }
}

