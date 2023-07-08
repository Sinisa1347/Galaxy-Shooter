using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _startPosition = new Vector3(0, 0, 0);
    [SerializeField] private float _playerSpeed = 7.5f;

    [SerializeField] private GameObject _singleShot;
    [SerializeField] private GameObject _tripleShot;
    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private GameObject _playerShield;

    [SerializeField] private float _fireRate = 0.0005f;
    [SerializeField] private bool canTripleShoot = false;
    [SerializeField] private int numberOfLives = 3;

    private UIManager UIManager;

    private float _nextFire = 0.0f;
    public bool isShieldOn = false;
    private float shieldTimeDuration = 10.0f;

    int newNumberOfTheSamePowerups = 0;
    int lastNumberForMultiplePowerups =0;


    void Start()
    {
        if (transform.position.x != _startPosition.x || transform.position.y != _startPosition.y || transform.position.z != _startPosition.z)
        {
            Debug.Log($"position is not (0,0,0), placing player on: x:{_startPosition.x}, y:{_startPosition.y} and z:{_startPosition.z}"); 
            transform.position = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z);
        }

        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (UIManager)
        {
            UIManager.UpdateLivese(numberOfLives);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundries();
        SpawnLaser();
        //ShieldIsActiveOnPlayer();

        if (numberOfLives < 1)
        {
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
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
                Instantiate(_tripleShot, transform.position, Quaternion.identity);

            }
            else
            {
                Instantiate(_singleShot, transform.position, Quaternion.identity);
            }
        }
    }
    public void TripleShotPowerOn()
    {
        canTripleShoot = true;
        Debug.Log($"Can triple shot {canTripleShoot}");
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    private IEnumerator TripleShotPowerDownRoutine()
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

    private IEnumerator SpeedPowerDownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _playerSpeed = 7.5f;
        Debug.Log($"Current player speed is {_playerSpeed}");
    }

    public void ReduceLife()
    {
        if (isShieldOn == true)
        {
            //Debug.Log("Shield saved your life");
            _playerShield.SetActive(false);
            isShieldOn = false;

        }
        else
        {
            numberOfLives -= 1;

            UIManager.UpdateLivese(numberOfLives);
            //Debug.Log($"Remaining number of lives for player: {numberOfLives}");
        }
    }

    public void ShieldPowerOn()
    {
        newNumberOfTheSamePowerups += 1;
        _playerShield.SetActive(true);
        isShieldOn = true;
        if (newNumberOfTheSamePowerups == 1) 
        {
            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine");
        }
    }

    private IEnumerator WaitForMultipleOfTheSamePowerupsCoroutine()
    {
        Debug.Log($"Start counting for {shieldTimeDuration}");
        yield return new WaitForSeconds(shieldTimeDuration);
        Debug.Log($"{shieldTimeDuration} have passed");
        if (newNumberOfTheSamePowerups == 1)
        {
            PowerupTurnOff();
        }

        else if (lastNumberForMultiplePowerups < newNumberOfTheSamePowerups)
        {
            lastNumberForMultiplePowerups += 1;
            Debug.Log($"lastNumberForMultiplePowerups {lastNumberForMultiplePowerups}");
            Debug.Log($"newNumberOfTheSamePowerups {newNumberOfTheSamePowerups}");
            //Debug.Log($"Time has been extended to: {shieldTimeDuration*newNumberOfTheSamePowerups}");
            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine");
        }
        else if(lastNumberForMultiplePowerups == newNumberOfTheSamePowerups)
        {
            Debug.Log($"Number of the same powerups picked up = {newNumberOfTheSamePowerups}");
            Debug.Log("lastNumberForMultiplePowerups == newNumberOfTheSamePowerups");
            PowerupTurnOff();
        }
    }

    private void PowerupTurnOff()
    {
        Debug.Log("Shields is inactive and is shield on is false");
        isShieldOn = false;
        _playerShield.SetActive(false);
    }
}