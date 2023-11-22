using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.PersistentProgress;
using System;

namespace Scripts.Infostructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;

        }
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, onLoaded);
        }

        private void onLoaded()
        {
            InitWorld();
            InformProgressReader();
            _gameStateMachine.Enter<GameLoopState>();
        }
        private void InformProgressReader()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }
        private void InitWorld()
        {

        }

        public void Exit()
        {

        }

    }
}