using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public bool isGamePaused;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawner;
    [SerializeField] StartGameButton _startGameButton;
    [SerializeField] UIManagerInMainMenus _UIManagerInMainMenu;
    [SerializeField] UIManagerInGame _UIManagerInGame;

    // Start is called before the first frame update
    void Start()
    {
        //_UIManager = GameObject.Find("CanvasInGame").GetComponent<UIManagerInGame>();
        isGamePaused = false;
        _UIManagerInGame.GetComponent<UIManagerInGame>();
        _UIManagerInMainMenu.GetComponent<UIManagerInMainMenus>();
        _startGameButton = _startGameButton.GetComponent<StartGameButton>();
    }

    //// Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            _UIManagerInMainMenu.ShowMainMenu();
            _UIManagerInGame.HideInGameMenu();
        }
        else if (gameOver == false && _startGameButton.buttonPressed == true)
        {
            Instantiate(player, Vector3.zero, Quaternion.identity);
            Instantiate(spawner, Vector3.zero, Quaternion.identity);
            _UIManagerInMainMenu.HideMainMenu();
            _UIManagerInGame.ResetScore();
            _UIManagerInGame.ShowInGameMenu();

            _startGameButton.buttonPressed = false;
        }
    }
}
