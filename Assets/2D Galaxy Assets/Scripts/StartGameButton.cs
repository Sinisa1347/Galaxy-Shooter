using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    //[SerializeField] UIManagerInMainMenus _UIManagerInMainMenus;
    [SerializeField] GameManager _gameManager;
    private Button _button;
    public bool buttonPressed;
    void Start()
    {
        //_UIManagerInMainMenus = _UIManagerInMainMenus.GetComponent<UIManagerInMainMenus>();
        _gameManager = _gameManager.GetComponent<GameManager>();
        _button = this.GetComponent<Button>();

        _button.onClick.AddListener(() =>
        {
            //_UIManagerInMainMenus.HideMainMenu();
            _gameManager.gameOver = false;
            buttonPressed=true;
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
