using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Infostructure.Services.SaveLoad;
using System;
using System.Collections.Generic;

namespace Scripts.Infostructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadProgressState)] = new LoadProgressState(this,services.Single<IPersistentProgressService>(), services.Single<ISaveLoadService>()),
                [typeof(LoadLevelState)] = new LoadLevelState(this,sceneLoader,services.Single<IGameFactory>(), services.Single<IPersistentProgressService>()),
                [typeof(GameLoopState)] = new GameLoopState(),
                
            };


        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState,TPayloat>(TPayloat payload) where TState : class, IPayloadedState<TPayloat>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        public TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state; 
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}