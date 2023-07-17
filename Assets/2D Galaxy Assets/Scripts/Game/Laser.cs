using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20.0f;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
        else
        {
            LaserCloneFired();
            DestroyLaserClone();
        }
    }

    private void LaserCloneFired()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void DestroyLaserClone()
    {
        if (this.GameObject() && transform.position.y >= 5.5)
        {
            Destroy(this.GameObject());
        }
    }
}
