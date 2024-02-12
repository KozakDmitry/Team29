using Scripts.Infostructure.Services;
using UnityEngine;

namespace Scripts.Infostructure.AssetManagement
{
    public interface IAssets :IService
    {
        public GameObject InstantiatePrefab(string path);
        public GameObject InstantiatePrefab(string path, Vector3 position);
    }
}