using UnityEngine;
using UnityEngine.UI;

public class GoBack : MonoBehaviour
{
    [SerializeField] UIManagerInMainMenus _UIManagerInMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInMainMenu = _UIManagerInMainMenu.GetComponent<UIManagerInMainMenus>();

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("Button clicked");
            _UIManagerInMainMenu.HideSettings();
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
