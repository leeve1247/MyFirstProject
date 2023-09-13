using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class myPrefab : MonoBehaviour
{

    public IObjectPool<GameObject> myPool { get; set; }


    float destroyTime = 3f;
    float time = 0f;

    float speed = 5f;

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if(time >= destroyTime)
        {
            time = 0;
            myPool.Release(this.gameObject);
        }


        transform.position += Vector3.forward * speed * Time.deltaTime;

    }

}
