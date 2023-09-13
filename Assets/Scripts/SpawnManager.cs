using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    public void OnClickGenerateCube()
    {
        Spawn.Inst.MyPool.Get();
    }



}
