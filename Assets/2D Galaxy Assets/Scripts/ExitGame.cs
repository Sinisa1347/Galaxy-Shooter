using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField]private Button _exitGame;
    // Start is called before the first frame update
    void Start()
    {
        _exitGame = _exitGame.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        _exitGame.onClick.AddListener(() =>
        {
            doExitGame();
        });
    }

    void doExitGame()
    {
        Application.Quit();
        Debug.Log("You have exitted the game");
    }
}
