using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftWrapper.WrapperEventArgs
{
    public class ClientExceptionEventArgs : EventArgs
    {
        public ClientExceptionEventArgs(Exception ex)
        {
            this.Exception = ex;
            message = null;
        }

        public ClientExceptionEventArgs(String message)
        {
            this.message = message;
            exception = null;
        }

        String message = "";

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        Exception exception;

        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }
    }
}
