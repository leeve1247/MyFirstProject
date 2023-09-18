using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // jump
    [Header("Jump related variables")]
    public bool hitSomething = false;
    public float jumpHeight = 20f;
    private float myVerticalVelocity;

    // gravity
    [Header("Gravity related variables")]
    public float gravity = -50f;
    public float dropSpeed = -5f;

    // player movement
    [Header("Player Movement related variables")]
    public float moveSpeed = 5f;
    float turningSpeed = 10f;
    Vector3 forward, right;

    // bullet shootting interval
    float bulletInterval = 1f;
    float curTime = 0f;


    private CharacterController myCC;
    private Vector3 moveDir;
    private Vector3 lookDir;


    // Start is called before the first frame update
    void Start()
    {
        myCC = GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }



    // Update is called once per frame
    void Update()
    {
        // get directional inputs 
        moveDir.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveDir.z = Input.GetAxis("Vertical") * moveSpeed;

        // if player is on ground 
        if (myCC.isGrounded)
        {
            hitSomething = false;
            myVerticalVelocity = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                myVerticalVelocity = jumpHeight;
            }
        }

        myVerticalVelocity += gravity * Time.deltaTime;

        moveDir.y = myVerticalVelocity;

        moveDir = Quaternion.Euler(0, 45f, 0) * moveDir;

        myCC.Move(moveDir * Time.deltaTime);

        if (moveDir.x != 0 || moveDir.z != 0)
        {
            // facing move direction 
            lookDir = new Vector3(moveDir.x, 0, moveDir.z);
            transform.forward = lookDir;

        }

        shootBullet();
    }


    private void shootBullet()
    {

        curTime += Time.deltaTime;

        if(curTime >= bulletInterval)
        {
            curTime = 0f;
            BulletManager.Inst.MyPool.Get();
        }
    }





    Collider lastCollidesObject = null;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        // if cube hit the ceiling, stop jump & drop the cube
        if (hit.collider.tag == "Ceiling")
        {
            hitSomething = true;

            myVerticalVelocity = dropSpeed;
        } 
    }
}
