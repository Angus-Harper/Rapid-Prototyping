using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Proto1
{ 
    public class UIManager : GameBehaviour<UIManager>
    {
        public TMP_Text scoreText;
        public PlayerController player;
        public PauseControler pauseCon;

        public TMP_Text bestTimeText;
        public TMP_Text bestTimeText1;
        public TMP_Text currentTimeText;
        public TMP_Text coins;
        public GameObject winCanvas;
        public void Update()
        {
            scoreText.text = player.cointP + "/9";

            if (player.cointP >= 9)
            {
                pauseCon.pause = true;
                pauseCon.hascontrol = false;
                winCanvas.SetActive(true);
            }
        }
        public void UpdateScore(int _score)
        {
            scoreText.text = "Score: " + _score;
        }

        public void UpdateCurrentTime(float _time)
        {
            currentTimeText.text = "Current TIme " + _time.ToString("F3");
        }
        public void UpdateBestTime(float _time, bool _firstTime = false)
        {
            if (_firstTime)
            {
                bestTimeText.text = "No Best Time Set Yet";
            }
            else 
            {
                bestTimeText.text = "Best Time: " + _time.ToString("F3");
                bestTimeText1.text = "Best Time: " + _time.ToString("F3");
            }
        }
    }
}
