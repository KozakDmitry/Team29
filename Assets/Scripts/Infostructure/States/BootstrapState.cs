using Infostructure.Factory;
using Infostructure.Services;
using Infostructure.Services.Input;
using System;
using UnityEngine;

namespace Infostructure.States
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
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory());
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