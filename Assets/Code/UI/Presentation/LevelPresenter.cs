using Code.Goals.Domain;

namespace Code.UI.Presentation
{
    public class LevelPresenter
    {
        private readonly ILevelView _view;
        private readonly IBlocksGoalsRepository _inMemoryGoal;
        private int _level;

        public LevelPresenter(ILevelView view, IBlocksGoalsRepository inMemoryGoal)
        {
            _view = view;
            _inMemoryGoal = inMemoryGoal;
        }

        public void Initialize(int level)
        {
            _level = level;
            _view.Initialize(_inMemoryGoal.GetGoalFor(level));
        }

        public void Show()
        {
            _view.Show();
        }

        public void Hide()
        {
            _view.Hide();
        }

        public void UpdateGoal()
        {
            _view.UpdateGoal(_inMemoryGoal.GetGoalFor(_level));
        }
    }
}