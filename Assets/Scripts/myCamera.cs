using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class myCamera : MonoBehaviour
{
    // to fade any object which blocking the player view
    List <ObjectFader> currentHitObjects = new List<ObjectFader>();
    List<ObjectFader> lastFadedObjects = new List<ObjectFader>();
    float camDistance;

    [Header("Camera Movement")]
    Vector3 myOffset;
    [SerializeField] private Transform myTarget;
    [SerializeField] private float smoothTime;

    Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    { 
        myOffset = transform.position - myTarget.position;
        camDistance = Vector3.Magnitude(transform.position - myTarget.position);
    }

    private void Update()
    {
        CheckObjectInFront();
        ShowObject();
        FadeObjects();
    }


    private void LateUpdate()
    {
        Vector3 targetPosition = myTarget.position + myOffset;
        targetPosition.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position,
        targetPosition, ref currentVelocity, smoothTime);
    }


    void CheckObjectInFront()
    {
        currentHitObjects.Clear();


        // create ray to the player
        Vector3 dir = myTarget.position - transform.position;

        Debug.DrawRay(transform.position, dir,Color.green);

        RaycastHit[] hits;

        Ray ray = new Ray(transform.position, myTarget.position - transform.position);
        hits = Physics.RaycastAll(ray, camDistance).OrderBy(h => h.distance).ToArray();

        for (int i = 0; i < hits.Length; ++i)
        {
            if (hits[0].collider.tag == "Player") { return; }

            if (hits[i].collider.TryGetComponent<ObjectFader>(out ObjectFader fader))
            {
                if (!currentHitObjects.Contains(fader))
                {
                    currentHitObjects.Add(fader);
                }
            }
        }
    }



    void FadeObjects()
    {
        for(int i = 0; i < currentHitObjects.Count; ++i)
        {
            currentHitObjects[i].isFaded = true;
            lastFadedObjects.Add(currentHitObjects[i]);
        }

    }

    void ShowObject()
    {
        for (int i = lastFadedObjects.Count  -1; i >= 0; --i)
        {
            lastFadedObjects[i].isFaded = false;
            lastFadedObjects.Remove(lastFadedObjects[i]);
        }
    }

}
