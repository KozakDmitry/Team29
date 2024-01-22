using System;

namespace Scripts.Infostructure.Services.DifficultyDirector
{
    public interface IDifficultyDirectorService : IService
    {
        int DifficultyUpdateTimer { get; }
        int Difficulty { get; }

        event Action<int> DifficultyChanged;

        void UpdateDifficult();
    }
}