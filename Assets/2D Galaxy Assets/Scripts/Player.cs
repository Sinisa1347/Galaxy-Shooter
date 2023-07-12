using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Vector3 _startPosition = new Vector3(0, 0, 0);
    [SerializeField] private float _playerSpeed = 7.5f;

    [SerializeField] private GameObject _singleShot;
    [SerializeField] private GameObject _tripleShot;
    [SerializeField] private GameObject _playerExplosionAnimation;
    [SerializeField] private GameObject _playerShield;

    [SerializeField] private float _fireRate = 0.0005f;
    [SerializeField] private bool canTripleShoot = false;
    [SerializeField] private int numberOfLives = 3;

    [SerializeField] private AudioClip _playerExplosionSound;
    [SerializeField] private GameObject _playerHurtLeftSide;
    [SerializeField] private GameObject _playerHurtRightSide;

    //[SerializeField] private GameObject _playerTurnRight;
    //[SerializeField] private GameObject _playerTurnLeft;

    private UIManager _UIManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;

    private float _nextFire = 0.0f;
    public bool isShieldOn = false;

    private float shieldTimeDuration = 10.0f;
    private float _tripleShotTimeDuration = 10.0f;
    private float _speedTimeDuration = 10.0f;

    private int _newNumberOfShieldPickedUp = 0;
    private int _lastNumberOfShieldPickedUp = 0;

    private int _newNumberOfSpeedPickedUp = 0;
    private int _lastNumberOfSpeedPickedUp = 0;

    private int _newNumberOfTripleShotPickedUp = 0;
    private int _lastNumberOfTripleShotPickedUp = 0;


    void Start()
    {
        if (transform.position.x != _startPosition.x || transform.position.y != _startPosition.y || transform.position.z != _startPosition.z)
        {
            Debug.Log($"position is not (0,0,0), placing player on: x:{_startPosition.x}, y:{_startPosition.y} and z:{_startPosition.z}"); 
            transform.position = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z);
        }

        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_UIManager)
        {
            _UIManager.UpdateLives(numberOfLives);
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = this.GetComponent<AudioSource>();

        _playerHurtLeftSide.SetActive(false);
        _playerHurtRightSide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundries();
        SpawnLaser();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//-1,0,1

        //if(horizontalInput == -1)
        //{
        //    Instantiate(_playerTurnLeft, transform.position, Quaternion.identity);
        //}
        //else if(horizontalInput == 1) 
        //{ 
        //    Instantiate(_playerTurnRight,transform.position, Quaternion.identity);
        //}

        transform.Translate(Vector3.right * _playerSpeed * horizontalInput * Time.deltaTime);

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
            _audioSource.Play();
        }
    }
    public void TripleShotPowerOn(string tag)
    {
        canTripleShoot = true;

        _newNumberOfTripleShotPickedUp += 1;

        object[] paramsForCoroutine = new object[] { _tripleShotTimeDuration, _newNumberOfTripleShotPickedUp, _lastNumberOfTripleShotPickedUp, tag };
        if (_newNumberOfTripleShotPickedUp == 1)
        {
            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine", paramsForCoroutine);
        }
    }

    private void TripleShotPowerUpTurnOff()
    {
        canTripleShoot = false;
        _newNumberOfTripleShotPickedUp = 0;
        _lastNumberOfTripleShotPickedUp = 0;
        Debug.Log($"Can triple shot {canTripleShoot}");
    }

    public void SpeedPowerOn(string tag)
    {
        _playerSpeed =11.0f;
        //Debug.Log($"Current player speed is {_playerSpeed}");
        //StartCoroutine(SpeedPowerDownCoroutine());

        _newNumberOfSpeedPickedUp += 1;

        object[] paramsForCoroutine = new object[] { _speedTimeDuration, _newNumberOfSpeedPickedUp, _lastNumberOfSpeedPickedUp, tag };
        if (_newNumberOfSpeedPickedUp == 1)
        {
            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine", paramsForCoroutine);
        }
    }

    private void SpeedPowerUpTurnOff()
    {
        _playerSpeed = 7.5f;
        _newNumberOfSpeedPickedUp = 0;
        _lastNumberOfSpeedPickedUp = 0;
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
            if (numberOfLives>0)
            {
                _UIManager.UpdateScore(-100);
                _UIManager.UpdateLives(numberOfLives);

                if (numberOfLives == 2)
                {
                    //_playerHurtLeftSide.SetActive(true);
                    RandomizePlayerHurtWing();
                }
                if(numberOfLives == 1) 
                {
                    //_playerHurtRightSide.SetActive(true);
                    RandomizePlayerHurtWing();
                }
            }
            else if(numberOfLives==0)
            {
                _UIManager.UpdateScore(-100);
                _UIManager.UpdateLives(numberOfLives);
                Instantiate(_playerExplosionAnimation, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(_playerExplosionSound, Camera.main.transform.position, 0.75f);
                _gameManager.gameOver = true;
                _UIManager.ShowMainMenu();
            }
        }
    }

    public void ShieldPowerOn(string tag)
    {
        _newNumberOfShieldPickedUp += 1;
        _playerShield.SetActive(true);
        isShieldOn = true;
        object[] paramsForCoroutine = new object[] { shieldTimeDuration, _newNumberOfShieldPickedUp, _lastNumberOfShieldPickedUp, tag };
        if (_newNumberOfShieldPickedUp == 1) 
        {
            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine", paramsForCoroutine);
        }
    }

    private void ShieldPowerUpTurnOff()
    {
        Debug.Log("Shields is inactive and is shield on is false");
        isShieldOn = false;
        _newNumberOfShieldPickedUp = 0;
        _lastNumberOfShieldPickedUp = 0;
        _playerShield.SetActive(false);
    }

    private IEnumerator WaitForMultipleOfTheSamePowerupsCoroutine(object[] paramsForCoroutine)
    {
        float timeDuration = (float)paramsForCoroutine[0];
        int newNumberOfPowerUpPickedUp = (int)paramsForCoroutine[1];
        int lastNumberOfPowerUpPickedUp = (int)paramsForCoroutine[2];
        string nameOfPowerUp = (string)paramsForCoroutine[3];

        Debug.Log($"Name of the powerup is {nameOfPowerUp}");

        Debug.Log($"Start counting for {timeDuration}");
        yield return new WaitForSeconds(timeDuration);
        Debug.Log($"{timeDuration} have passed");


        if (nameOfPowerUp == "Powerup_TripleShot")
        {
            newNumberOfPowerUpPickedUp = _newNumberOfTripleShotPickedUp;
        }
        else if (nameOfPowerUp == "Powerup_Speed")
        {
            newNumberOfPowerUpPickedUp = _newNumberOfSpeedPickedUp;
        }
        else if (nameOfPowerUp == "Powerup_Shield")
        {
            newNumberOfPowerUpPickedUp = _newNumberOfShieldPickedUp;
        }

        if (lastNumberOfPowerUpPickedUp < newNumberOfPowerUpPickedUp-1)
        {
            Debug.Log($"lastNumberOfPowerUpPickedUp {lastNumberOfPowerUpPickedUp}");
            lastNumberOfPowerUpPickedUp += 1;
            Debug.Log($"newNumberOfPowerUpPickedUp {newNumberOfPowerUpPickedUp}");

            object paramsToStartCoroutineAgain = new object[] {timeDuration,newNumberOfPowerUpPickedUp,lastNumberOfPowerUpPickedUp,nameOfPowerUp};

            StartCoroutine("WaitForMultipleOfTheSamePowerupsCoroutine", paramsToStartCoroutineAgain);
        }
        else if(lastNumberOfPowerUpPickedUp+1 == newNumberOfPowerUpPickedUp)
        {
            Debug.Log($"lastNumberOfPowerUpPickedUp== newNumberOfPowerUpPickedUp");

            if (nameOfPowerUp == "Powerup_TripleShot")
            {
                TripleShotPowerUpTurnOff();
            }
            else if (nameOfPowerUp == "Powerup_Speed")
            {
                SpeedPowerUpTurnOff();
            }
            else if (nameOfPowerUp == "Powerup_Shield")
            {
                ShieldPowerUpTurnOff();
            }
        }
    }

    private void RandomizePlayerHurtWing()
    {
        int randomNumber = Random.Range(0, 2);

        if(randomNumber == 0)
        {
            if (_playerHurtLeftSide.activeSelf == true)
            {
                _playerHurtRightSide.SetActive(true);
                Debug.Log("Player hurt on right side");
            }
            else
            {
                _playerHurtLeftSide.SetActive(true);
                Debug.Log("Player hurt on left side");
            }
        }
        else if(randomNumber == 1)
        {
            if (_playerHurtRightSide.activeSelf == true)
            {
                _playerHurtLeftSide.SetActive(true);
                Debug.Log("Player hurt on left side");
            }
            else
            {
                _playerHurtRightSide.SetActive(true);
                Debug.Log("Player hurt on right side");
            }
        }
    }
}