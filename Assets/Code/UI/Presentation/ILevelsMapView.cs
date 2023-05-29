using System;
using System.Collections.Generic;
using Code.Core.Domain;

namespace Code.UI.Presentation
{
    public interface ILevelsMapView
    {
        void DrawLevels(IDictionary<int,Level> levels);
        void DeactivateNotAvailableLevels(int reachedLevel);
        Action<int> LevelClicked { get; set; }
        void Hide();
        void Show();
    }
}