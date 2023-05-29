namespace Code.Core.Domain
{
    public class Player
    {
        private int _reachedLevel;

        public Player(int reachedLevel)
        {
            _reachedLevel = reachedLevel;
        }

        public int ReachedLevel => _reachedLevel;

        public void SetReachedLevel(int level)
        {
            _reachedLevel = level;
        }
    }
}