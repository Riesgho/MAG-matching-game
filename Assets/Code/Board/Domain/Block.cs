using Code.Core.Views;
using UnityEngine;

namespace Code.Board.Domain
{
    public class Block
    {
        private readonly float _height;
        public string ID { get; }
        public float InitPositionX { get; }
        public float InitPositionY { get; }
        public BlockColor Color { get; }
        public float Height { get; }
        public float Width { get; }

        public Block(string id, float initPositionX, float initPositionY, BlockColor color, float height, float width)
        {
            Height = height;
            Width = width;
            ID = id;
            InitPositionX = initPositionX;
            InitPositionY = initPositionY;
            Color = color;
        }
    }
}