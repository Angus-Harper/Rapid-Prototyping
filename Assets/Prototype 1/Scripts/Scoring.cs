using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proto1
{
    public class Scoring : GameBehaviour
    {
        public float bestTime;
        public float currentTime;
        public PlayerController player;
        Timer timer;

        private void Start()
        {
            if (PlayerPrefs.HasKey("BestTime"))
            {
                bestTime = PlayerPrefs.GetFloat("BestTime");
                _UI.UpdateBestTime(bestTime);
            }
            else
            {
                bestTime = 10000;
            }

            timer = FindObjectOfType<Timer>(); // finds object through the hierarchy
            timer.StartTimer();
        }

        void Update()
        {
            if (timer.IsTiming())
            {
                _UI.UpdateCurrentTime(timer.GetTimer());

            }
            if (player.cointP > 8)
            {
                GameOver();
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                PlayerPrefs.DeleteAll();
            }
        }

        void GameOver()
        {
            timer.StopTimer();
            currentTime = timer.GetTimer();
            if (currentTime < bestTime)
            {
                bestTime = currentTime;
                PlayerPrefs.SetFloat("BestTime", bestTime);
            }
        }
    }
}
