using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private GameObject _powerupPrefab;
    [SerializeField] private float _powerupSpeed=5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _powerupSpeed);

        if(transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"Collided with {other.name}");

        //Debug.Log($"Current powerup prefab is {_powerupPrefab}");
        //Debug.Log($"And its tag is {_powerupPrefab.tag}");

        IsOtherCollidedObjectPlayer(other, _powerupPrefab);
    }

    private void IsOtherCollidedObjectPlayer(Collider2D other, GameObject _powerupPrefab)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player && _powerupPrefab.tag == "Powerup_TripleShot")
            {
                player.TripleShotPowerOn();
            }
            else if (player && _powerupPrefab.tag == "Powerup_Speed")
            {
                player.SpeedPowerOn();
            }
            else if(player && _powerupPrefab.tag == "Powerup_Shield")
            {
                player.ShieldPowerOn();
            }

            Destroy(this.gameObject);
        }
    }
}
