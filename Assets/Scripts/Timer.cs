using System;
using BoundfoxStudios.MiniGolf._Game.Scripts;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    private float _waitingTimeValue = 5;
    private bool _next = false;
    public Text timeText;
    public GameObject gameOverPanel;

    private void Start()
    {
        _waitingTimeValue += timeValue;
    }

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            GameOver();
        }
        DisplayTime(timeValue);

        _waitingTimeValue -= Time.deltaTime;
        if (_waitingTimeValue <= 0)
        {
            _next = true;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        if (_next)
        {
            TrackManager.Instance.NextTrack();
            timeValue = 90;
            _waitingTimeValue = timeValue + 5;
            _next = false;
            ScoreManager.instance.ResetScore();
            gameOverPanel.SetActive(false);
        }
    }
}
