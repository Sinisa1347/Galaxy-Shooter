using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _powerupsToSpawn;
    [SerializeField] private GameObject[] _enemiesToSpawn;
    [SerializeField] private float cooldown = 10.0f;
    [SerializeField] private float speed = 4.0f;
    private float nextTimeSpawn = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        nextTimeSpawn = Time.time + cooldown;

    }

    void Update()
    {
        foreach (var _powerupToSpawn in _powerupsToSpawn)
        {
            if (_powerupToSpawn && _powerupToSpawn.tag != "Enemy" && _powerupToSpawn.transform.position.y < -4)
            {
                Destroy(_powerupToSpawn);
            }
        }

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
    }

    private Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-8, 8), 5, 0);
    }

    private void InstantiatePrefav(GameObject _objectToSpawn)
    {
        Instantiate(_objectToSpawn, RandomSpawn(), Quaternion.identity);
        if (_objectToSpawn)
        {
            _objectToSpawn.transform.Translate(Vector3.down * speed * Time.deltaTime);

            if (_objectToSpawn && _objectToSpawn.tag != "Enemy" && _objectToSpawn.transform.position.y < -4)
            {
                Destroy(_objectToSpawn);
            }
        }
    }
}

