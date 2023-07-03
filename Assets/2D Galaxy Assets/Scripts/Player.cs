using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _startPosition = new Vector3(0, 0, 0);
    [SerializeField] private float _playerSpeed = 7.5f;

    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleLaserPrefab;

    [SerializeField] private GameObject playerExplosion;

    [SerializeField] private float _fireRate = 0.0005f;
    private float _nextFire = 0.0f;

    public bool canTripleShoot = false;

    public int numberOfLives = 3;


    void Start()
    {
        if (transform.position.x != _startPosition.x || transform.position.y != _startPosition.y || transform.position.z != _startPosition.z)
        {
            Debug.Log($"position is not (0,0,0), placing player on: x:{_startPosition.x}, y:{_startPosition.y} and z:{_startPosition.z}"); 
            transform.position = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundries();
        SpawnLaser();

        if (numberOfLives < 1)
        {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//-1,0,1
        transform.Translate(Vector3.right*_playerSpeed*horizontalInput*Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*_playerSpeed*verticalInput*Time.deltaTime);
    }
    private void Boundries()
    {
        float rightBoundary = 8.0f;
        float leftBoundary = -8.0f;
        float topBoundary = 6.0f;
        float bottomBoundary = -6.0f;


        if (transform.position.x >= rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= leftBoundary)
        {
            transform.position = new Vector3(leftBoundary,transform.position.y,transform.position.z);
        }

        if(transform.position.y >= topBoundary)
        {
            transform.position = new Vector3(transform.position.x, bottomBoundary, transform.position.z);
        }
        else if (transform.position.y <= bottomBoundary)
        {
            transform.position = new Vector3(transform.position.x, topBoundary, transform.position.z);
        }
    }

    private void SpawnLaser()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&& Time.time>=_nextFire) 
        {
            _nextFire += _fireRate;

            if (canTripleShoot == true )
            {
                Instantiate(_tripleLaserPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            }
        }
    }
    public void TripleShotPowerOn()
    {
        canTripleShoot = true;
        Debug.Log($"Can triple shot {canTripleShoot}");
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
        Debug.Log($"Can triple shot {canTripleShoot}");
    }


    public void SpeedPowerOn()
    {
        _playerSpeed = _playerSpeed*1.5f;
        Debug.Log($"Current player speed is {_playerSpeed}");
        StartCoroutine(SpeedPowerDownCoroutine());
    }

    public IEnumerator SpeedPowerDownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _playerSpeed = 7.5f;
        Debug.Log($"Current player speed is {_playerSpeed}");
    }

    public int ReduceLife(int numberOfLives)
    {
        numberOfLives -= 1;
        Debug.Log($"Remaining number of lives for player: {numberOfLives}");
        return numberOfLives;
    }
}