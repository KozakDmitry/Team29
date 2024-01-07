using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Player;
using System;
using UnityEngine;

namespace Scripts.Infostructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public GameLoopState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }
        public void Enter()
        {
            Debug.Log("InGame");
            _gameFactory.ReturnPlayer().GetComponent<PlayerGameRestart>().Restart+= RestartTheGame;

        }

        private void RestartTheGame()
        {
            _stateMachine.Enter<BootstrapState>();
        }

        public void Exit()
        {

        }

        
    }
}