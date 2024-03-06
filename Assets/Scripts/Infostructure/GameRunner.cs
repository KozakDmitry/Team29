using Scripts.Infostructure.States;
using System.Collections;
using UnityEngine;


namespace Scripts.Infostructure
{
    public class GameRunner : MonoBehaviour
    {
        public Scenes StartScene;
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