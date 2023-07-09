using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] lives;
    [SerializeField] private Image livesImageDisplay;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _playerLives;
    [SerializeField] private GameObject _playerScore;
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    [SerializeField] private TextMeshProUGUI score;
    private int totalScore;

    public void UpdateScore(int obtainedScore)
    {
        totalScore += obtainedScore;
        score.text = $"Score: {totalScore}";
    }

    private void ResetScore()
    {
        score.text = $"Score: {0}";
    }

    public void ShowMainMenu()
    {
        _mainMenu.SetActive(true);
        _playerLives.SetActive(false);
        //_playerScore.SetActive(false);
    }

    public void HideMainMenu()
    {
        _mainMenu.SetActive(false);
        _playerLives.SetActive(true);
        _playerScore.SetActive(true);
        ResetScore();
    }
}
