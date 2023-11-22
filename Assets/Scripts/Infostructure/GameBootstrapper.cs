using Infostructure.States;
using UnityEngine;

namespace Infostructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game(this);
            _game._stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}