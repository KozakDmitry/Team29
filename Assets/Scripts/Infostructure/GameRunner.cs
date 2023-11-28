using System.Collections;
using UnityEngine;


namespace Scripts.Infostructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper bootstrapperPrefab;
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
            if (bootstrapper == null)
            {
                Instantiate(bootstrapperPrefab);
            }
        }
    }
}