using Scripts.StaticData;
using System.Collections;
using UnityEngine;

namespace Scripts.Weapon
{
    public class ArmorySpawnSlot : MonoBehaviour
    {
        [SerializeField]
        private WeaponTypeID weaponType;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<WeaponManager>().AddWeapon(weaponType);      
                Destroy(this.gameObject);
            }
        }
    }
}