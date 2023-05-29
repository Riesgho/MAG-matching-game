namespace Code.Core.Domain
{
    public class UpdatePlayerOnWin
    {
        private readonly IPlayerRepository _playerRepository;

        public UpdatePlayerOnWin(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Execute(int level)
        {
            var player = _playerRepository.GetPlayer();
            if (player.ReachedLevel < level)
            {
                player.SetReachedLevel(level);
                _playerRepository.SetPlayer(player);
            }
        }
    }
}