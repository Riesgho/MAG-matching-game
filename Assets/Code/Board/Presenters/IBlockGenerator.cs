using System.Collections.Generic;
using Code.Board.Domain;

namespace Code.Board.Presenters
{
    public interface IBlockGenerator
    {
        IDictionary<string, Block> Generate(int rows, int columns);
    }
}