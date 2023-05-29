using System.Collections;
using System.Collections.Generic;

namespace Code.Core.Domain
{
    public interface ILevelConfig
    {
        IEnumerable<LevelData> GetAll();
    }
}