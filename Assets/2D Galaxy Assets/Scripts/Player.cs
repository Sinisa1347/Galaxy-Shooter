using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(0, 0, 0);
    [SerializeField] private float playerSpeed = 7.5f;

    [SerializeField] private float rightBoundary = 8.0f;
    [SerializeField] private float leftBoundary = -8.0f;
    [SerializeField] private float topBoundary = 8.0f;
    [SerializeField] private float bottomBoundary = -8.0f;


    void Start()
    {
        if (transform.position.x != startPosition.x || transform.position.y != startPosition.y || transform.position.z != startPosition.z)
        {
            Debug.Log($"position is not: x:{startPosition.x}, y:{startPosition.y} and z:{startPosition.z}"); 
            transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundries();
    }

    void Movement()
    {
        Vector3 moveCharacter = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*playerSpeed*horizontalInput*Time.deltaTime);

        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up*playerSpeed*verticalInput*Time.deltaTime);
        //characterController.Move(playerSpeed * Time.deltaTime * moveCharacter);//7.5*0*(0,1)
    }
    private void Boundries()
    {
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
}