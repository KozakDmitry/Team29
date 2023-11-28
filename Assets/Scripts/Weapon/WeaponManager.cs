using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField]
        private List<IWeapon> currentWeapon = new List<IWeapon>();
        private IGameFactory _gameFactory;


        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void ActivateAll()
        {
            foreach(IWeapon weapon in currentWeapon)
            {
                weapon.Activate();
            }
        }

        public void DeactivateAll()
        {

            foreach (IWeapon weapon in currentWeapon)
            {
                weapon.Deactivate();
            }
        }

    }
}