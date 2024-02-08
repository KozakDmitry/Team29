using Scripts.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Scripts.Enemy
{
    public class LootDrop : MonoBehaviour
    {
        public GameObject lootPrefab;
        public GameObject pickUpPopUp;

        private bool _picked;
        private Loot _loot;
        public void Construct()
        {

        }

        public void Initialize(Loot loot)
        {
            _loot = loot;
        }

        private void OnTriggerEnter(Collider other) =>
            PickUp();

        private void PickUp()
        {
            if (_picked)
            {
                return;
            }
            _picked = true;

            UpdateWorldData();
            //ShowText();

            Destroy(this.gameObject, 1.5f);
        }

        private void UpdateWorldData()
        {

        }



        //private void ShowText()
        //{
        //    LootText.text = $"{_loot.value}";
        //    PickUpPopUp.SetActive(true);
        //}

    }
}
