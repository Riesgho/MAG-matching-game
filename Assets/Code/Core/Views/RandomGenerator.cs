using Code.Board.Presenters;
using UnityEngine;

namespace Code.Core.Views
{
    public class RandomGenerator: IRandomValueGenerator
    {
        public int GetValueBetween(int min, int max) => 
            Random.Range(min, max);
    }
}