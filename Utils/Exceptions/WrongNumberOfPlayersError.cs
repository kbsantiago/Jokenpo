using System;

namespace RPS_Game.Utils.Exceptions
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError() : base() { }
        public WrongNumberOfPlayersError(string message) : base(message) { }
        public WrongNumberOfPlayersError(string message, Exception inner) : base(message, inner) { }
    }
}
