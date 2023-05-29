using Code.Goals.Domain;

namespace Code.UI.Presentation
{
    public interface ILevelView
    {
        void Initialize(IBlocksGoals goal);
        void Show();
        void Hide();
        void UpdateGoal(IBlocksGoals goal);
    }
}