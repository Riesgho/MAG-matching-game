using System.Collections.Generic;

namespace Code.Core.Domain
{
    public interface ILevelsRepository
    {
        IDictionary<int, Level> GetAll();
    }
}