using System;
using System.Collections.Generic;
using System.Linq;
using Code.Board.Domain;
using Code.Board.Infrastructure;
using Code.Goals.Domain;

namespace Code.Board.Presenters
{
    public class BoardPresenter
    {
        public Action<int> LevelWon { get; set; }
        public Action BlocksPopped { get; set; }
        private readonly IBoardView _boardView;
        private readonly IRandomValueGenerator _randomValueGenerator;
        private readonly IBlockGenerator _blockGenerator;
        private readonly int _level;
        private readonly IBlocksGoalsRepository _inMemoryGoals;
        private IDictionary<string, Block> _blocks;
        private List<Block> _poppedBlocks;
        public BoardPresenter(IBoardView boardView,
            IRandomValueGenerator randomValueGenerator,
            IBlockGenerator blockGenerator,
            int level,
            IBlocksGoalsRepository inMemoryGoals)
        {
            _boardView = boardView;
            _randomValueGenerator = randomValueGenerator;
            _blockGenerator = blockGenerator;
            _level = level;
            _inMemoryGoals = inMemoryGoals;
        }

        public void Initialize(IBlockConfig blockConfig)
        {
            var size = _randomValueGenerator.GetValueBetween(5,9);
            _blocks = _blockGenerator.Generate(size, size);
            var inMemoryBlocks = new InMemoryBlocks(_blocks);
            _boardView.Initialize(DestroyNeighboursOf, blockConfig, inMemoryBlocks);
            _boardView.Show();
            _poppedBlocks = new List<Block>();
        }
    

        private void DestroyNeighboursOf(string id)
        {
            var neighbours = _boardView.FindNeighboursOf(id);
            var sameColorNeighbours = neighbours.Where(blockId => _blocks[blockId].Color == _blocks[id].Color).ToList();
            if (sameColorNeighbours.Any())
            {
                sameColorNeighbours.Add(id);
                AddPoppedBlocks(sameColorNeighbours);
                _boardView.Pop(sameColorNeighbours);
                var execute = _inMemoryGoals.GetGoalFor(_level).Execute(_poppedBlocks);
                BlocksPopped();
                if (execute)
                {
                    BoardBested();
                }
            }
        }

        private void BoardBested()
        {
            LevelWon(_level);
            _boardView.Destroy();
        }

        private void AddPoppedBlocks(List<string> sameColorNeighbours)
        {
            foreach (var blockId in sameColorNeighbours)
            {
                _poppedBlocks.Add(new Block(blockId, 0, 0, _blocks[blockId].Color, 0, 0));
            }
        }
    }
}