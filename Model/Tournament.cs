using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS_Game.Model
{
    public class Tournament
    {
        public Tournament()
        {
            _tournamentPlayers = new List<List<Player[]>>();
            _groups = new List<Player[]>();
        }

        public void AddToGroup(Player player1, Player player2)
        {
            Player[] _players = new Player[2];

            _players[0] = player1;
            _players[1] = player2;

            if (_groups.Count < 2)
            {
                _groups.Add(_players);
            }
            else
            {
                _groups = new List<Player[]>();
                _groups.Add(_players);
            }
        }

        public void CreateGroup()
        {
            AddPlayersToTournament();
        }

        public List<List<Player[]>> GetTournament()
        {
            return _tournamentPlayers;
        }
        
        private void AddPlayersToTournament()
        {
            _tournamentPlayers.Add(_groups);
        }

        private List<List<Player[]>> _tournamentPlayers;
        private List<Player[]> _groups;
    }
}
