using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LaserCloneFired();
        DestroyLaserClone();

    }

    private void LaserCloneFired()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void DestroyLaserClone()
    {
        if (this.GameObject() && transform.position.y >= 5.5)
        {
            Destroy(this.GameObject());
        }
    }
}
