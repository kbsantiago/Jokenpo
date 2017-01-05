using System.Collections.Generic;

namespace RPS_Game.Model
{
    public class SingleMatch
    {
        private List<Player[]> _matches;
        private Player[] _players = new Player[2];

        public SingleMatch(Player player1, Player player2)
        {
            _matches = new List<Player[]>();

            _players[0] = player1;
            _players[1] = player2;

            AddPlayers(_players);
        }


        public List<Player[]> GetMatches()
        {
            return _matches;
        }

        private void AddPlayers(Player[] players)
        {
            _matches.Add(players);
        }

       
    }
}
