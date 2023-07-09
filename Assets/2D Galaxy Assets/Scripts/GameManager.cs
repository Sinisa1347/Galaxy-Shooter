using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    public GameObject player;
    public GameObject spawner;

    private UIManager _UIManager;

    // Start is called before the first frame update
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            _UIManager.ShowMainMenu();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player,Vector3.zero,Quaternion.identity);
                Instantiate(spawner, Vector3.zero, Quaternion.identity);
                _UIManager.HideMainMenu();
                gameOver = false;
            }
        }
    }
}
