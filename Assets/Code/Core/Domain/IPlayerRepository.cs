namespace Code.Core.Domain
{
    public interface IPlayerRepository
    {
        Player GetPlayer();
        void SetPlayer(Player player);
    }
}