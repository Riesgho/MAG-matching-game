using System.Collections.Generic;
using Code.Core.Domain;

namespace Code.Core.Infrastructure
{
    public class InMemoryLevels: ILevelsRepository
    {
        private IDictionary<int,Level> _levels;

        public InMemoryLevels(ILevelConfig levelsConfigs)
        {
            _levels = new Dictionary<int, Level>();
            foreach (var levels in levelsConfigs.GetAll())
            {
                _levels.Add(levels.Number, new Level(levels.Number));
            }
        }
    
        public IDictionary<int, Level> GetAll() => 
            _levels;
    }
}