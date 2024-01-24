﻿
using Scripts.Infostructure.Services.DifficultyDirector;
using System;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Logic
{
    public class SurviveTimer :MonoBehaviour
    {
        public TextMeshProUGUI surviveTime;
        

        private IDifficultyDirectorService _directorService;
        private float startTime;
        private TimeSpan timeSpan;

        public void Construct(IDifficultyDirectorService directorService)
        {
            _directorService = directorService;
            
        }
        private void Start()
        {
            startTime = Time.time;
        }

        private void Update()
        {
            UpdateTimer();
        }

        private void UpdateTimer()
        {
            timeSpan = TimeSpan.FromSeconds(Time.time - startTime);
            CheckUpdateDifficulty();
            surviveTime.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        }

        private void CheckUpdateDifficulty()
        {
            if (timeSpan.TotalMinutes > (double)_directorService.DifficultyUpdateTimer)
            {
                _directorService.UpdateDifficult();
            }
        }
    }
}
