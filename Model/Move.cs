namespace RPS_Game.Model
{
    public class Move
    {
        public Move(string name)
        {
            Name = name;
        }

        public string Name{ get; private set; }
    }
}