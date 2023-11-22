using System.Collections;
using UnityEngine;

namespace Scripts.Infostructure.AssetManagment
{
    public class AssetManager : IAssets
    {
        public GameObject InstantiatePrefab(string path)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject InstantiatePrefab(string path, Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);

        }
    }
}