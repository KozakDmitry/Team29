using Scripts.Data;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Elements
{
    public class LootCounter : MonoBehaviour
    {
        public TextMeshProUGUI Counter;
        private PlayerProgress _playerProgress;

        public void Construct(PlayerProgress progress)
        {
            _playerProgress = progress;
            _playerProgress.LootData.ChangedLoot += UpdateCounter;
            UpdateCounter();
        }

        private void UpdateCounter()
        {
           Counter.text = $"(_playerProgress.LootData.collected)";
        }
    }
}
