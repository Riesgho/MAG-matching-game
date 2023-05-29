using System;
using System.Collections.Generic;
using Code.Board.Domain;

namespace Code.Board.Presenters
{
    public class BlockPresenter
    {
        private Action<string> BlockClicked { get; }
        public Action<string> BlockPopped { get; set; }
        private readonly IBlockView _view;
        private Block _block;
        private readonly IBlockConfig _blockConfig;
        private readonly IObserver<string> _blockClicked;

        public BlockPresenter(IBlockView view, Block block, Action<string> blockClicked, IBlockConfig blockConfig)
        {
            BlockClicked = blockClicked;
            _view = view;
            _block = block;
            _blockConfig = blockConfig;
            _view.BlockClicked = BlockClickedAction;
            _view.Popped = Popped;
        }

        private void Popped()
        {
            _view.MoveTo(10);
            BlockPopped(_block.ID);
        }

        private void BlockClickedAction()
        {
            BlockClicked(_block.ID);
        }

        public void Initialize()
        {
            _view.Initialize(_block, _blockConfig.BaseSize);
        }

        public IEnumerable<string> FindNeighbours() => 
            _view.FindNeighbours();

        public void Pop()
        {
            _view.Pop();
        }

        public void UpdateBlock(Block block)
        {
            _block = block;
            _view.UpdateColor(_block.Color.Color);
        }
    }
}