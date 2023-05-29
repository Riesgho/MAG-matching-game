using System.Collections.Generic;
using Code.Board.Domain;

namespace Code.Board.Infrastructure
{
    public class InMemoryBlocks : IBlockRepository
    {
        private readonly IDictionary<string, Block> _blocks;

        public InMemoryBlocks(IDictionary<string,Block> blocks)
        {
            _blocks = blocks;
        }

        public IDictionary<string, Block> GetAll() => 
            _blocks;

        public void UpdateBlock(Block block)
        {
            _blocks[block.ID] = block;
        }
    }
}