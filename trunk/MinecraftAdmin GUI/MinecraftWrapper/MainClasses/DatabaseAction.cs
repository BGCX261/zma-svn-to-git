using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftWrapper.MainClasses
{
    public enum ActionType
    {
        None = 0,
        Move = 1,
        Dig = 2,
        Build = 3,
    };

    public class DatabaseAction
    {
        public DatabaseAction(Action action)
        {
            this.Action = action;
        }

        //ActionType type = ActionType.None;
        Action action = null;

        public Action Action
        {
            get { return action; }
            set { action = value; }
        }
    }
}
