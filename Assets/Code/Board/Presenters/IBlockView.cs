using System;
using System.Collections.Generic;
using Code.Board.Domain;
using UnityEngine;

namespace Code.Board.Presenters
{
    public interface IBlockView
    {
        void Initialize(Block block, float blockBaseSize);
        Action BlockClicked { get; set; }
        Action Popped { get; set; }
        IEnumerable<string> FindNeighbours();
        void Pop();
        void MoveTo(float position);
        void UpdateColor(Color blockColor);
    }
}