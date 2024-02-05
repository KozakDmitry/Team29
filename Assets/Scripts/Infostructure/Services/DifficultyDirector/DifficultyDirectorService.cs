
using System;
using UnityEngine;

namespace Scripts.Infostructure.Services.DifficultyDirector
{
    public class DifficultyDirectorService : IDifficultyDirectorService
    {

        public int DifficultyUpdateTimer 
        { 
            private set => _diffUpdateTimer = value; 
            get => _diffUpdateTimer * DifficultStacks; 
        }
        private int _diffUpdateTimer;
        public int Difficulty { private set; get; }
        public event Action <int> DifficultyChanged;
        private int DifficultStacks; 

        public DifficultyDirectorService()
        {
            Difficulty = 0;
            _diffUpdateTimer = 3;
            DifficultStacks=0;
        }
        public void UpdateDifficult()
        {
            Difficulty+= 1;
            DifficultStacks++;
        }



    }
}
