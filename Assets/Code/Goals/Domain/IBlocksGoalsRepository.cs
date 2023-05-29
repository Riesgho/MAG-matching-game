using System.Collections.Generic;

namespace Code.Goals.Domain
{
    public interface IBlocksGoalsRepository
    {
        IDictionary<int, IBlocksGoals> GetAllGoals();
        IBlocksGoals GetGoalFor(int level);
        void AddGoal(IBlocksGoals goal, int level);
    }
}