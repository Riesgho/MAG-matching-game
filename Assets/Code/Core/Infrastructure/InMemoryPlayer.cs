using Code.Core.Domain;

namespace Code.Core.Infrastructure
{
    public class InMemoryPlayer: IPlayerRepository
    {
        private Player _player;

        public InMemoryPlayer()
        {
            _player = new Player(0);
        }
        public Player GetPlayer() => 
            _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }
    }
}