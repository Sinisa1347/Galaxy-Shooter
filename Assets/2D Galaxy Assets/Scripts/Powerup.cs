using UnityEngine;
using UnityEngine.UIElements;

public class Powerup : MonoBehaviour
{
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private float spawnCooldown = 20.0f;
    private float nextTimeSpawn = 0.0f;
    private float speed = 5.0f;
    private GameObject powerupClone;
    // Start is called before the first frame update
    void Start()
    {
        nextTimeSpawn = Time.time + spawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(powerupClone && powerupClone.transform.position.y < -4)
        {
            Destroy(powerupClone);
        }

        if(Time.time > nextTimeSpawn) 
        {
            nextTimeSpawn = Time.time + spawnCooldown;
            powerupClone = Instantiate(_powerupPrefab, RandomSpawn(), Quaternion.identity);
        }

        if (powerupClone)
        {
            powerupClone.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-8, 8), 5, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.name}");
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player)
            {
                player.TripleShotPowerOn();

                Destroy(this.gameObject);
            }
        }
    }
}
