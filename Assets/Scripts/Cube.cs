using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float rotateSpeed = 10;
    Vector3 moveDir;
    Vector3 lookDir;
    float jump = 3.0f;
    float gravity = -9.8f;

    CharacterController myCC;

    // Start is called before the first frame update
    void Start()
    {
        myCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        if (myCC.isGrounded == false)
        {
            moveDir.y += gravity * Time.deltaTime;
        }


        if(moveDir.x == 0 && moveDir.y == 0)
        {
            return;
        }


        lookDir = Vector3.forward * moveDir.z + Vector3.right * moveDir.x;


       

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myCC.Move(Vector3.up * 5f);
        }

        transform.forward = lookDir;
        myCC.Move(moveDir * Time.deltaTime);


    
       
    }
}
