using UnityEngine;
using UnityEngine.UI;

public class GoBackToGame : MonoBehaviour
{
    [SerializeField] UIManagerInGame _UIManagerInGame;
    [SerializeField] GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInGame = _UIManagerInGame.GetComponent<UIManagerInGame>();

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            _UIManagerInGame.HidePauseMenu();
            Time.timeScale = 1;
            _gameManager.isGamePaused = false;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
