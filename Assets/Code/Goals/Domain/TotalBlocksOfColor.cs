using System.Collections.Generic;
using System.Linq;
using Code.Board.Domain;
using Code.Core.Views;
using UnityEngine;

namespace Code.Goals.Domain
{
    public class TotalBlocksOfColor: IBlocksGoals
    {
        private readonly int _amount;
        private readonly BlockColor _color;
        private int _blocksPopped;

        public TotalBlocksOfColor(int amount, BlockColor color)
        {
            _amount = amount;
            _color = color;
        }
        public bool Execute(IEnumerable<Block> blocks)
        {
            _blocksPopped = blocks.Count(block => block.Color.ColorName == _color.ColorName);
            return _amount <= _blocksPopped;
        }

        public string GoalState() => 
            $"{_blocksPopped} Blocks Popped out of {_amount} of color {_color.ColorName}";
    }
}