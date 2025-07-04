using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private GameObject enemyExplosion;
    private AudioClip _enemyExplosionAudioClip;

    private GameManager _gameManager;
    private UIManagerInGame _UIManagerInGame;

    // Start is called before the first frame update
    void Start()
    {
        _UIManagerInGame = GameObject.FindGameObjectWithTag("CanvasInGame").GetComponent<UIManagerInGame>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _enemyExplosionAudioClip = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>()._explosionSoundSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -6.5)
        {
            transform.position = GenerateNewSpawn();
        }

        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }

    Vector3 GenerateNewSpawn()
    {
        float randomX = Random.Range(-8.0f, 8.0f);
        return new Vector3(randomX, 6.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.ReduceLife();
                Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(_enemyExplosionAudioClip, Camera.main.transform.position, 0.75f);
            }
        }
        else if (other.gameObject.tag == "Laser")
        {
            Laser laser = other.gameObject.GetComponent<Laser>();
            if (laser != null)
            {
                Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(_enemyExplosionAudioClip, Camera.main.transform.position, 0.75f);

                if (laser.gameObject.transform.parent != null)
                {
                    Destroy(laser.transform.parent.gameObject);
                }
                else
                {
                    Destroy(laser.gameObject);
                }

                _UIManagerInGame.UpdateScore(100);
            }
        }
    }
}
