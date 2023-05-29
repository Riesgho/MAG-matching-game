using Code.Goals.Domain;
using Code.UI.Presentation;
using TMPro;
using UnityEngine;

namespace Code.UI.Views
{
    public class LevelView: MonoBehaviour, ILevelView
    {
        [SerializeField] private TextMeshProUGUI goalLabel;
        public void Initialize(IBlocksGoals goal)
        {
            UpdateGoal(goal);
        }

        public void Show()
        {
           gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void UpdateGoal(IBlocksGoals goal)
        {
            goalLabel.text = goal.GoalState();
        }
    }
}