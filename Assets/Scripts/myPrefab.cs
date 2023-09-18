using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;

public class myPrefab : MonoBehaviour
{

    public IObjectPool<GameObject> myPool { get; set; }

    public NavMeshAgent agent;
    GameObject target;

    float destroyTime = 3f;
    float time = 0f;

    float speed = 5f;


    private void Awake()
    {
        target = FindAnyObjectByType<Cube>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            myPool.Release(this.gameObject);
        }
    }
}
