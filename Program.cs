using RPS_Game.Model;
using RPS_Game.Services;
using System;

namespace RPS_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player armando = new Player(("Armando"), new Move("P"));
            Player dave = new Player(("Dave"), new Move("S"));

            Player richard = new Player(("Richard"), new Move("R"));
            Player michael = new Player(("Michael"), new Move("S"));

            Player allen = new Player(("Allen"), new Move("S"));
            Player omer = new Player(("Omer"), new Move("P"));

            Player david = new Player(("David E."), new Move("R"));
            Player richardX = new Player(("Richard X."), new Move("P"));

            ///Single Matches
            SingleMatch match = new SingleMatch(armando, dave);

            ResultCompiler result = new ResultCompiler(match);

            try { Console.WriteLine(result.RpsGameWinner()); }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

            ///Tournament
            ///
            Tournament tournament = new Tournament();

            tournament.AddToGroup(armando, dave);
            tournament.AddToGroup(richard, michael);
            tournament.CreateGroup();
            tournament.AddToGroup(allen, omer);
            tournament.AddToGroup(david, richardX);
            tournament.CreateGroup();

            ResultCompiler tournamentResult = new ResultCompiler(tournament);

            try { Console.WriteLine(tournamentResult.RpsTournamentWinner()); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }
    }
}
