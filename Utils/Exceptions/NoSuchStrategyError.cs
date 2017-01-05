using System;

namespace RPS_Game.Utils.Exceptions
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base() { }
        public NoSuchStrategyError(string message) : base(message) { }
        public NoSuchStrategyError(string message, Exception inner) : base(message, inner) { }
    }
}
