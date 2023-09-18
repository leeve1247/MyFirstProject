using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public void OnClickGenerateCube()
    {
        MonsterSpawner.Inst.MyPool.Get();
    }

}
