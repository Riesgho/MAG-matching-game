using System;
using System.Collections.Generic;
using System.Linq;
using Code.Core.Domain;
using Code.UI.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class LevelsMapsView: MonoBehaviour, ILevelsMapView
    {
        public Action<int> LevelClicked { get; set; }
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        [SerializeField] private LevelMapView levelMapPrefab;
        [SerializeField] private Transform layout;
        
        private IDictionary<int, LevelMapView> _levels = new Dictionary<int, LevelMapView>();

        public void DrawLevels(IDictionary<int, Level> levels)
        {
            foreach (var level in levels)
            {
                var levelView = Instantiate(levelMapPrefab, layout);
                levelView.Initialize(level.Value.Number);
                levelView.LevelClicked = LevelClicked;
                _levels.Add(level.Key, levelView);
            }
        }

        public void DeactivateNotAvailableLevels(int reachedLevel)
        {
            var levelViews = _levels.Values.ToList();
            for (var index = 0; index < _levels.Count; index++)
            {
                if(index > reachedLevel)
                    levelViews[index].Deactivate();
                else
                {
                    levelViews[index].Activate();
                }
            }
        }
    }
}