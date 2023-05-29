using System.Collections.Generic;
using Code.Board.Domain;
using UnityEngine;

namespace Code.Core.Views
{
    [CreateAssetMenu(menuName = "Create BlockConfig", fileName = "BlockConfig", order = 0)]
    public class BlockConfig :ScriptableObject, IBlockConfig
    {
        private const int MinAmountOfColumns = 5;
        private const int MinAmountOfRows = 5;
        [SerializeField] private float baseSize;
        [SerializeField] private Vector2 initPosition;
        [SerializeField] private List<Vector2> blockSizes;
        [SerializeField] private List<BlockColor> _colors;
        public float InitPositionX => initPosition.x;
        public float InitPositionY => initPosition.y;
        public float WidthForColumns(int columns) => 
            blockSizes[columns - MinAmountOfColumns].x;

        public float HeightForRows(int rows) => 
            blockSizes[rows - MinAmountOfRows].y;

        public BlockColor GetRandomColor() => 
            _colors[Random.Range(0, _colors.Count)];

        public float BaseSize => baseSize;
    }
}