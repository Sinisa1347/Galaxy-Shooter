using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerupsToSpawn;
    [SerializeField] private GameObject[] _enemiesToSpawn;
    [SerializeField] private float cooldown = 10.0f;
    [SerializeField] private float speed = 4.0f;
    private float nextTimeSpawn = 0.0f;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        nextTimeSpawn = Time.time + cooldown;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Time.time > nextTimeSpawn)
        {
            nextTimeSpawn = Time.time + cooldown;

            int randomNumber = Random.Range(0, _powerupsToSpawn.Length);

            InstantiatePrefav(_powerupsToSpawn[randomNumber]);

            foreach (var _enemyToSpawn in _enemiesToSpawn)
            {
                InstantiatePrefav(_enemyToSpawn);
            }
        }

        if (_gameManager.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }

    private Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-8, 8), 5, 0);
    }

    private void InstantiatePrefav(GameObject _objectToSpawn)
    {
        GameObject _clonedObjectToSpawn = Instantiate(_objectToSpawn, RandomSpawn(), Quaternion.identity);
        if (_clonedObjectToSpawn)
        {
            _clonedObjectToSpawn.transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (_clonedObjectToSpawn && _clonedObjectToSpawn.tag != "Enemy" && _clonedObjectToSpawn.transform.position.y < -4)
            {
                Destroy(_clonedObjectToSpawn);
            }
        }
    }
}

