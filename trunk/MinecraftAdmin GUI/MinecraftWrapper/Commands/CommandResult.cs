using System;
using System.Collections.Generic;
using System.Text;

namespace Zicore.MinecraftAdmin.Commands
{
    public class CommandResult
    {
        bool hasResult = false;

        public bool HasResult
        {
            get { return hasResult; }
            set { hasResult = value; }
        }

        bool isPrivate = false;

        public bool IsPrivate
        {
            get { return isPrivate; }
            set { isPrivate = value; }
        }

        String message = "";

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        public CommandResult(bool hasResult,String msg)
        {
            if (!String.IsNullOrEmpty(msg))
            {
                this.Message = msg;
                this.HasResult = hasResult;
            }
        }

        public CommandResult(bool hasResult, String msg, bool isPrivate)
            :this(hasResult,msg)
        {
            this.IsPrivate = isPrivate;
        }

        public CommandResult()
           :this(false,"")
        {

        }
    }
}
