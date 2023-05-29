using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Views
{
    public class LevelMapView : MonoBehaviour
    {
        public Action<int> LevelClicked { get; set; }
        
        [SerializeField] private Button _levelSelectedButton;
        [SerializeField] private TextMeshProUGUI _levelLabel;
        public void Initialize(int valueNumber)
        {
            _levelLabel.text = valueNumber.ToString();
            _levelSelectedButton.onClick.RemoveAllListeners();
            _levelSelectedButton.onClick.AddListener(()=> LevelClicked(valueNumber));
        }

        public void Deactivate()
        {
            _levelSelectedButton.interactable = false;
        }

        public void Activate()
        {
            _levelSelectedButton.interactable = true;
        }
    }
}