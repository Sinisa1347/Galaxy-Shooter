using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] UIManagerInGame _UIManagerInGame;
    [SerializeField] GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInGame = _UIManagerInGame.GetComponent<UIManagerInGame>();

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            _UIManagerInGame.ShowPauseMenu();
            Time.timeScale = 0;
            _gameManager.isGamePaused = true;
        });
    }


    // Update is called once per frame
    void Update()
    {
    }
}
