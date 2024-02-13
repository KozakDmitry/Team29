using Scripts.Data;
using Scripts.Infostructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Elements
{
    public class LootCounter : MonoBehaviour
    {
        public TextMeshProUGUI Counter;
        private IPersistentProgressService _playerProgress;

        public void Construct(IPersistentProgressService progress)
        {
            _playerProgress = progress;
            _playerProgress.Progress.LootData.ChangedLoot += UpdateCounter;
            UpdateCounter();
        }

        private void UpdateCounter()
        {
           Counter.text = $"{_playerProgress.Progress.LootData.collected}";
        }
    }
}
