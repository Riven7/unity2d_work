using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 2f;
    public float spawnDelay = 1f;
    public GameObject enemy;
    public GameObject enemy2;
    public float dropRangeLeft = -13f;       //最左侧
    public float dropRangeRight = 14f;       // 最右侧

    // Start is called before the first frame update
    void Start()
    {
        //重复激发函数（在spawnDelay时间后开始执行Spawn函数，每隔spawnTime执行一次）
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        // 在最左和最右之间产生随机x值
        float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
        int who = Random.Range(1, 3);

        Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);
        if (who == 1)
            Instantiate(enemy2, dropPos, transform.rotation);
        else
            Instantiate(enemy, dropPos, transform.rotation);
    }
}
