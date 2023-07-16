using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    private Button button;
    [SerializeField] UIManagerInMainMenus _UIManagerInMainMenus;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        _UIManagerInMainMenus = _UIManagerInMainMenus.GetComponent<UIManagerInMainMenus>();

        button.onClick.AddListener(() =>
        {
            _UIManagerInMainMenus.ShowSettings();
        });
    }
}
