using System.Collections.Generic;
using Code.Board.Domain;

namespace Code.Goals.Domain
{
    public interface IBlocksGoals
    {
        bool Execute(IEnumerable<Block> blocks);
        string GoalState();
    }
}