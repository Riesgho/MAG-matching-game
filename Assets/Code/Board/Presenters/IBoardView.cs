using System;
using System.Collections.Generic;
using Code.Board.Domain;

namespace Code.Board.Presenters
{
    public interface IBoardView
    {
        void Initialize(Action<string> blockClicked, IBlockConfig blockConfig,
            IBlockRepository inMemoryBlocks);
        IEnumerable<string> FindNeighboursOf(string id);
        void Pop(IEnumerable<string> sameColorNeighbours);
        void Show();
        void Hide();
        void Destroy();
    }
}