using Infostructure.Factory;
using System;

namespace Infostructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gamefactory;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gamefactory = gameFactory;

        }
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, onLoaded);
        }

        private void onLoaded()
        {
            InitWorld();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitWorld()
        {

        }

        public void Exit()
        {

        }

    }
}