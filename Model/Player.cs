namespace RPS_Game.Model
{
    public class Player
    {
        public Player(string name, Move move)
        {
            Name = name;
            Move = move;
        }

        public string Name { get; private set; }

        public Move Move { get; private set; }
    }
}
