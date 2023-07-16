using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _powerupSpeed = 5.0f;
    private AudioClip _powerupSound;

    // Start is called before the first frame update
    void Start()
    {
        _powerupSound = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>()._powerUpSoundSource.clip;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _powerupSpeed);

        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsOtherCollidedObjectPlayer(other, this.gameObject);
    }

    private void IsOtherCollidedObjectPlayer(Collider2D other, GameObject _powerupPrefab)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_powerupSound, Camera.main.transform.position, 0.75f);
            Player player = other.GetComponent<Player>();

            if (player && _powerupPrefab.tag == "Powerup_TripleShot")
            {
                player.TripleShotPowerOn(_powerupPrefab.tag);
            }
            else if (player && _powerupPrefab.tag == "Powerup_Speed")
            {
                player.SpeedPowerOn(_powerupPrefab.tag);
            }
            else if (player && _powerupPrefab.tag == "Powerup_Shield")
            {
                player.ShieldPowerOn(_powerupPrefab.tag);
            }

            Destroy(this.gameObject);
        }
    }
}
