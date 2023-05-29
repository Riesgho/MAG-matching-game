using System;
using System.Collections.Generic;
using System.Linq;
using Code.Board.Domain;
using Code.Board.Presenters;
using UnityEngine;

namespace Code.Board.Views
{
    public class BoardView : MonoBehaviour,  IBoardView
    {
        [SerializeField] private BlockViewWorldSpace blockViewPrefab;
        private readonly IDictionary<string, BlockPresenter> _blockPresenters = new Dictionary<string, BlockPresenter>();
        private IBlockConfig _blockConfig;
        private IBlockRepository _inMemoryBlocks;

        public void Initialize(Action<string> blockClicked,
            IBlockConfig blockConfig,
            IBlockRepository inMemoryBlocks)
        {
            _blockConfig = blockConfig;
            _inMemoryBlocks = inMemoryBlocks;
            InitializeBlocks(blockClicked);
        }

        public IEnumerable<string> FindNeighboursOf(string id) => 
            _blockPresenters[id].FindNeighbours().ToList();

        public void Pop(IEnumerable<string> sameColorNeighbours)
        {
            foreach (var id in sameColorNeighbours)
            {
                _blockPresenters[id].Pop();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void InitializeBlocks(Action<string> blockClicked)
        {                                                         
            foreach (var block in _inMemoryBlocks.GetAll())
            {
                var view = Instantiate(blockViewPrefab, transform);
                var blockPresenter = new BlockPresenter(view, block.Value, blockClicked,_blockConfig);
                blockPresenter.Initialize();
                _blockPresenters.Add(block.Key, blockPresenter);
                blockPresenter.BlockPopped = ChangeBlockColor;
            }
        }

        private void ChangeBlockColor(string id)
        {
            var blocks = _inMemoryBlocks.GetAll();
            var currentBlock = blocks[id];
            var block = new Block(id,
                currentBlock.InitPositionX,
                currentBlock.InitPositionY,
                _blockConfig.GetRandomColor(),
                currentBlock.Height,
                currentBlock.Width);
            _inMemoryBlocks.UpdateBlock(block);
            _blockPresenters[id].UpdateBlock(block);
        }
    }
}
