using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private float cooldown = 20.0f;
    private float nextTimeSpawn = 0.0f;
    private float speed = 2.5f;
    private GameObject powerupClone;
    // Start is called before the first frame update
    void Start()
    {
        nextTimeSpawn = Time.time + cooldown;
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
            nextTimeSpawn = Time.time + cooldown;
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
}
