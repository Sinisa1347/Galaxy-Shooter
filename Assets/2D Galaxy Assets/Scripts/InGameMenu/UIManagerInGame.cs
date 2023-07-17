using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerInGame : MonoBehaviour
{
    [SerializeField] private Sprite[] lives;
    [SerializeField] private Image livesImageDisplay;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _playerLives;
    [SerializeField] private GameObject _playerScore;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _pauseMenu;
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

    public void ResetScore()
    {
        score.text = $"Score: {0}";
    }

    public void ShowInGameMenu()
    {
        _playerLives.SetActive(true);
        _pauseButton.SetActive(true);
        _playerScore.SetActive(true);
    }

    public void HideInGameMenu()
    {
        _playerLives.SetActive(false);
        _pauseButton.SetActive(false);
    }

    public void ShowPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
    public void HidePauseMenu()
    {
        _pauseMenu.SetActive(false);
    }
}
