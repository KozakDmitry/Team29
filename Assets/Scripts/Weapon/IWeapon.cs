using Scripts.StaticData;
using UnityEngine;

namespace Scripts.Weapon
{
    public interface IWeapon
    {
    
        public string name { get; set; }
        public int level { get; set; }

        public float damage { get; set; }
        public Transform heroTransform { get; set; }
        public GameObject attackPrefab { get; set; }
        public float damagePerLevel { get; set; }
        public void LevelUp();
        public void Activate();
        
        public void Deactivate();

        public void Construct();

       

    }
}