
using System;
using UnityEngine;

namespace Scripts.Infostructure.Services.DifficultyDirector
{
    public class DifficultyDirectorService : IDifficultyDirectorService
    {
        
        public int Difficulty { private set; get; }
        public event Action <int> DifficultyChanged;
        
        public DifficultyDirectorService()
        {
            Difficulty = 0;
        }
        public void UpdateDifficult()
        {
            Difficulty+= 1;
        }



    }
}
