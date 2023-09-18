using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    float spawnTime = 2f;
    float curTime = 0;

    //        Spawn.Inst.MyPool.Get();

    private void Update()
    {

        curTime += Time.deltaTime;

        // generate monster every 2 seconds
        if (curTime >= spawnTime)
        {

            if (MonsterSpawner.Inst.transform.childCount < 20)
            {
                MonsterSpawner.Inst.MyPool.Get();
                curTime = 0;
            }
        }
    }



}
