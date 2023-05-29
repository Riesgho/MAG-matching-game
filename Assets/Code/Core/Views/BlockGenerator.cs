using System.Collections.Generic;
using Code.Board.Domain;
using Code.Board.Presenters;

namespace Code.Core.Views
{
    public class BlockGenerator : IBlockGenerator
    {
        private readonly IBlockConfig _blockConfig;

        public BlockGenerator(IBlockConfig blockConfig)
        {
            _blockConfig = blockConfig;
        }
    
        public IDictionary<string, Block> Generate(int rows, int columns)
        {
            var blocks = new Dictionary<string, Block>();
            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < rows; j++)
                {
                    blocks.Add($"{i}{j}", new Block($"{i}{j}",
                        _blockConfig.InitPositionX + _blockConfig.WidthForColumns(columns)*i+1, 
                        _blockConfig.InitPositionY + _blockConfig.HeightForRows(rows)*j+1, 
                        _blockConfig.GetRandomColor(),
                        _blockConfig.HeightForRows(rows), 
                        _blockConfig.WidthForColumns(columns)));
                }
            }
            return blocks;
        }
    }
}