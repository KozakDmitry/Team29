using Scripts.Infostructure.AssetManagment;
using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.Infostructure.Services.DifficultyDirector;
using Scripts.Infostructure.Services.Input;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Infostructure.Services.SaveLoad;
using Scripts.StaticData;
using System;
using UnityEngine;

namespace Scripts.Infostructure.States
{
    public class BootstrapState : IState
    {
        private const string Entry = "Entry";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = AllServices.Container;
            _services = services;
            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(Entry, onLoaded: EnterLoadLevel);

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            RegisterStaticData();
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssets>(new AssetManager());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IDifficultyDirectorService>(new DifficultyDirectorService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(),_services.Single<IStaticDataService>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadMonsters();
            staticData.LoadWeapons();
            _services.RegisterSingle(staticData);
        }

        private static IInputService InputService()
        {
            if(Application.isEditor)
            {
                return new StandaloneInputService();
            }
            else
            {
                return new MobileInputService();
            }
        }

        public void Exit()
        {

        }
    }
}