using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject myPrefab;

    private IObjectPool<GameObject> myPool;

    public IObjectPool<GameObject> MyPool { get { return myPool; } }


    private static Spawn inst = null;

    public static Spawn Inst { get { if (inst == null) { return null; } return inst; } }


    private void Awake()
    {
        if(inst == null)
        {
            inst = FindAnyObjectByType<Spawn>();
            
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
            ReturnObject, OnDestroyObject, true, 5, 10);




        for(int i = 0; i < 10; ++i)
        {
            GameObject myObject = Instantiate(myPrefab);
            myObject.GetComponent<myPrefab>().myPool = this.myPool;

            myObject.transform.parent = this.transform;
            myObject.transform.position = Vector3.right * i * 3;
        }
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
        myobject.transform.position = new Vector3(0, 1, 0);
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
