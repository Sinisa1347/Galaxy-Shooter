using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerInMainMenus : MonoBehaviour
{
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _exitGameButton;
    [SerializeField] private GameObject _coverPicture;
    [SerializeField] private GameObject _settingsPanel;

    public void HideMainMenu()
    {
        _startGameButton.SetActive(false);
        _settingsButton.SetActive(false);
        _exitGameButton.SetActive(false);
        _coverPicture.SetActive(false);
    }

    public void ShowMainMenu()
    {
        _startGameButton.SetActive(true);
        _settingsButton.SetActive(true);
        _exitGameButton.SetActive(true);
        _coverPicture.SetActive(true);
    }

    public void ShowSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void HideSettings()
    {
        _settingsPanel.SetActive(false);
    }
}
