
using System;
using UnityEngine;

namespace Scripts.Infostructure.Services.DifficultyDirector
{
    public class DifficultyDirectorService : IDifficultyDirectorService
    {

        public int DifficultyUpdateTimer 
        { 
            private set => DifficultyUpdateTimer = value; 
            get => DifficultyUpdateTimer * DifficultStacks; 
        }
        public int Difficulty { private set; get; }
        public event Action <int> DifficultyChanged;
        private int DifficultStacks;

        public DifficultyDirectorService()
        {
            Difficulty = 0;
            DifficultyUpdateTimer = 3;
            DifficultStacks++;
        }
        public void UpdateDifficult()
        {
            Difficulty+= 1;
            DifficultStacks++;
        }



    }
}
