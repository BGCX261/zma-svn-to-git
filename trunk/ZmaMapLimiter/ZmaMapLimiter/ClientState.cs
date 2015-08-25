using System;
using System.Collections.Generic;
using System.Text;

namespace ZmaMapLimiter
{
    public class ClientState
    {
        int ticker = 0;

        public int Ticker
        {
            get { return ticker; }
            set { ticker = value; }
        }
        int tickerMax = 5;

        public int TickerMax
        {
            get { return tickerMax; }
            set { tickerMax = value; }
        }

        bool hasBeenWarned = false;

        public bool HasBeenWarned
        {
            get { return hasBeenWarned; }
            set { hasBeenWarned = value; }
        }
        bool hasBeenTeleported = false;

        public bool HasBeenTeleported
        {
            get { return hasBeenTeleported; }
            set { hasBeenTeleported = value; }
        }
    }
}
