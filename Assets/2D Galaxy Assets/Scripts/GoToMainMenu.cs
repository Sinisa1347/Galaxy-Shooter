using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMainMenu : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] UIManagerInGame _UIManagerInGame;
    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInGame = _UIManagerInGame.GetComponent<UIManagerInGame>();

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            _gameManager.gameOver = true;
            _UIManagerInGame.HidePauseMenu();
            _gameManager.isGamePaused = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
