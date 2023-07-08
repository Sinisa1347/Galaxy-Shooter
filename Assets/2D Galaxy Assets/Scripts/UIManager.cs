using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] lives;
    public Image livesImageDisplay;
    public void UpdateLivese(int currentLives)
    {
        Debug.Log($"Current image is for lives: {livesImageDisplay}");
        livesImageDisplay.sprite = lives[currentLives];
    }

    public TextMeshProUGUI score;
    private int totalScore=0;

    public void UpdateScore(int obtainedScore)
    {
        totalScore += obtainedScore;
        score.text = $"Score: {totalScore}";
    }
}
