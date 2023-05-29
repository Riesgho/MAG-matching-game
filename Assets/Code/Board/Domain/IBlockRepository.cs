using System.Collections.Generic;

namespace Code.Board.Domain
{
    public interface IBlockRepository
    {
        IDictionary<string, Block> GetAll();
        void UpdateBlock(Block block);
    }
}