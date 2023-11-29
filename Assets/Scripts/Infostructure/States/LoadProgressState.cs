

using Scripts.Data;
using Scripts.Infostructure.Services.PersistentProgress;
using Scripts.Infostructure.Services.SaveLoad;
using System;

namespace Scripts.Infostructure.States
{
    public class LoadProgressState : IState
    {
        private const string Scene = "City";
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistentProgressService _progressService;
        private ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistentProgressService progressService, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }
        public void Enter()
        {
            LoadProgressOrCreateNew();
            _stateMachine.Enter<LoadLevelState, string>(Scene);
        }

        private void LoadProgressOrCreateNew() =>
            _progressService.Progress = 
            _saveLoadService.LoadProgress() 
            ?? NewProgress();

        private PlayerProgress NewProgress()
        {
            PlayerProgress progress = new PlayerProgress();
            return progress; 
        }

        public void Exit()
        {

        }
    }
}