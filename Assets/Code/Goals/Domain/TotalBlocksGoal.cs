using System.Collections.Generic;
using System.Linq;
using Code.Board.Domain;
using UnityEngine;

namespace Code.Goals.Domain
{
    public class TotalBlocksGoal: IBlocksGoals
    {
        private readonly int _totalBlocks;
        private int _blocksPopped;

        public TotalBlocksGoal(int totalBlocks)
        {
            _totalBlocks = totalBlocks;
        }
        
        public bool Execute(IEnumerable<Block> blocks)
        {
            _blocksPopped = blocks.Count();
            return _totalBlocks <= _blocksPopped;
        }

        public string GoalState() => 
            $"{_blocksPopped} Blocks Popped out of {_totalBlocks}";
    }
}