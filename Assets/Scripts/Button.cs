using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject myGameObject;
    [SerializeField] GameObject myCube;
    

    public void OnClickButton()
    {
        myGameObject.transform.position += Vector3.forward;

    }

    public void OnClickGenerateCube()
    {
       GameObject myNewCube = Instantiate(myCube);
        myNewCube.transform.position = new Vector3(2, 2, 2);
    }

}
