using System.Collections.Generic;
using Code.Goals.Domain;

namespace Code.Goals.Infrastructure
{
    public class InMemoryGoals: IBlocksGoalsRepository
    {
        private IDictionary<int, IBlocksGoals> _goals;
        public InMemoryGoals()
        {
            _goals = new Dictionary<int, IBlocksGoals>();
        }

        public IDictionary<int, IBlocksGoals> GetAllGoals() => 
            _goals;

        public IBlocksGoals GetGoalFor(int level) => 
            _goals[level];

        public void AddGoal(IBlocksGoals goal, int level)
        {
            _goals.Add(level, goal);
        }
    }
}