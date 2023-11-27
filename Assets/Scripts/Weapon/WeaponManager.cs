using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        private Dictionary<IWeapon, int> currentWeapon = new Dictionary<IWeapon, int>();
        private IGameFactory _gameFactory;


        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void ActivateAll()
        {
            foreach(IWeapon weapon in currentWeapon.Keys)
            {
                weapon.Activate();
            }
        }

        public void DeactivateAll()
        {

            foreach (IWeapon weapon in currentWeapon.Keys)
            {
                weapon.Deactivate();
            }
        }

    }
}