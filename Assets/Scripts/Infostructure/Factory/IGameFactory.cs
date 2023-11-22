using Scripts.Infostructure.Services;
using Scripts.Infostructure.Services.PersistentProgress;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Infostructure.Factory
{
    public interface IGameFactory :IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        public void Register(ISavedProgressReader progressReader);

        void CleanUp();
    }
}