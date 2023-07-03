using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private GameObject enemyExplosion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -6.5)
        {
            transform.position = GenerateNewSpawn();
        }
    }

    Vector3 GenerateNewSpawn()
    {
        float randomX = Random.Range(-8.0f, 8.0f);
        return new Vector3(randomX, 6.5f,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player!=null)
            {
                int numberOfLives = player.ReduceLife(player.numberOfLives);
                player.numberOfLives = numberOfLives;
            }
        }

        if (other.gameObject.tag == "Laser")
        {
            Laser laser = other.gameObject.GetComponent<Laser>();
            if (laser != null)
            {
                Instantiate(enemyExplosion,transform.position, Quaternion.identity);

                Destroy(this.gameObject);

                if (laser.gameObject.transform.parent != null)
                {
                    Destroy(laser.transform.parent.gameObject);
                }
                else
                {
                    Destroy(laser.gameObject);
                }
            }
        }
    }
}
