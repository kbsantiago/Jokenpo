using RPS_Game.Model;
using RPS_Game.Utils.Exceptions;
using System;
using System.Collections.Generic;

namespace RPS_Game.Services
{
    public class ResultCompiler
    {
        public ResultCompiler(SingleMatch match)
        {
            _match = match;
        }

        public ResultCompiler(Tournament tournament)
        {
            _tournament = tournament;
        }

        /// <summary>
        /// Retorna o vencedor de um jogo simples
        /// </summary>
        /// <returns></returns>
        public string RpsGameWinner()
        {
            Player player =  null;

            foreach (Player[] players in _match.GetMatches())
            {
                ValidatePlayersMove(players);

                player = AnalyzeResult(players[0], players[1]);
            }

            return string.Format("Winner is: {0}, with Move: {1}", player.Name, player.Move.Name);
        }

        /// <summary>
        /// Retorna o vencedor do torneio
        /// </summary>
        /// <returns></returns>
        public string RpsTournamentWinner()
        {
            Player[] players = new Player[2];
            byte i = 0;

            foreach (List<Player[]> groups in _tournament.GetTournament())
            {
                players[i] = FindWinnerPerGroup(groups);
                i++;
            }

            Player player = AnalyzeResult(players[0], players[1]);

            return string.Format("Tournament Winner is: {0}, with mover {1}", player.Name, player.Move.Name);
        }

        /// <summary>
        /// Encontra o vencedor de um grupo do torneio
        /// </summary>
        /// <param name="groups"></param>
        /// <returns></returns>
        private Player FindWinnerPerGroup(List<Player[]> groups)
        {
            byte i = 0;

            foreach (Player[] players in groups)
            {
                ValidatePlayersMove(players);

                _finalPlayers[i] = AnalyzeResult(players[0], players[1]);
                i++;
            }

            return AnalyzeResult(_finalPlayers[0], _finalPlayers[1]);
        }


        /// <summary>
        /// Realiza a analise dos movimentos dos jogadores
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        private Player AnalyzeResult(Player player1, Player player2)
        {
            if ((player1.Move.Name.Equals("R", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("S", StringComparison.InvariantCultureIgnoreCase)) ||
               ((player1.Move.Name.Equals("P", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("R", StringComparison.InvariantCultureIgnoreCase)) ||
               (player1.Move.Name.Equals("S", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("P", StringComparison.InvariantCultureIgnoreCase))))  
                return player1;
            else if((player1.Move.Name.Equals("S", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("R", StringComparison.InvariantCultureIgnoreCase)) ||
                   ((player1.Move.Name.Equals("R", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("P", StringComparison.InvariantCultureIgnoreCase)) ||
                    (player1.Move.Name.Equals("P", StringComparison.InvariantCultureIgnoreCase) && player2.Move.Name.Equals("S", StringComparison.InvariantCultureIgnoreCase))))
                return player2;
            else
                return player2;
        }

        /// <summary>
        /// Realiza validacao do numero de jogadores
        /// </summary>
        private void ValidateNumberOfPlayers()
        {
            foreach (Player[] players in _match.GetMatches())
            {
                if (players[0] == null || players[1] == null)
                    throw new WrongNumberOfPlayersError("Required two players to start the game.");
            }
        }

        /// <summary>
        /// Realiza validacao do movimento dos jogadores
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private void ValidatePlayersMove(Player[] players)
        {
            foreach (Player player in players)
            {
                if (!(player.Move.Name.Equals("R", StringComparison.InvariantCultureIgnoreCase) ||
                    player.Move.Name.Equals("P", StringComparison.InvariantCultureIgnoreCase) ||
                    player.Move.Name.Equals("S", StringComparison.InvariantCultureIgnoreCase)))
                    throw new NoSuchStrategyError("Not a valid move.");
            }
        }

        private SingleMatch _match;
        private Tournament _tournament;
        private Player[] _finalPlayers = new Player[2];
    }
}
