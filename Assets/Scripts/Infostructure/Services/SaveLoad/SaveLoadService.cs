using System.Collections;
using Scripts.Data;
using Scripts.Infostructure.Factory;
using Scripts.Infostructure.Services.PersistentProgress;
using UnityEngine;

namespace Scripts.Infostructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory) 
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }
        public PlayerProgress LoadProgress()
        {
            return new PlayerProgress();
        }

        public void SaveProgress()
        {
            
        }

       
    }
}