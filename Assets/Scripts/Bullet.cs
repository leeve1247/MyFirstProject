using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> myPool { get; set; }

    float bulletSpeed = 15f;

    float destroyTime = 2f;
    float curTime = 0;

    Rigidbody myRB;


    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        myRB.velocity = transform.up * bulletSpeed;

        destroyBullet();
    }


    void destroyBullet()
    {
        curTime += Time.deltaTime;
        if (curTime >= destroyTime)
        {
            curTime = 0f;
            myPool.Release(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Player")
        {
            myPool.Release(this.gameObject);
        }
    }
}
