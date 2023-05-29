using System.Collections.Generic;
using Code.Core.Domain;
using UnityEngine;

namespace Code.Core.Views
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelsConfig: ScriptableObject, ILevelConfig
    {
        [SerializeField] private List<LevelData> _levels;
        public IEnumerable<LevelData> GetAll() => _levels;
    }
}