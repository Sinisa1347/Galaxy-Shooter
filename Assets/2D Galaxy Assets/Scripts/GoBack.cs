using UnityEngine;
using UnityEngine.UI;

public class GoBack : MonoBehaviour
{
    [SerializeField] UIManagerInMainMenus _UIManagerInMainMenu;
    [SerializeField] Button goBackButton;

    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInMainMenu = _UIManagerInMainMenu.GetComponent<UIManagerInMainMenus>();

        goBackButton.onClick.AddListener(() =>
        {
            _UIManagerInMainMenu.HideSettings();
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
