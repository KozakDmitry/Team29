
using Scripts.Infostructure.Services.DifficultyDirector;
using System;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Logic
{
    public class SurviveTimer :MonoBehaviour
    {
        public TextMeshProUGUI surviveTime;
        

        private DifficultyDirectorService _directorService;
        private float startTime;

        public void Construct(DifficultyDirectorService directorService)
        {
            _directorService = directorService;
        }
        private void Start()
        {
            startTime = Time.time;
        }

        private void Update()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(Time.time - startTime);
            surviveTime.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds); ;
        }

    }
}
