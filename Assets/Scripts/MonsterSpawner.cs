using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject myPrefab;

    private IObjectPool<GameObject> myPool;
    public IObjectPool<GameObject> MyPool { get { return myPool; } }


    private static MonsterSpawner inst = null;
    public static MonsterSpawner Inst { get { if (inst == null) { return null; } return inst; } }


    Vector3 mobOriginPosition;


    private void Awake()
    {
        if(inst == null)
        {
            inst = FindAnyObjectByType<MonsterSpawner>();
            
            if(inst == null)
            {
                inst = this;

                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        myPool = new ObjectPool<GameObject>(CreateObject, BringObject,
            ReturnObject, OnDestroyObject, true, 10, 20);

        mobOriginPosition = transform.position;
        mobOriginPosition += Vector3.forward;
    }


    private GameObject CreateObject()
    {
        GameObject myObject = Instantiate<GameObject>(myPrefab);
        myObject.GetComponent<myPrefab>().myPool = this.myPool;
        myObject.transform.parent = this.transform;
        return myObject;
    }

    private void BringObject(GameObject myobject)
    {
        myobject.gameObject.SetActive(true);
        myobject.transform.position = mobOriginPosition;
    }

    private void ReturnObject(GameObject myObject)
    {
        myObject.gameObject.SetActive(false);
    }

    private void OnDestroyObject(GameObject myObject)
    {
        Destroy(myObject.gameObject);
    }

}
