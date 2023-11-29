using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.PersistentProgress;
using System;
using UnityEngine;

namespace Scripts.Infostructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;


        private const string StartPointTag = "StartPoint";
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
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindWithTag(StartPointTag));
            InitSpawner();
            InitHUD(player);
            BindCamera(player);
        }

        private void InitSpawner() => 
            _gameFactory.CreateSpawner();

        private void BindCamera(GameObject player) =>
            Camera.main.GetComponent<CameraFollow>().Follow(player);

        private void InitHUD(GameObject player) =>
            _gameFactory.CreateHUD();

        public void Exit()
        {

        }

    }
}