using Code.Core.Views;
using UnityEngine;

namespace Code.Board.Domain
{
    public interface IBlockConfig
    {
        float InitPositionX { get; }
        float InitPositionY { get; }
        float BaseSize { get; }
        float WidthForColumns(int columns);
        float HeightForRows(int rows);
        BlockColor GetRandomColor();
    }
}