using UnityEngine;
using UnityEngine.UIElements;

public class Powerup : MonoBehaviour
{
    //[SerializeField] private GameObject _powerupPrefab;
    //[SerializeField] private float cooldown = 10.0f;
    //private float nextTimespawn = 0.0f;
    private float speed = 10.0f;
    //public float currentTime = 0.0f;
    //private GameObject clonePowerup;
    // Start is called before the first frame update
    void Start()
    {
        //nextTimeSpawn = Time.time + cooldown;
        //Debug.Log($"Next time spawn is: {nextTimeSpawn}");
        //nextTimespawn = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down *speed * Time.deltaTime);
        //currentTime += Time.deltaTime;

        //if(currentTime> nextTimespawn ) 
        //{
        //    Debug.Log(currentTime);
        //    Debug.Log(nextTimespawn);
            
        //    CreateClone();
        //}

        //if (clonePowerup && clonePowerup.transform.position.y < -4)
        //{
        //    Destroy(clonePowerup);
        //}
    }

    //void CreateClone()
    //{
    //    clonePowerup = Instantiate(this.gameObject, RandomSpawn(), Quaternion.identity);
    //    clonePowerup.transform.Translate(Vector3.down * speed * Time.deltaTime);
    //}

    //Vector3 RandomSpawn()
    //{
    //    return new Vector3(Random.Range(-8, 8), 4,0);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.name}");
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player)
            {
                player.TripleShotPowerOn();
            }

            Destroy(this.gameObject);
        }
    }
}
