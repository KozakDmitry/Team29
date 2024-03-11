using Scripts.Data;
using UnityEditor;
using UnityEngine;

namespace Scripts.Enemy
{
    public class LootDrop : MonoBehaviour
    {
        public GameObject lootPrefab;
        public GameObject pickUpPopUp;

        private bool _picked;
        private Loot _loot;
        private PlayerProgress _progress;

        public void Construct(PlayerProgress progress)
        {
            _progress = progress;
        }

        public void Initialize(Loot loot)
        {
            _loot = loot;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PickUp();
            }
        }

        private void FixedUpdate()
        {
            Rotating();
        }
        private void Rotating()
        {
            transform.Rotate(Vector3.up, 1f);
        }
        private void PickUp()
        {
            if (_picked)
            {
                return;
            }
            _picked = true;

            UpdateData();
            Destroy(this.gameObject);
        }

        private void UpdateData()
        {
            _progress.LootData.Collect(_loot);
        }

    }
}
