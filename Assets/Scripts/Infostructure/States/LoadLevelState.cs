using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Logic;
using Scripts.UI.Logic;
using Scripts.UI.Services;
using System;
using UnityEngine;

namespace Scripts.Infostructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _UIFactory;
        private readonly IPersistentProgressService _progressService;
       
 

        private const string StartPointTag = "StartPoint";
        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IPersistentProgressService progressService, IUIFactory UIFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _UIFactory = UIFactory;
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
            GameObject _player = _gameFactory.CreatePlayer(GameObject.FindWithTag(StartPointTag));
            InitSpawner();
            InitUIRoot();
            InitHUD(_player);
            BindCamera(_player);
        }

        private void InitUIRoot()
        {
            _UIFactory.CreateUIRoot();
        }

        private void InitSpawner() => 
            _gameFactory.CreateSpawner();

        private void BindCamera(GameObject player) =>
            Camera.main.GetComponent<CameraFollow>().Follow(player);

        private void InitHUD(GameObject player)
        {
            GameObject hud = _gameFactory.CreateHUD();
            hud.GetComponent<ActorUI>().Construct(player.GetComponent<IHealth>());
        }

        public void Exit()
        {

        }

    }
}