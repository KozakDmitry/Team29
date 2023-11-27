using Scripts.Weapon;
using UnityEngine;

namespace Scripts.StaticData
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "StaticData/WeaponData")]
    public class WeaponStaticData : ScriptableObject
    {
        public Sprite Sprite;

        [Range(1,20)]
        public int MaxLevel;
        
        [Range(1, 20)]
        public int StartDamage;

        [Range(1, 20)]
        public int DamagePerLevel;

        public IWeapon WeaponScript;
    }
}
