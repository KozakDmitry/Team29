using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject WeaponList;
        [SerializeField]
        public List<IWeapon> currentWeapons = new List<IWeapon>();

        private IGameFactory _gameFactory;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void AddWeapon(WeaponTypeID weaponTypeID)
        {
            GameObject weapon = _gameFactory.AddWeapon(weaponTypeID);
            weapon.transform.parent = WeaponList.transform;
            currentWeapons.Add(weapon.GetComponent<IWeapon>());
            weapon.GetComponent<IWeapon>().Activate();
        }

        public void ActivateAll()
        {
            foreach(IWeapon weapon in currentWeapons)
            {
                weapon.Activate();
            }
        }

        public void DeactivateAll()
        {

            foreach (IWeapon weapon in currentWeapons)
            {
                weapon.Deactivate();
            }
        }

    }
}